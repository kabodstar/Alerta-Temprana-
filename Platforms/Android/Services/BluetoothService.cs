using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Bluetooth;
using AlertaTemprana.Services;
using Java.Util;
using Microsoft.Maui.ApplicationModel;
using System.Text;

namespace AlertaTemprana.Platforms.Android.Services;

public class BluetoothService : IWaterLevelSource
{
    private const string NombreDispositivo = "HC-05";

    private static readonly UUID SppUuid =
        UUID.FromString("00001101-0000-1000-8000-00805F9B34FB")!;

    private BluetoothSocket? _socket;
    private System.IO.Stream? _inputStream;
    private CancellationTokenSource? _cancellationTokenSource;

    public event EventHandler<string>? DataReceived;
    public event EventHandler<bool>? ConnectionStateChanged;

    public async Task<bool> ConnectAsync()
    {
        if (_socket is not null && _socket.IsConnected)
            return true; // Ya hay una conexión activa: no abrimos un segundo canal.

        if (OperatingSystem.IsAndroidVersionAtLeast(31))
        {
            var estadoPermiso = await Permissions.RequestAsync<BluetoothConnectPermission>();
            if (estadoPermiso != PermissionStatus.Granted)
            {
                ConnectionStateChanged?.Invoke(this, false);
                return false;
            }
        }

       

        var adapter = BluetoothAdapter.DefaultAdapter;

        if (adapter is null || !adapter.IsEnabled)
        {
            ConnectionStateChanged?.Invoke(this, false);
            return false;
        }

        var dispositivoObjetivo = adapter.BondedDevices?
            .FirstOrDefault(dispositivo => dispositivo.Name == NombreDispositivo);

        if (dispositivoObjetivo is null)
        {
            ConnectionStateChanged?.Invoke(this, false);
            return false;
        }

        try
        {
            _socket = dispositivoObjetivo.CreateRfcommSocketToServiceRecord(SppUuid);
    

            await Task.Run(() => _socket.Connect());

            _inputStream = _socket.InputStream;
            ConnectionStateChanged?.Invoke(this, true);

            _cancellationTokenSource = new CancellationTokenSource();
            _ = Task.Run(() => EscucharDatos(_cancellationTokenSource.Token));

            return true;
        }
        catch (Java.IO.IOException)
        {
            ConnectionStateChanged?.Invoke(this, false);
            return false;
        }
    }

    private void EscucharDatos(CancellationToken token)
    {
        var buffer = new byte[1024];
        var lineaActual = new StringBuilder();

        while (!token.IsCancellationRequested && _inputStream is not null)
        {
            try
            {
                int bytesLeidos = _inputStream.Read(buffer, 0, buffer.Length);

                for (int i = 0; i < bytesLeidos; i++)
                {
                    char caracter = (char)buffer[i];

                    if (caracter == '\n')
                    {
                        string linea = lineaActual.ToString().Trim();
                        lineaActual.Clear();

                        if (!string.IsNullOrEmpty(linea))
                            DataReceived?.Invoke(this, linea);
                    }
                    else
                    {
                        lineaActual.Append(caracter);
                    }
                }
            }
            catch (Java.IO.IOException)
            {
                ConnectionStateChanged?.Invoke(this, false);
                break;
            }
        }
    }

    public void Disconnect()
    {
        _cancellationTokenSource?.Cancel();
        _inputStream?.Close();
        _socket?.Close();
        ConnectionStateChanged?.Invoke(this, false);
    }
}