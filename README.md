CREACION DE PROYECTO.
**mkdir nuevacarpeta**

**cd nuevacarpeta.**

**dotnet new sln** = Comando para crear la solucion.

**dir** = con este comando observamos como va el proyecto.

**dotnet new webapi -o API** = Comando para crear el proyecto webApi.

**dotnet new classlib -o Core**= Comando para crear Core.

**dotnet new classlib -o  Infraestructure** = Se crea Infraestructure.

**dotnet  sln add .\API\** = Comando para asociar API con la solucion.

**dotnet sln add .\Core\** = Se asocia Core con la solucion.

**dotnet sln add .\Infraestructure\** = Hacemos lo mismo con Infraestructure.

**dotnet sln list** = Comando para verificar que todas las carpetas esten asociadas a la solucion.

**cd .\Infraestructure\** = Accedemos a la carpeta Infraestructure.

**dotnet add reference ..\Core\** = Comando para referenciar.

**cd ..**  = Salimos de la carpeta Infraestructure.

**cd .\API\** = Accedemos ahora a API

**dotnet add reference ..\Infraestructure\** = Referenciamos API con Infraestructure.
