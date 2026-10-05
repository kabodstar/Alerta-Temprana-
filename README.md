# AlertaTemprana v0.9.0

**Sistema de Monitoreo en Tiempo Real del Nivel de Agua para Detección Temprana de Inundaciones**

---

##  Descripción General

AlertaTemprana es una aplicación móvil para Android que monitorea el nivel del agua en zonas propensas a inundaciones. Se conecta a un sensor ultrasónico vía Bluetooth, recibe datos en tiempo real y los presenta de forma clara y visual, permitiendo identificar cambios en el nivel antes de que se vuelvan críticos.

La app está diseñada para ser intuitiva, incluso para usuarios sin conocimientos técnicos, y proporciona alertas automáticas cuando el nivel alcanza condiciones de riesgo o peligro.

---

##  Características Principales

- **Monitoreo en tiempo real**: Visualiza el nivel del agua en metros con actualización continua
- **Indicador visual dinámico**: Barra que sube y baja según el nivel medido
- **Sistema de tres alertas**: Seguro (verde), Riesgo (amarillo), Peligro (rojo)
- **Notificaciones automáticas**: Recibe avisos incluso si la app está minimizada
- **Historial completo**: Registra todos los eventos de riesgo y peligro
- **Filtrado avanzado**: Filtra por rango de fechas y tipo de evento
- **Interfaz profesional**: Diseño limpio, colores coherentes, fácil de navegar
- **Sin conexión a internet**: Funciona completamente offline (solo necesita Bluetooth)
- **Almacenamiento local**: Guarda el historial en el teléfono, datos privados

---

##  Requisitos

### Hardware
- **Teléfono Android** versión 8.0 (API 21) o superior
- **Bluetooth** habilitado en el teléfono
- **Maqueta con sensor ultrasónico** conectada a un microcontrolador Arduino
- **Módulo Bluetooth HC-06** instalado en la maqueta

### Software
- **AlertaTemprana v0.9.0** (este archivo `.apk`)
- **Permisos otorgados**: Bluetooth y Notificaciones (se piden al primer uso)

---

##  Instalación

### Paso 1: Descargar la aplicación

Descarga el archivo `AlertaTemprana_v0.9.0_Release.apk` desde MediaFire o la fuente proporcionada.

### Paso 2: Permitir instalación de fuentes desconocidas

Si es la primera vez que instalas una app desde un archivo APK:

1. Ve a **Ajustes → Seguridad** (o **Privacidad y seguridad**, según el modelo)
2. Busca **"Instalar desde fuentes desconocidas"** o **"Aplicaciones de orígenes desconocidos"**
3. Habilita la opción y marca **"Permitir solo para esta app"** o **"Archivo Manager"** (según lo que te pida)

### Paso 3: Instalar

1. Abre el archivo `AlertaTemprana_v0.9.0_Release.apk`
2. Presiona **"Instalar"**
3. Espera a que termine (tarda unos segundos)
4. Cuando se complete, presiona **"Abrir"** o cierra y busca el ícono de AlertaTemprana en tu bandeja de apps

---

##  Configuración Inicial

### Emparejar el módulo Bluetooth (HC-06)

Esto **solo se hace una sola vez**. Luego, la app recordará el dispositivo.

1. Enciende tu maqueta (Arduino + sensor + módulo HC-06 alimentados)
2. Ve a **Ajustes del teléfono → Bluetooth**
3. Asegúrate de que Bluetooth esté **activado**
4. En la lista de dispositivos disponibles, busca **"HC-06"**
5. Toca **"HC-06"** para emparejar
6. Si pide un código PIN (generalmente **1234** o **0000**), ingrésalo
7. Cuando aparezca "HC-06" en la lista de dispositivos emparejados, cierra Ajustes

### Otorgar permisos a la app

1. Abre **AlertaTemprana**
2. En la pantalla principal, presiona **"Conectar HC-05"**
3. Android te pedirá permisos:
   - **Bluetooth**: presiona **"Permitir"**
   - **Notificaciones** (en Android 13+): presiona **"Permitir"**
4. La app ahora tiene acceso completo

---

##  Uso de la aplicación

### Pantalla de Inicio

**Esta es la pantalla principal donde ves los datos en tiempo real.**

#### Elementos:

- **Estado de Bluetooth** (arriba): Muestra "Conectado" (verde) o "Desconectado" (rojo)
- **Botón "Conectar HC-05"**: Presiona aquí para vincular el teléfono con el sensor
- **Nivel del agua actual**: El número grande en metros, acompañado de una barra visual que sube y baja
- **Regla de referencia**: Escala de 0.00 a 2.00 metros para contextualizar el nivel
- **Nivel de alerta**: Indica el estado actual (SEGURO, RIESGO, PELIGRO) con descripción
- **Semáforo de colores**: Leyenda que explica qué significa cada color
- **Sistema activo**: Confirmación de que las notificaciones están habilitadas

#### Cómo usar:

1. Asegúrate de que Bluetooth esté encendido y el HC-06 emparejado
2. Presiona **"Conectar HC-05"**
3. El estado debe cambiar a "Bluetooth: conectado" (en verde)
4. Observa el nivel del agua — se actualiza automáticamente cada 2 segundos
5. Cuando el nivel alcance RIESGO o PELIGRO, recibirás una notificación automática

---

### Pantalla de Historial

**Aquí ves el registro de todos los eventos de riesgo y peligro.**

#### Elementos:

- **Encabezado**: "Historial — Registro de niveles y alertas"
- **Filtro de fecha**: "Últimas 24 horas" (puedes cambiar a "Última semana", "Último mes" o "Todo el historial")
- **Filtro de evento**: "Todos los eventos" (puedes filtrar solo "RIESGO" o solo "PELIGRO")
- **Botón de calendario**: Abre el selector de fechas
- **Botón de borrar**: Elimina todo el historial (con confirmación)
- **Lista de registros**: Cada entrada muestra:
  - Nivel de agua alcanzado (en metros)
  - Estado (RIESGO o PELIGRO)
  - Fecha y hora exacta
  - Pequeño indicador visual del nivel

#### Cómo usar:

1. Toca **"Historial"** en la barra inferior
2. Por defecto, ves los últimos eventos (últimas 24 horas)
3. Si quieres ver más, toca **"Últimas 24 horas"** y elige otro rango
4. Si quieres filtrar por tipo, toca **"Todos los eventos"** y elige "Solo RIESGO" o "Solo PELIGRO"
5. Para limpiar todo, presiona el ícono de borrar y confirma
6. Para volver a la pantalla principal, toca **"Inicio"** en la barra inferior

---

##  Sistema de Alertas

### Estados de alerta

| Estado | Color | Significado | Acción |
|--------|-------|-------------|--------|
| **SEGURO** | Verde | El nivel del agua está dentro de rangos normales | Ninguna inmediata |
| **RIESGO** | Amarillo | El nivel está subiendo y se acerca a un valor de atención | Prestar atención a la zona |
| **PELIGRO** | Rojo | El nivel alcanzó un valor crítico | Tomar precauciones inmediatas |

### Notificaciones

Cuando el nivel pasa de SEGURO a RIESGO o a PELIGRO, la app:
1. Actualiza la pantalla en tiempo real
2. Guarda el evento en el historial
3. Envía una **notificación del sistema operativo** (incluso si la app está minimizada)

La notificación muestra:
- Título: "Alerta Temprana: [RIESGO/PELIGRO]"
- Descripción: Mensaje específico del estado

### Historial automático

Solo se registran los eventos de **RIESGO y PELIGRO**. Los momentos en estado SEGURO no se guardan, para mantener el historial enfocado en lo importante.

---

## 🔗 Conexión Bluetooth

### Conexión manual

Presiona **"Conectar HC-05"** en la pantalla de Inicio cada vez que quieras establecer conexión. Es especialmente útil si:
- Encendiste la app sin la maqueta conectada
- Apagaste y volviste a encender la maqueta
- La conexión se perdió por alguna razón

### Conexión persistente

Una vez conectado, **la conexión se mantiene activa** aunque cambies de pestañas (Inicio ↔ Historial). No es necesario reconectar cada vez que navegas.

### Si la conexión falla

**Verificar:**
- ¿La maqueta está encendida?
- ¿El HC-06 está emparejado desde los Ajustes de Bluetooth?
- ¿El teléfono tiene Bluetooth habilitado?
- ¿La app tiene permiso de Bluetooth?

**Soluciones:**
1. Presiona nuevamente "Conectar HC-05"
2. Apaga y enciende el Bluetooth del teléfono
3. Desempareja y vuelve a emparejar el HC-06 desde Ajustes
4. Reinicia la app completamente

---

##  Detalles Técnicos

### Especificaciones

- **Nombre de paquete**: `com.alertatemprana.app`
- **Versión**: 0.9.0 (Release Candidate)
- **Framework**: .NET MAUI 9.0
- **Plataforma destino**: Android 8.0+
- **Tamaño aproximado**: ~40-50 MB
- **Permisos requeridos**: BLUETOOTH_CONNECT, POST_NOTIFICATIONS, INTERNET (solo para futuras actualizaciones)

### Almacenamiento

- **Historial**: Se guarda en formato JSON en la carpeta privada de la app (`/data/data/com.alertatemprana.app/files/`)
- **Datos**: Completamente local, no se envía a servidores
- **Privacidad**: Los datos nunca salen de tu teléfono

### Rendimiento

- **Actualización de datos**: Cada 2 segundos
- **Consumo de batería**: Bajo a moderado (depende de si Bluetooth está activo)
- **Conexión de red**: No requerida

---

##  Solución de Problemas

### "No se puede conectar el Bluetooth"

**Causa:** El módulo HC-06 no está emparejado o la app no tiene permisos.

**Solución:**
1. Ve a Ajustes → Bluetooth del teléfono
2. Busca "HC-06" en dispositivos disponibles
3. Empareja (PIN: 1234 o 0000)
4. Abre AlertaTemprana y presiona "Conectar HC-05"

---

### "No aparece ningún número"

**Causa:** El Bluetooth está desconectado o el sensor no envía datos.

**Solución:**
1. Confirma que el estado dice "Bluetooth: conectado"
2. Enciende la maqueta
3. Verifica que el sensor ultrasónico esté correctamente conectado
4. Presiona "Conectar HC-05" nuevamente

---

### "No recibo notificaciones"

**Causa:** El permiso de notificaciones no está otorgado.

**Solución:**
1. Ve a Ajustes → Aplicaciones → AlertaTemprana → Notificaciones
2. Activa el permiso
3. Vuelve a la app y presiona "Conectar HC-05"


## Información de Contacto y Soporte

### Sobre esta versión

- **Versión**: 0.9.0 (Release Candidate)
- **Estado**: Completamente funcional, listo para uso
- **Desarrollador**: AlertaTemprana Dev
- **Fecha**: Octubre de 2026

### Limitaciones conocidas (para futuras versiones)

- Los íconos internos de la app son placeholders (no afecta la funcionalidad)
- Notificaciones locales solo disponibles en Android (iOS planeado)
- Sin sincronización en la nube (datos solo en el teléfono)

### Feedback y mejoras

Esta es una versión temprana. Si encuentras problemas o tienes sugerencias, considera reportarlos para futuras actualizaciones.

---

## Licencia y Uso

AlertaTemprana es una herramienta educativa y personal. Fue desarrollada como proyecto académico. Úsalo libremente para monitorear niveles de agua en tu zona.

**Disclaimer:** AlertaTemprana es un sistema de monitoreo complementario. No reemplaza las indicaciones de las autoridades locales ni es una herramienta de prevención de inundaciones garantizada. Su función es informar oportunamente sobre cambios en el nivel de agua para apoyar tu toma de decisiones.

---

## Recursos Adicionales

- **Manual de Usuario completo**: Incluido en el proyecto (Manual_Usuario_AlertaTemprana.docx)
- **Video explicativo**: Guion disponible (Guion_Video_AlertaTemprana.md)
- **Código fuente**: Desarrollado en .NET MAUI, disponible en GitHub

---

## Checklist antes de usar

- [ ] APK descargado correctamente
- [ ] Teléfono con Android 8.0+
- [ ] Bluetooth activado en el teléfono
- [ ] HC-06 emparejado desde Ajustes
- [ ] Permisos de Bluetooth y Notificaciones otorgados
- [ ] Maqueta encendida y sensor funcionando

---

**¡Gracias por usar AlertaTemprana! Esperamos que te sea útil en el monitoreo de tu zona.**

---

*Para más información técnica o actualizaciones, visita el repositorio del proyecto.*
