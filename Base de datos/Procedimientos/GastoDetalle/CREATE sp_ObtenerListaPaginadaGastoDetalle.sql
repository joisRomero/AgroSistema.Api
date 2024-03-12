IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_ObtenerListaPaginadaGastoDetalle')
	DROP PROCEDURE sp_ObtenerListaPaginadaGastoDetalle
GO

CREATE PROCEDURE sp_ObtenerListaPaginadaGastoDetalle(
	@pIdCampania int,
	@pNombreTipoGasto VARCHAR(100) = NULL,
	@pFechaGasto datetime = null,
	@pPageNumber int,
	@pPageSize int
)
as
begin

	IF OBJECT_ID('tempdb..#temp_TablaListaPaginadaGastoDetalle') IS NOT NULL
		DROP TABLE #temp_TablaListaPaginadaGastoDetalle

	declare @nIdCampania int = @pIdCampania 
	declare @nNombreTipoGasto VARCHAR(100) = @pNombreTipoGasto
	declare @nFechaGasto datetime = @pFechaGasto 	
	declare @nPageNumber int = @pPageNumber
	declare @nPageSize int = @pPageSize

	declare @offset int = (@nPageSize) * (@nPageNumber - 1)
	
	SELECT 
		gd.id_gastoDet as IdGastoDetalle,
		tg.id_tipoGasto as IdTipoGasto,
		tg.nombre_tipoGasto as NombreTipoGasto,
		gd.fecha_gastoDet as FechaGasto,
		gd.cantidad_gastoDet as Cantidad,
		gd.costoUnitario_gastoDet as CostoUnitario,
		gd.costoTotal_gastoDet as CostoTotal,
		gd.descripcion_gastoDet as Descripcion
	INTO #temp_TablaListaPaginadaGastoDetalle
	FROM GASTO_DETALLE gd
	INNER JOIN TIPO_GASTO tg ON gd.id_tipoGasto = tg.id_tipoGasto
	where ((tg.nombre_tipoGasto LIKE '%'+@nNombreTipoGasto+'%') OR ISNULL(@nNombreTipoGasto,'') = '')
			AND (gd.fecha_gastoDet = @nFechaGasto OR @nFechaGasto IS NULL)
			AND gd.id_camp = @nIdCampania
			AND gd.estado_gastoDet = 1
	order by gd.fecha_gastoDet desc

	;with
		tabla 
		as(
			select distinct
				ROW_NUMBER() over(order by IdGastoDetalle) as Numero,
				IdGastoDetalle,
				IdTipoGasto,
				NombreTipoGasto,
				FechaGasto,
				Cantidad,
				CostoUnitario,
				CostoTotal,
				Descripcion
			from #temp_TablaListaPaginadaGastoDetalle
		),
		totalFilas AS
		(
			SELECT
				COUNT(1) AS TotalRows
			FROM tabla
		)

	select 
		Numero,
		IdGastoDetalle,
		IdTipoGasto,
		NombreTipoGasto,
		FechaGasto,
		Cantidad,
		CostoUnitario,
		CostoTotal,
		t.TotalRows,
		Descripcion
	from tabla, totalFilas as t
	order by IdGastoDetalle asc
	offset @offset rows
	fetch next @nPageSize rows only
end
