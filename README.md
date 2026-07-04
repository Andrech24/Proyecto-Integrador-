# TaskFlow SOLID

Proyecto academico simple en ASP.NET Core MVC con API JSON y cliente React.

## Ejecutar

```powershell
dotnet run
```

Rutas principales:

- MVC: `http://localhost:5000/Tareas`
- API JSON: `http://localhost:5000/api/tareas`
- React: `http://localhost:5000/react-app/index.html`

## Mejoras aplicadas

- Principio de responsabilidad unica: controladores, servicio, repositorio y factory tienen responsabilidades separadas.
- Principio de inversion de dependencias: `TareaService` depende de `ITareaRepository` e `ITareaFactory`, no de clases concretas.
- Patron Repository: encapsula el acceso a datos.
- Patron Strategy: calcula prioridad segun fecha de entrega.
- Patron Factory Method: centraliza la creacion valida de una tarea.

## API

`GET /api/tareas` devuelve un arreglo JSON:

```json
[
  {
    "id": 1,
    "titulo": "Informe de bases de datos",
    "descripcion": "Preparar consultas y capturas de evidencia.",
    "materia": "Ingenieria Web",
    "fechaEntrega": "2026-07-06T00:00:00",
    "estado": "Pendiente",
    "prioridad": 5
  }
]
```
