USE agro_sistema_bd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_ObtenerListaPaginadaAbono')
	DROP PROCEDURE sp_ObtenerListaPaginadaAbono
GO

CREATE PROCEDURE sp_ObtenerListaPaginadaAbono(
	@pNombre  varchar(100) = null, 
	@pIdUsuario int,
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
				ROW_NUMBER() over(order by id_abono) as Numero,
				id_abono as IdAbono,
				nombre_abono as NombreAbono,
				descripcion_abono as Descripcion		
			from ABONO
			where (ISNULL(@nNombre,'') = '' or nombre_abono LIKE '%'+@nNombre+'%') 
					and estado_abono = 1 and id_usu = @pIdUsuario
		),
		totalFilas AS
		(
			SELECT
				COUNT(1) AS TotalRows
			FROM tabla
		)

	select 
		Numero, 
		IdAbono,
		NombreAbono,
		t.TotalRows,
		Descripcion
	from tabla, totalFilas as t
	order by IdAbono asc
	offset @offset rows
	fetch next @nPageSize rows only
end
