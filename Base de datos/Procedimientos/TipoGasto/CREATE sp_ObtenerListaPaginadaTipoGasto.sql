USE agro_sistema_bd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_ObtenerListaPaginadaTipoGasto')
	DROP PROCEDURE sp_ObtenerListaPaginadaTipoGasto
GO

CREATE PROCEDURE sp_ObtenerListaPaginadaTipoGasto(
	@pNombre  varchar(100) = null, 
	@pPageNumber int,
	@pPageSize int
)
as
begin
	declare @nNombre varchar(100) = @pNombre 
	declare @nPageNumber int = @pPageNumber
	declare @nPageSize int = @pPageSize

	declare @offset int = (@nPageSize) * (@nPageNumber - 1)     
	;with
		tabla 
		as(
			select distinct
				ROW_NUMBER() over(order by id_tipoGasto) as Numero,
				id_tipoGasto as IdTipoGasto,
				nombre_tipoGasto as NombreTipoGasto,
				descripcion_tipoGasto as Descripcion		
			from TIPO_GASTO
			where (ISNULL(@nNombre,'') = '' or nombre_tipoGasto LIKE '%'+@nNombre+'%') 
					and estado_tipoGasto = 1
		),
		totalFilas AS
		(
			SELECT
				COUNT(1) AS TotalRows
			FROM tabla
		)

	select 
		Numero, 
		IdTipoGasto,
		NombreTipoGasto,
		t.TotalRows,
		Descripcion
	from tabla, totalFilas as t
	order by IdTipoGasto asc
	offset @offset rows
	fetch next @nPageSize rows only
end
