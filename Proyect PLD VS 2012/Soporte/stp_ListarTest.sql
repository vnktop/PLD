IF EXISTS (	SELECT							1
			FROM							SYSOBJECTS
			WHERE							NAME = 'stp_ListarTest'
			AND								TYPE = 'P' )
	DROP PROCEDURE		stp_ListarTest
GO

CREATE PROCEDURE stp_ListarTest
AS 
BEGIN
SELECT 
	id,
	Descripcion
  FROM dbTest  
END
-- exec stp_ListarTest