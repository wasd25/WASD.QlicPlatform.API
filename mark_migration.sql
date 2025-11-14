-- Script para marcar la migración como aplicada
USE `qlic-database`;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20251114215548_AddAlertsAndAnomalies', '9.0.10');

