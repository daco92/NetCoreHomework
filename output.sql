ALTER TABLE [Person] ADD [DateModified] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Department] ADD [DateModified] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Course] ADD [DateModified] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200521095158_addDateModified', N'3.1.4');

GO

