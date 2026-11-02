-- ========================================================================
-- StockCafeterias / PA3: cuentas de demostración para autenticación
-- 6.Script_PA3_UsuariosDemo.sql
-- ========================================================================
-- Requisitos: base StockCafeterias de PA2, y luego ejecutar script 5.
-- Ejecutar una sola vez (si se ejecuta otra vez, no duplica usuarios).
-- SOLO PARA DEMOSTRACIÓN ACADÉMICA EN BASES DE DESARROLLO.
--
-- Cuentas de demostración:
--   Rol Admin:    admin_pa3    / AdminPA3#2026!
--   Rol Invitado: invitado_pa3 / InvitadoPA3#2026!
--
-- Los passwords se almacenan como PBKDF2-HMAC-SHA256 (600.000 iteraciones,
-- sal aleatoria de 16 bytes, hash de 32 bytes), NO como texto plano.
-- Los valores ya existentes con estos nombres NO se modifican.
-- ========================================================================

USE StockCafeterias;
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;

IF NOT EXISTS (SELECT 1 FROM dbo.Rol WHERE IdRol = 1 AND Nombre = N'Admin')
   OR NOT EXISTS (SELECT 1 FROM dbo.Rol WHERE IdRol = 3 AND Nombre = N'Invitado')
BEGIN
    THROW 50100, 'Faltan los roles esperados (1=Admin, 3=Invitado).', 1;
END;
GO

BEGIN TRY
    BEGIN TRANSACTION;

    IF NOT EXISTS (SELECT 1 FROM dbo.Usuario WHERE NombreUsuario = N'admin_pa3')
    BEGIN
        EXEC dbo.sp_Usuario_Insertar
            @Nombres = N'Administrador',
            @Apellidos = N'Demo PA3',
            @NombreUsuario = N'admin_pa3',
            @PasswordHash = N'PBKDF2-SHA256$600000$irmytDSe/P0ZBvkV5RRs/Q==$pna8vvoHLiUCQmtpDrDwVhmHiW8QyZZHXyKB5M77mtk=',
            @IdRol = 1,
            @IdLocal = NULL,
            @Usuario = N'demo-pa3';
        PRINT N'Cuenta admin_pa3 creada.';
    END
    ELSE
        PRINT N'Cuenta admin_pa3 ya existe; se conserva sin cambios.';

    IF NOT EXISTS (SELECT 1 FROM dbo.Usuario WHERE NombreUsuario = N'invitado_pa3')
    BEGIN
        EXEC dbo.sp_Usuario_Insertar
            @Nombres = N'Invitado',
            @Apellidos = N'Demo PA3',
            @NombreUsuario = N'invitado_pa3',
            @PasswordHash = N'PBKDF2-SHA256$600000$eHy64QST/ke1gvAFVkw49Q==$vb+5e1sqLTlxhrA5bQ0x+BxB7d5aWCtvDLK8nYanX9s=',
            @IdRol = 3,
            @IdLocal = NULL,
            @Usuario = N'demo-pa3';
        PRINT N'Cuenta invitado_pa3 creada.';
    END
    ELSE
        PRINT N'Cuenta invitado_pa3 ya existe; se conserva sin cambios.';

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    THROW;
END CATCH;
GO

-- Comprobación de cuentas. "Lista" exige rol, estado y hash esperados.
-- Si sale "Revisar", posiblemente ya existía ese nombre de usuario.
SELECT
    u.NombreUsuario,
    r.Nombre AS Rol,
    u.Estado,
    CASE
        WHEN u.NombreUsuario = N'admin_pa3'
            AND u.IdRol = 1 AND u.Estado = 1
            AND u.PasswordHash = N'PBKDF2-SHA256$600000$irmytDSe/P0ZBvkV5RRs/Q==$pna8vvoHLiUCQmtpDrDwVhmHiW8QyZZHXyKB5M77mtk=' THEN N'Lista'
        WHEN u.NombreUsuario = N'invitado_pa3'
            AND u.IdRol = 3 AND u.Estado = 1
            AND u.PasswordHash = N'PBKDF2-SHA256$600000$eHy64QST/ke1gvAFVkw49Q==$vb+5e1sqLTlxhrA5bQ0x+BxB7d5aWCtvDLK8nYanX9s=' THEN N'Lista'
        ELSE N'Revisar: nombre ya usado o cuenta modificada'
    END AS Verificacion
FROM dbo.Usuario AS u
INNER JOIN dbo.Rol AS r ON r.IdRol = u.IdRol
WHERE u.NombreUsuario IN (N'admin_pa3', N'invitado_pa3')
ORDER BY u.NombreUsuario;
GO
