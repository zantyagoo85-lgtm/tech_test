# Prueba Técnica - Ejecución del Proyecto

## Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) instalado
- Visual Studio 2022 (actualizado)
- Navegador web moderno (Edge, Chrome, Firefox, etc.)

## Estructura del proyecto

- **prueba_tecnica.API**: Backend (API REST .NET 8)
- **prueba_tecnica.Front.Client**: Frontend (Blazor WebAssembly)
- **prueba_tecnica.Front**: Host/Server

---

## Ejecución en Visual Studio

1. Abre la solución en Visual Studio 2022.
2. En la barra superior, selecciona el perfil personalizado llamado **Start Project**.
   - Este perfil fue configurado desde Visual Studio, seleccionando qué proyectos ejecutar y qué perfil usar en cada uno.
   - No se encuentra en los archivos `launchSettings.json`, sino en la configuración de inicio múltiple de la solución.
3. Haz clic en el botón **Iniciar** (F5) o **Ctrl+F5** para ejecutar sin depuración.

---

## Ejecución desde la línea de comandos

Como el perfil múltiple es exclusivo de Visual Studio, desde la terminal debes iniciar cada proyecto por separado, usando el perfil `https` en cada uno:

1. Verifica que tienes instalado .NET 8:
    dotnet --version

        Debe mostrar `8.0.x`.

2. Ejecuta la API (desde la carpeta del proyecto API):
    cd prueba_tecnica.API dotnet run --launch-profile "https"


3. Ejecuta el Frontend (desde la carpeta del proyecto Front):

   cd prueba_tecnica.Front/prueba_tecnica.Front dotnet run --launch-profile "https"


   - El perfil `https` está definido en los archivos `launchSettings.json` de cada proyecto.

---

## Notas adicionales

- El perfil **Start Project** solo está disponible en Visual Studio y no en la línea de comandos.
- Si necesitas cambiar puertos, revisa los archivos `launchSettings.json`.
- Si usas certificados de desarrollo, acepta el certificado en el navegador si es solicitado.

---
