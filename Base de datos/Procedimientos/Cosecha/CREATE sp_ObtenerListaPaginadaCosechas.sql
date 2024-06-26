IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_ObtenerListaPaginadaCosechas')
	DROP PROCEDURE sp_ObtenerListaPaginadaCosechas
GO

CREATE PROCEDURE [dbo].[sp_ObtenerListaPaginadaCosechas] (
	@pPageNumber int,
	@pPageSize int,
	@pIdCampania int,
	@pFechaCosecha datetime = null
)
as
begin
	declare @nPageNumber int = @pPageNumber
	declare @nPageSize int = @pPageSize
	declare @nIdCampania int = @pIdCampania
	declare @nFechaCosecha datetime = @pFechaCosecha

	declare @offset int = (@nPageSize) * (@nPageNumber - 1)     
	;with
		tabla
		as(
			select
				ROW_NUMBER() over(order by id_cose) as Numero,
				id_cose as IdCosecha,
				FORMAT(fecha_cose, 'dd/MM/yyyy') as Fecha, 
				descripcion_cose as Descripcion 
			from COSECHA with(nolock)
			where id_camp = @nIdCampania 
				and (fecha_cose = @nFechaCosecha OR @nFechaCosecha IS NULL)
				and estado_cose = 1
		),
		totalFilas AS
		(
			SELECT
				COUNT(1) AS TotalRows
			FROM tabla
		)

	select 
		Numero, 
		t.TotalRows,
		IdCosecha,
		Fecha,
		Descripcion,
		t.TotalRows
	from tabla, totalFilas as t
	order by IdCosecha asc
	offset @offset rows
	fetch next @nPageSize rows only

end