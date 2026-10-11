# StockCafeterias

Sistema de control de inventario multi-local para cafeterías, desarrollado como trabajo grupal del curso de acceso a bases de datos con arquitectura en N-Capas (Windows y Web).

## Tecnologías

- Visual Studio 2026 y C#
- SQL Server (base de datos `StockCafeterias`)
- Entity Framework Core (base de datos primero)
- Windows Forms para el módulo de escritorio y ASP.NET para el módulo web (PA4)
- MSTest para las pruebas

## Arquitectura

| Proyecto | Responsabilidad | Referencia a |
|---|---|---|
| `StockCafeterias.Entidades` | Clases del modelo (`Modelos`) y clases de resultado de los procedimientos (`Listados`) | Ninguno |
| `StockCafeterias.Datos` | `DbContext`, clase `Conexion` y un repositorio por tabla que ejecuta los procedimientos almacenados | Entidades |
| `StockCafeterias.Negocio` | Validaciones y reglas de negocio | Datos, Entidades |
| `StockCafeterias.Windows` | Menú principal y formularios | Negocio, Entidades |
| `StockCafeterias.Pruebas` | Pruebas automáticas de los repositorios | Datos, Entidades |

**Regla principal:** `Windows` nunca referencia a `Datos`. Los formularios solo hablan con `Negocio`, y `Negocio` con `Datos`.

## Cómo ejecutar el proyecto en tu computadora

1. **Clona el repositorio** desde Visual Studio con Git, Clonar repositorio (o con `git clone`).
2. **Crea la base de datos.** Abre SQL Server Management Studio y ejecuta, en este orden y cada uno completo, los scripts de la carpeta `BaseDeDatos`:
   1. `01_crear_bd_v2.sql`
   2. `02_datos_prueba_v2.sql`
   3. `03_procedimientos_v2.sql`

   Al final, `sys.tables` debe mostrar 13 tablas y `sys.procedures` 25 procedimientos.
3. **Revisa la ruta de los archivos en el script 01.** Las líneas `FILENAME = '...'` apuntan a la carpeta `DATA` de SQL Server (`C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA`). Si tu instalación usa otra ruta, cámbiala solo en tu copia local antes de ejecutarlo.
4. **Ajusta la cadena de conexión.** En `StockCafeterias.Datos/Conexion.cs`, cambia `Server=localhost` por el nombre que usas al conectarte en SSMS (por ejemplo `.\SQLEXPRESS`). **No subas ese cambio al repositorio** si es distinto al de los demás.
5. **Compila** con Ctrl+Shift+B. Debe terminar con 0 errores.
6. **Ejecuta las pruebas** desde Prueba, Explorador de pruebas. Si salen en verde, tu entorno está bien configurado.

> Los archivos `.mdf` y `.ldf` no se suben a Git. Si necesitas la base ya armada, pídele los archivos al jefe de grupo.

## Estructura de carpetas

```
StockCafeterias/
├── BaseDeDatos/                  scripts SQL (01 a 04)
├── StockCafeterias.Entidades/
│   ├── Modelos/                  clases generadas desde las tablas
│   └── Listados/                 clases de resultado de los procedimientos
├── StockCafeterias.Datos/
│   ├── Contexto/                 StockCafeteriasContext
│   ├── Repositorios/             un repositorio por tabla
│   └── Conexion.cs
├── StockCafeterias.Negocio/
│   └── Servicios/
├── StockCafeterias.Windows/
│   └── Formularios/
└── StockCafeterias.Pruebas/
```

## Flujo de trabajo en Git

- La rama `main` siempre debe compilar. No se trabaja directamente sobre ella.
- Cada integrante crea su propia rama por tarea, por ejemplo `feature/insumo-repositorio` o `feature/form-usuario`.
- Antes de empezar a trabajar y antes de subir cambios, trae lo último de `main` (`git pull origin main`).
- Haz commits pequeños y con mensajes claros, por ejemplo: `Agrega InsumoRepositorio y sus clases de listado`.
- Antes de subir una rama, compila y ejecuta las pruebas.
- Se integra a `main` con un Pull Request, revisado por al menos otro integrante.
- Cada integrante trabaja solo en los archivos de su tarea, para evitar conflictos. Si necesitas cambiar un archivo de otra persona, avísale primero.

## Convenciones

- Nombres de clases y métodos en español y en PascalCase, igual que las tablas (`ProductoRepositorio`, `Listar`, `Insertar`).
- Los namespaces siguen el nombre del proyecto y la carpeta (`StockCafeterias.Datos.Repositorios`).
- Cada propiedad de una clase de `Listados` se llama igual que la columna que devuelve el procedimiento.
- Los formularios no contienen reglas de negocio ni acceso a datos: solo llaman a `Negocio`.
- Eliminar es una baja lógica (`Estado = 0`), nunca se borra un registro.

## Si la base de datos cambia

Las clases de `Entidades/Modelos` se generaron con `Scaffold-DbContext` y luego se movieron a su proyecto. **No vuelvas a ejecutar ese comando por tu cuenta**, porque sobrescribe archivos. Si hay que cambiar una tabla, avisa al jefe de grupo para hacerlo de forma coordinada y actualizar los scripts de `BaseDeDatos`.

## Estado y reparto de tareas

| Tarea | Estado | Responsable |
|---|---|---|
| Base de datos (13 tablas, 3 vistas, 25 procedimientos) | Listo | Sherlon |
| Estructura N-Capas, `Conexion` y `StockCafeteriasContext` | Listo | Sherlon |
| `ProductoRepositorio` y sus pruebas | Listo | Sherlon |
| `InsumoRepositorio` y sus clases de `Listados` | Listo | Renato |
| `UsuarioRepositorio` y sus clases de `Listados` | Listo | Renato |
| Repositorios de listas auxiliares (Categoría, Unidad de medida, Rol, Local) | Pendiente | |
| Capa de Negocio (validaciones de Producto, Insumo y Usuario) | Pendiente | |
| Menú principal | Pendiente | |
| Formulario de Producto | Pendiente | |
| Formulario de Insumo | Pendiente | |
| Formulario de Usuario | Pendiente | |

## Cronograma de entregables

| Entregable | Sesión | Contenido |
|---|---|---|
| PA1 | 4 | Base de datos en SQL Server (nota 17, observaciones corregidas) |
| PA2 | 7 | Solución N-Capas en Windows: menú principal y CRUD de Producto, Insumo y Usuario |
| PA3 | 10 | Inicio de sesión con registro de usuario |
| PA4 | 13 | Capa Web: 2 formularios de consulta con filtros, paginación y gráficos estadísticos |
| Examen final | 16 | Sistema completo, base de datos e informe final |
