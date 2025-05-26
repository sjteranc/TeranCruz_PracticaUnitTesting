# BEPractice

Proyecto de práctica que implementa una API REST con .NET Core, incluyendo pruebas unitarias.

## Estructura del Proyecto

```
BEPractice/
├── Controllers/     # Controladores de la API
│   ├── PersonController.cs
│   └── StudentController.cs
├── Models/         # Modelos de datos
├── Services/       # Servicios de negocio
│   ├── PersonService.cs
│   ├── StudentService.cs
│   ├── IPersonService.cs
│   └── IStudentService.cs
└── Tests/          # Pruebas unitarias

BEPractice.Tests/
├── Controllers/    # Pruebas de controladores
└── Services/       # Pruebas de servicios
```

## Requisitos

- .NET 6.0 o superior
- Visual Studio 2022 o Visual Studio Code

## Configuración

1. Clonar el repositorio
2. Abrir la solución en Visual Studio o VS Code
3. Restaurar los paquetes NuGet
4. Ejecutar el proyecto

## Ejecutar Pruebas

Para ejecutar las pruebas unitarias:

```bash
dotnet test
```

## Tecnologías Utilizadas

- .NET Core
- xUnit (para pruebas unitarias)
- Moq (para mocks en pruebas)
- ASP.NET Core Web API

## Endpoints de la API

### Personas
- GET `/api/person` - Obtener todas las personas
- GET `/api/person/{id}` - Obtener persona por ID
- GET `/api/is-adult/{id}` - Verificar si una persona es adulta
- POST `/api/person` - Crear nueva persona
- PUT `/api/person/{id}` - Actualizar persona
- DELETE `/api/person/{id}` - Eliminar persona

### Estudiantes
- GET `/api/student` - Obtener todos los estudiantes
- GET `/api/student/{id}` - Obtener estudiante por ID
- POST `/api/student` - Crear nuevo estudiante
- PUT `/api/student/{id}` - Actualizar estudiante
- DELETE `/api/student/{id}` - Eliminar estudiante 
