# UNIDAD 2. LENGUAJE DE SERVIDOR. APLICACIONES

## Introducción

### Qué es .NET CORE

![](img/dotnet.PNG) 

### Cómo funcionan las páginas dotnet

![](img/funcionamientodotnet.PNG)


### Cómo se estructura una página

![](img/funcionamientodotnet.PNG)

### Cuál es flujo de una apliación web .net

![](flujodotnet.PNG)

### Qué podemos hacer con .NET CORE

- **APIs mínimas**: APIs HTTP simples que pueden ser consumidas por aplicaciones móviles o aplicaciones de una sola página basadas en navegador.
- **APIs web**: Un enfoque alternativo para construir APIs HTTP que agrega más estructura y características en comparación con las APIs mínimas.
- **APIs gRPC**: Se utilizan para crear APIs binarias eficientes para la comunicación entre servidores usando el protocolo gRPC.
- **Razor Pages**: Se utilizan para construir aplicaciones basadas en páginas renderizadas en el servidor.
- **Controladores MVC**: Similar a Razor Pages. Las aplicaciones de controladores de Modelo-Vista-Controlador (MVC) son para aplicaciones basadas en servidor, pero sin el paradigma basado en páginas.
- **Blazor WebAssembly**: Un marco de aplicación de una sola página basado en el navegador que utiliza el estándar WebAssembly, similar a los marcos de JavaScript como Angular, React y Vue.
- **Blazor Server**: Se utiliza para construir aplicaciones con estado, renderizadas en el servidor, que envían eventos de interfaz de usuario y actualizaciones de página a través de WebSockets para proporcionar la sensación de una aplicación de una sola página del lado del cliente, pero con la facilidad de desarrollo de una aplicación renderizada en el servidor.

### Páginas con estilos modernos de gran rendimiento

![](img/website.PNG)

### Funcionamiento de las APIs

![](img/restapi.PNG)

### Cómo está integrado dotnet en los servidore de aplicaciones/web

![](img/reverseproxy.PNG)

## Creación de aplicaciones web .net (api mínima)

![](img/simpleproject.PNG)

**Comandos de ejecución**

- dotnet restore
- dotnet build
- dotnet run

Cada uno de estos comandos debe ejecutarse dentro de la carpeta de tu proyecto y actuará solo sobre ese proyecto. 
Excepto donde se indique explícitamente, este es el caso para todos los comandos de la CLI de .NET. 

La mayoría de las aplicaciones ASP.NET Core tienen dependencias en varias bibliotecas externas, 
que se gestionan a través del gestor de paquetes NuGet. Estas dependencias se enumeran en el proyecto, 
pero los archivos de las bibliotecas en sí no están incluidos. Antes de que puedas compilar y ejecutar tu aplicación, 
debes asegurarte de que haya copias locales de cada dependencia en tu máquina. 

El primer comando, `dotnet restore`, asegura que las dependencias NuGet de tu aplicación se descarguen y que los archivos 
se referencien correctamente en tu proyecto.

Los proyectos ASP.NET Core enumeran sus dependencias en el archivo `.csproj` del proyecto, un archivo XML que lista 
cada dependencia como un nodo `PackageReference`. Cuando ejecutas `dotnet restore`, se usa este archivo para establecer 
qué paquetes NuGet descargar. Cualquier dependencia listada estará disponible para su uso en tu aplicación.

El proceso de restauración generalmente ocurre de manera implícita cuando compilas o ejecutas tu aplicación, 
como se muestra en la siguiente figura, pero a veces puede ser útil ejecutarlo explícitamente, 
como en los pipelines de integración continua.

![](img/compilation.PNG)

Si no quieres restaurar o construir, usar flags: ```--no-restore``` y ```--no-build```


### Paquetes Nuget

```dotnet add package Newtonsoft.Json```

```
<Project Sdk="Microsoft.NET.Sdk.Web">
	<PropertyGroup>
		<TargetFramework>net7.0</TargetFramework>
			<Nullable>enable</Nullable>
		<ImplicitUsings>enable</ImplicitUsings>
	</PropertyGroup>
	<ItemGroup>
		<PackageReference Include="NewtonSoft.Json" Version="13.0.1" />
	</ItemGroup>
</Project>
```

### Primera aplicación

![](img/primeraapp.PNG)

### Middleware

![](img/middleware.PNG)

### Landing page

![](img/landingpage.PNG)

![](img/opcionesuse.PNG)


---

# Prácticas

## Práctica 1: API de Gestión de Tareas (To-Do List)

Crea una API sencilla para gestionar una lista de tareas. Cada tarea tendrá un título, una descripción, y un estado (completada o no).

Requerimientos

Listado de Tareas: Permite listar todas las tareas.
Detalles de una Tarea: Obtén detalles de una tarea específica por su ID.
Agregar una Tarea: Permite agregar una nueva tarea.
Actualizar una Tarea: Permite actualizar los detalles de una tarea existente.
Eliminar una Tarea: Permite eliminar una tarea por su ID.

## Práctica 2: API de Gestión de Contactos

Aquí vamos a construir una API básica para gestionar una lista de contactos. Cada contacto tiene un nombre, un número de teléfono y un correo electrónico.

Requerimientos
Listado de Contactos: Permite listar todos los contactos.
Detalles de un Contacto: Obtén detalles de un contacto específico por su ID.
Agregar un Contacto: Permite agregar un nuevo contacto.
Actualizar un Contacto: Permite actualizar los detalles de un contacto existente.
Eliminar un Contacto: Permite eliminar

### Práctica 3: API de Carpooling para Cabify

Vamos a crear una API básica para un sistema de "carpooling" donde los conductores pueden ofrecer asientos 
para compartir y los pasajeros pueden reservar esos asientos. 
Este es un ejemplo simplificado destinado a ilustrar cómo podrías estructurar tal API.

Requerimientos

Listado de Viajes Disponibles: Permitir a los pasajeros ver todos los viajes disponibles.
Detalles de un Viaje: Obtener detalles adicionales sobre un viaje específico.
Publicar un Viaje: Permitir a los conductores publicar un nuevo viaje.
Reservar un Asiento en un Viaje: Permitir a los pasajeros reservar un asiento en un viaje.
Cancelar un Viaje: Permitir al conductor cancelar su viaje.