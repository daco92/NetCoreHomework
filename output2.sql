ALTER TABLE [Person] ADD [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [Course] ADD [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200522021056_IsDeletedFlag', N'3.1.4');

GO

