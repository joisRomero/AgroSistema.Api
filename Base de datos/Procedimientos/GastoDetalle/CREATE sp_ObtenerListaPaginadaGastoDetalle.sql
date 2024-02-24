USE agro_sistema_bd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_ObtenerListaPaginadaGastoDetalle')
	DROP PROCEDURE sp_ObtenerListaPaginadaGastoDetalle
GO

CREATE PROCEDURE sp_ObtenerListaPaginadaGastoDetalle(
	@pIdCampania int,
	@pIdTipoGasto int = null,
	@pFechaGasto datetime = null,
	@pPageNumber int,
	@pPageSize int
)
as
begin
	declare @nIdCampania int = @pIdCampania 
	declare @nIdTipoGasto int = @pIdTipoGasto 
	declare @nFechaGasto datetime = @pFechaGasto 	
	declare @nPageNumber int = @pPageNumber
	declare @nPageSize int = @pPageSize

	declare @offset int = (@nPageSize) * (@nPageNumber - 1)     
	;with
		tabla 
		as(
			select distinct
				ROW_NUMBER() over(order by gd.id_gastoDet) as Numero,
				gd.id_gastoDet as IdGastoDetalle,
				tg.id_tipoGasto as IdTipoGasto,
				tg.nombre_tipoGasto as NombreTipoGasto,
				gd.fecha_gastoDet as FechaGasto,
				gd.cantidad_gastoDet as Cantidad,
				gd.costoUnitario_gastoDet as CostoUnitario,
				gd.costoTotal_gastoDet as CostoTotal,
				gd.descripcion_gastoDet as Descripcion
			from GASTO_DETALLE gd
				INNER JOIN TIPO_GASTO tg ON gd.id_tipoGasto = tg.id_tipoGasto
			where (tg.id_tipoGasto = @nIdTipoGasto OR @nIdTipoGasto IS NULL)
				AND (gd.fecha_gastoDet = @nFechaGasto OR @nFechaGasto IS NULL)
				AND gd.id_camp = @nIdCampania
				AND gd.estado_gastoDet = 1
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
