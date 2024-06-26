/****** Object:  StoredProcedure [dbo].[sp_ObtenerListaPaginaCampaniasSocidad]    Script Date: 25/03/2024 02:14:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[sp_ObtenerListaPaginaCampaniasSocidad] (
	@pIdSociedad int,
	@pNombre varchar(100),
	@pPageNumber int,
	@pPageSize int
)
as
begin
	declare @nNombre varchar(100) = @pNombre 
	declare @nIdSociedad int =  @pIdSociedad
	declare @nPageNumber int = @pPageNumber
	declare @nPageSize int = @pPageSize

	declare @offset int = (@nPageSize) * (@nPageNumber - 1)    
	
	;with
		tabla
		as (
			select distinct	
				ROW_NUMBER() over(order by ca.id_camp) as Numero,
				ca.id_camp as IdCampania,
				ca.nombre_camp as Nombre, 
				ca.nombreTerreno_camp as Terreno, 
				FORMAT(ca.fechaInicio_camp, 'dd/MM/yyyy')as Inicio,
				FORMAT(ca.fechaFin_camp, 'dd/MM/yyyy')as Fin,
				cu.nombre_culti as Cultivo,
				ca.areaSembrar_camp as AreaSembrar,
				dt.descripcionLarga as Unidad,
				ca.estado_camp as Estado,
				ca.estado_proceso_camp AS EstadoProceso,
				CASE WHEN ca.estado_proceso_camp = 'P' THEN 'En proceso'
					WHEN ca.estado_proceso_camp = 'R'	THEN 'Reabierta'
					WHEN ca.estado_proceso_camp = 'T'	THEN 'Terminada'
					WHEN ca.estado_proceso_camp = 'E'	THEN 'Eliminada'
					END AS EstadoDescripcionProceso
			from CAMPANIA as ca with(nolock)
			left join CULTIVO as cu on cu.id_culti = ca.id_culti
			left join DATO_COMUN as dt on dt.id_datoComun = ca.unidadTerrenoDatoComun_camp
			where (ISNULL(@nNombre,'') = '' or ca.nombre_camp LIKE '%'+@nNombre+'%') 
			and ca.id_soc = @nIdSociedad and estado_camp = 1
		),
		TotalRows AS
		(
			SELECT
				COUNT(1) AS TotalRows
			FROM tabla
		)
		
		select 
			Numero, 
			t.TotalRows, 
			IdCampania, 
			Nombre, 
			Terreno, 
			Inicio, 
			Fin, 
			Cultivo, 
			Estado,
			AreaSembrar,
			Unidad,
			EstadoProceso,
			EstadoDescripcionProceso
		from tabla, TotalRows as t
		order by IdCampania asc
		offset @offset rows
		fetch next @nPageSize rows only
end