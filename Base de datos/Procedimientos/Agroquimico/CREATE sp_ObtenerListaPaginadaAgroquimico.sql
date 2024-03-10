USE agro_sistema_bd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_ObtenerListaPaginadaAgroquimico')
	DROP PROCEDURE sp_ObtenerListaPaginadaAgroquimico
GO

CREATE PROCEDURE sp_ObtenerListaPaginadaAgroquimico(
	@pNombre  varchar(100) = null,
	@idTipoAgroquimico int = null,
	@pIdUsuario int,
	@pPageNumber int,
	@pPageSize int
)
as
begin
	declare @nNombre varchar(100) = @pNombre
	declare @nIdTipoAgroquimico int = @idTipoAgroquimico 	
	declare @nPageNumber int = @pPageNumber
	declare @nPageSize int = @pPageSize

	declare @offset int = (@nPageSize) * (@nPageNumber - 1)     
	;with
		tabla 
		as(
			select distinct
				ROW_NUMBER() over(order by a.id_agroqui) as Numero,
				a.id_agroqui as IdAgroquimico,
				a.nombre_agroqui as NombreAgroquimico,
				a.descripcion_agroqui as Descripcion,
				a.id_tipoAgroqui as IdTipoAgroquimico,
				ta.nombre_tipoAgroqui as NombreTipoAgroquimico
			from AGROQUIMICO a
				INNER JOIN TIPO_AGROQUIMICO ta ON a.id_tipoAgroqui = ta.id_tipoAgroqui
			where (ISNULL(@nNombre,'') = '' or a.nombre_agroqui LIKE '%'+@nNombre+'%')
				AND (a.id_tipoAgroqui = @nIdTipoAgroquimico OR @nIdTipoAgroquimico IS NULL)
				and a.estado_agrpqui = 1 and id_usu = @pIdUsuario
		),
		totalFilas AS
		(
			SELECT
				COUNT(1) AS TotalRows
			FROM tabla
		)

	select 
		Numero, 
		IdAgroquimico,
		NombreAgroquimico,
		t.TotalRows,
		Descripcion,
		IdTipoAgroquimico,
		NombreTipoAgroquimico
	from tabla, totalFilas as t
	order by IdAgroquimico asc
	offset @offset rows
	fetch next @nPageSize rows only
end
