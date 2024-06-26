IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_ObtenerListaPaginadaSociedades')
	DROP PROCEDURE sp_ObtenerListaPaginadaSociedades
GO

CREATE procedure [dbo].[sp_ObtenerListaPaginadaSociedades] (
	@pNombre  varchar(100) = null, 
	@pPageNumber int,
	@pPageSize int,
	@pIdUsuario int
)
as
begin
	declare @nNombre varchar(100) = @pNombre 
	declare @nPageNumber int = @pPageNumber
	declare @nPageSize int = @pPageSize
	declare @nIdUsuario int = @pIdUsuario

	declare @offset int = (@nPageSize) * (@nPageNumber - 1)     
	;with
		tabla 
		as(
			select distinct 
				ROW_NUMBER() over(order by s.id_soc) as Numero,
				s.id_soc as IdSociedad, 
				s.nombre_soc as Nombre,
				us.esAdministrador_usuSoc as EsAdministrador
			from USUARIO_SOCIEDAD as us with(nolock)
			left join SOCIEDAD as s on us.id_soc = s.id_soc
			where (ISNULL(@nNombre,'') = '' or nombre_soc LIKE '%'+@nNombre+'%') 
					and id_usu = @nIdUsuario and estado_soc = 1
		),
		totalFilas AS
		(
			SELECT
				COUNT(1) AS TotalRows
			FROM tabla
		)

	select 
		Numero, 
		IdSociedad,
		Nombre,
		t.TotalRows,
		EsAdministrador
	from tabla, totalFilas as t
	order by IdSociedad asc
	offset @offset rows
	fetch next @nPageSize rows only
end
