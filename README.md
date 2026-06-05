# SwitchAppConfig

Aplicación WinForms en VB.NET para modificar directamente archivos `App.config` y `*.exe.config`, cambiando todas las cadenas de conexión SQL Server entre entornos como `DOM` y `app01\\vectorerp`.

## Funcionalidades

- Selección de archivo `.config`
- Copia de seguridad automática `.bak`
- Cambio directo de todas las `connectionStrings`
- Botones rápidos para:
  - `DOM`
  - `app01\\vectorerp`
  - servidor personalizado
- Log de cambios
- Restauración desde backup
- Recuerda la última ruta usada

## Requisitos

- Visual Studio 2022 o compatible
- .NET Framework 4.8

## Uso

1. Abre la solución `SwitchAppConfig.sln`
2. Ejecuta el proyecto `SwitchAppConfig`
3. Selecciona tu archivo `App.config` o `MiAplicacion.exe.config`
4. Elige el servidor destino
5. Pulsa el botón para aplicar el cambio

## Nota

La aplicación modifica el archivo seleccionado directamente y crea una copia `.bak` antes de guardar los cambios.
