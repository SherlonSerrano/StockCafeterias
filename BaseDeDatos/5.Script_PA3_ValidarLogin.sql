USE StockCafeterias;
GO

-- =====================================================
-- PA3: Autenticación de usuarios
-- Procedimiento: sp_ValidarLogin
-- =====================================================
-- Obtiene los datos de un usuario activo y su hash.
-- La contraseña se verifica en la capa Negocio
-- mediante PasswordHasher.Verificar().
-- =====================================================

CREATE OR ALTER PROCEDURE dbo.sp_ValidarLogin
    @NombreUsuario NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        u.IdUsuario,
        u.Nombres + ' ' + u.Apellidos AS NombreCompleto,
        u.NombreUsuario,
        u.PasswordHash,
        u.IdRol,
        r.Nombre AS Rol,
        u.IdLocal
    FROM dbo.Usuario AS u
    INNER JOIN dbo.Rol AS r
        ON r.IdRol = u.IdRol
    WHERE u.NombreUsuario = @NombreUsuario
      AND u.Estado = 1;
END;
GO
