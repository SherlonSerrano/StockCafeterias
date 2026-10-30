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
| `StockCafeterias.Pruebas` | Pruebas automáticas de los repositorios y la autenticación | Datos, Negocio, Entidades |

**Regla principal:** `Windows` nunca referencia a `Datos`. Los formularios solo hablan con `Negocio`, y `Negocio` con `Datos`.

## Cómo ejecutar el proyecto en tu computadora

1. **Clona el repositorio** desde Visual Studio con Git, Clonar repositorio (o con `git clone`). Para trabajar con la PA3 mientras se revisa el Pull Request #3, utiliza la rama `feature/pa3-login-registro`.
2. **Revisa la ruta de los archivos en el script 1.** Las líneas `FILENAME = '...'` apuntan a la carpeta `DATA` de SQL Server (`C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA`). Si tu instalación usa otra ruta, cámbiala solo en tu copia local antes de ejecutarlo.
3. **Crea la base de datos.** Abre SQL Server Management Studio y ejecuta, en este orden, los scripts de la carpeta `BaseDeDatos`:
   1. `1.Script_BD_tablas_vistas.txt`
   2. `2.Script_datos_de_prueba.txt`
   3. `3.Script_procedimientos_almacenados.txt`
   4. `5.Script_PA3_ValidarLogin.sql`

   **Atención:** el script 1 elimina y recrea la base `StockCafeterias` si ya existe. Ejecútalo solo para preparar una base nueva o descartable. Si ya tienes la base de la PA2 configurada, ejecuta únicamente el script 5 para actualizar el procedimiento de login. El script 4 es de pruebas de la PA2 y no forma parte de la instalación.

   Al final, `sys.tables` debe mostrar 13 tablas y `sys.procedures` 25 procedimientos.
4. **Ajusta la cadena de conexión.** En `StockCafeterias.Datos/Conexion.cs`, cambia `Server=localhost` por el nombre que usas al conectarte en SSMS (por ejemplo `.\SQLEXPRESS`). **No subas ese cambio al repositorio** si es distinto al de los demás.
5. **Compila** con Ctrl+Shift+B. Debe terminar con 0 errores.
6. **Ejecuta la aplicación** desde el proyecto `StockCafeterias.Windows` (Ctrl+F5).
7. **Ejecuta las pruebas** desde Prueba, Explorador de pruebas. Las pruebas de repositorios requieren SQL Server configurado; las siete pruebas de seguridad y autenticación se explican en la sección PA3.

> Los archivos `.mdf` y `.ldf` no se suben a Git. Si necesitas la base ya armada, pídele los archivos al jefe de grupo.

## Estructura de carpetas

Se muestran los principales archivos y carpetas; los formularios también cuentan con sus archivos `.Designer.cs` y, cuando corresponde, `.resx`.

```text
StockCafeterias/
├── BaseDeDatos/                        scripts SQL de la PA1, PA2 y PA3
│   ├── 1.Script_BD_tablas_vistas.txt
│   ├── 2.Script_datos_de_prueba.txt
│   ├── 3.Script_procedimientos_almacenados.txt
│   ├── 4.Script_pruebas_finales.txt
│   └── 5.Script_PA3_ValidarLogin.sql
├── StockCafeterias.Entidades/
│   ├── Modelos/                        clases generadas desde las tablas
│   └── Listados/                       resultados de los procedimientos
│       └── UsuarioCredenciales.cs      PA3
├── StockCafeterias.Datos/
│   ├── Contexto/                       StockCafeteriasContext
│   ├── Repositorios/                   repositorios de acceso a datos
│   │   └── UsuarioRepositorio.cs
│   └── Conexion.cs
├── StockCafeterias.Negocio/
│   ├── Servicios/
│   │   ├── UsuarioServicio.cs
│   │   └── AutenticacionServicio.cs     PA3
│   └── Seguridad/
│       └── PasswordHasher.cs           PA3
├── StockCafeterias.Windows/
│   ├── Formularios/
│   │   ├── FrmMenuPrincipal.cs
│   │   ├── FrmLogin.cs                 PA3
│   │   ├── FrmRegistro.cs              PA3
│   │   └── ...                          formularios de Producto, Insumo y Usuario
│   ├── Utilidades/
│   └── Program.cs
├── StockCafeterias.Pruebas/
│   ├── PasswordHasherPruebas.cs         PA3
│   ├── AutenticacionServicioPruebas.cs  PA3
│   └── ...                              pruebas de repositorios
├── StockCafeterias.slnx
└── README.md
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
| Repositorios de listas auxiliares (Categoría, Unidad de medida, Rol, Local) | Listo | Fernando |
| Capa de Negocio (validaciones de Producto, Insumo y Usuario) | Listo | Fernando |
| Menú principal | Listo | Fernando |
| Formulario de Producto | Listo | Fernando |
| Formulario de Insumo | Listo | Fernando |
| Formulario de Usuario | Listo | Fernando |
| Pruebas finales | Listo | Sherlon |
| Formulario de inicio de sesión y registro de usuarios (PA3) | Listo (PR #3 en revisión) | Renato |
| Validación de contraseñas con PBKDF2 y `sp_ValidarLogin` (PA3) | Listo (PR #3 en revisión) | Renato |
| Control de acceso por roles (PA3) | Listo (PR #3 en revisión) | Renato |
| Pruebas de autenticación y seguridad (7 automatizadas) (PA3) | Listo (PR #3 en revisión) | Renato |

## Cronograma de entregables

| Entregable | Sesión | Contenido |
|---|---|---|
| PA1 | 4 | Base de datos en SQL Server (nota 17, observaciones corregidas) |
| PA2 | 7 | Solución N-Capas en Windows: menú principal y CRUD de Producto, Insumo y Usuario |
| PA3 | 10 | Inicio de sesión con registro de usuario |
| PA4 | 13 | Capa Web: 2 formularios de consulta con filtros, paginación y gráficos estadísticos |
| Examen final | 16 | Sistema completo, base de datos e informe final |


## PA3 - Inicio de sesión y registro

### Preparación de la base de datos

Los scripts y su orden de ejecución se detallan en **Cómo ejecutar el proyecto en tu computadora**.

Para la PA3 se agregó `BaseDeDatos/5.Script_PA3_ValidarLogin.sql`, que actualiza `dbo.sp_ValidarLogin` para recibir únicamente `@NombreUsuario`. El archivo `4.Script_pruebas_finales.txt` corresponde a pruebas anteriores de la PA2 y no es necesario para instalar la aplicación.

### Cuentas de demostración (PA3)

Para facilitar las pruebas de inicio de sesión y acceso por roles, se agregó el archivo `BaseDeDatos/6.Script_PA3_UsuariosDemo.sql`.

Si ya se tiene instalada la base de datos de la PA2, ejecutar los scripts 5 y 6, en ese orden, desde SQL Server Management Studio.

| Rol | Usuario | Contraseña |
|---|---|---|
| Administrador | admin_pa3 | AdminPA3#2026! |
| Invitado | invitado_pa3 | InvitadoPA3#2026! |

- Las contraseñas se almacenan mediante PBKDF2-SHA256.
- El script no modifica las cuentas existentes.

### Autenticación

La aplicación consulta las credenciales mediante `dbo.sp_ValidarLogin` y verifica las contraseñas en C# utilizando PBKDF2-SHA256.

Las contraseñas nuevas se almacenan como hashes.
Los valores antiguos `HASH_TEMP_000` son datos de ejemplo y no permiten iniciar sesión.

### Método de hash de contraseña

Para proteger las contraseñas de los usuarios, se implementó PBKDF2-HMAC-SHA256, con 600 000 iteraciones, una sal aleatoria de 16 bytes y un hash de 32 bytes.

Durante el registro, la clase PasswordHasher genera el hash que se almacena en SQL Server, evitando guardar la contraseña en texto plano.

Durante el inicio de sesión, el sistema recupera el hash mediante sp_ValidarLogin y verifica la contraseña ingresada mediante una comparación de tiempo constante.

Este método permite proteger las credenciales y dificulta los ataques de fuerza bruta.

### Registro de usuarios

`FrmRegistro` permite crear cuentas activas con rol **Invitado**. Valida que los campos estén completos, que las contraseñas coincidan, que tengan entre 12 y 128 caracteres y que el nombre de usuario no esté repetido.

### Control de acceso por roles

El menú principal muestra el usuario autenticado y habilita los módulos según su rol:

| Rol | Productos | Insumos | Usuarios |
|---|---|---|---|
| Admin | Permitido | Permitido | Permitido |
| Encargado de Local | Permitido | Permitido | Restringido |
| Invitado | Restringido | Restringido | Restringido |

Para comprobar el rol Admin con una cuenta registrada, se puede seguir la prueba manual opcional indicada al final de esta sección.

### Pruebas

Para verificar el funcionamiento del inicio de sesión y la seguridad de las contraseñas:

1. Abrir Visual Studio 2026.
2. Abrir la solución `StockCafeterias.slnx`.
3. Ir a Ver → Terminal (PowerShell).
4. Verificar que la terminal esté ubicada en la carpeta raíz del proyecto StockCafeterias.
5. Copiar y ejecutar el siguiente comando:

   ```powershell
   dotnet test StockCafeterias.Pruebas/StockCafeterias.Pruebas.csproj --filter "FullyQualifiedName~PasswordHasherPruebas|FullyQualifiedName~AutenticacionServicioPruebas"
   ```

Resultado esperado:
- 7 pruebas correctas.
- 0 errores.
- 0 pruebas omitidas.

Estas siete pruebas no requieren conectarse a SQL Server; otras pruebas del proyecto sí pueden necesitar una base configurada.

### Prueba manual del rol Administrador

Esta prueba es opcional y se realiza en la base de datos local de desarrollo.

1. Ejecutar la aplicación.
2. Registrar una cuenta nueva desde el formulario de registro, con un nombre de usuario de prueba.
3. Cerrar la aplicación.
4. Abrir SQL Server Management Studio.
5. Ejecutar en la base StockCafeterias:

   ```sql
   USE StockCafeterias;
   GO

   UPDATE dbo.Usuario
   SET IdRol = 1
   WHERE NombreUsuario = 'USUARIO_DE_PRUEBA'
     AND IdRol = 3
     AND Estado = 1;
   ```

   Reemplazar `USUARIO_DE_PRUEBA` por el nombre utilizado al registrarse. Verificar que se haya actualizado exactamente una fila.

6. Iniciar sesión nuevamente con esa cuenta.
7. Verificar que aparezca el rol Admin y que estén habilitados Productos, Insumos y Usuarios.
8. Cerrar la aplicación y restaurar el rol original:

   ```sql
   USE StockCafeterias;
   GO

   UPDATE dbo.Usuario
   SET IdRol = 3
   WHERE NombreUsuario = 'USUARIO_DE_PRUEBA'
     AND IdRol = 1
     AND Estado = 1;
   ```

   Verificar que se haya restaurado exactamente una fila.

**Nota:** usar una cuenta de prueba y devolverla al rol Invitado al finalizar.
