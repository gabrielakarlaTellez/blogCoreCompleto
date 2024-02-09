using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogCore.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ProcedimientospGetCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedimiento = @"create procedure spGetCategorias1
                as begin select * from Categoria end";

            migrationBuilder.Sql(procedimiento);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedimiento = @"drop procedure spGetCategorias1
                as begin select * from Categoria end";

            migrationBuilder.Sql(procedimiento);
        }
    }
}
