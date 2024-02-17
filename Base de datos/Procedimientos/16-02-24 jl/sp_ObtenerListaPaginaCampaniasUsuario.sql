IF EXISTS (SELECT * FROM sysobjects WHERE name='sp_ObtenerListaPaginaCampaniasUsuario') 
	BEGIN
		DROP PROCEDURE sp_ObtenerListaPaginaCampaniasUsuario
	END
GO
create procedure [dbo].[sp_ObtenerListaPaginaCampaniasUsuario] (
	@pIdUsuario int,
	@pNombre varchar(100),
	@pPageNumber int,
	@pPageSize int
)
as
begin
	declare @nNombre varchar(100) = @pNombre 
	declare @nIdUsuario int =  @pIdUsuario
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
				ca.estado_camp as Estado
			from CAMPANIA as ca with(nolock)
			left join CULTIVO as cu
			on cu.id_culti = ca.id_culti
			where (ISNULL(@nNombre,'') = '' or ca.nombre_camp LIKE '%'+@nNombre+'%') 
			and ca.id_usu = @nIdUsuario
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
			Estado
		from tabla, TotalRows as t
		order by IdCampania asc
		offset @offset rows
		fetch next @nPageSize rows only
end