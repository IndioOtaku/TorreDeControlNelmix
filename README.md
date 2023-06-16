# TorreDeControlNelmix
Una api swagger de un sistema que simula de manera simple una torre de control de una aerolínea creada para realizar la prueba backend de los aspirantes a pasantía

## Dependencias
- .Net7
- .Net Core
- Entity Framework core:  Microsoft.EntityFrameworkCore.SqlServer
## Instalacion
Si no se tiene instalado .NET descargar aqui: https://dotnet.microsoft.com/download

En la consola de git colocar:

~~~
git clone https://github.com/IndioOtaku/TorreDeControlNelmix.git
~~~

Abrir y ejecutar el query del llamado PruebaTécnicaDB.sql

Abrir la solución PruebaTécnica/TorreDeControl.WebApi/TorreDeControl.WebApi.sln

En el archivo PruebaTécnica/TorreDeControl.WebApi/TorreDeControl.WebApi1/appsettings.json modificar la línea 5 modificando la propiedad Server
~~~
"DefaultConnection": "Server=TuServidor;Database=TorreDeControlAerolíneasNelmix;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True"
~~~
## Autor
[IndiOtaku](https://github.com/IndioOtaku)
