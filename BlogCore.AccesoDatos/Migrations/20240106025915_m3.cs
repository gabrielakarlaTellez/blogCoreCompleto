using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogCore.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articulos_Categoria_CategoriaId",
                table: "articulos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_articulos",
                table: "articulos");

            migrationBuilder.RenameTable(
                name: "articulos",
                newName: "Articulo");

            migrationBuilder.RenameIndex(
                name: "IX_articulos_CategoriaId",
                table: "Articulo",
                newName: "IX_Articulo_CategoriaId");

            migrationBuilder.AlterColumn<string>(
                name: "UrlImagen",
                table: "Articulo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FechaCreacion",
                table: "Articulo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articulo",
                table: "Articulo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Categoria_CategoriaId",
                table: "Articulo",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Categoria_CategoriaId",
                table: "Articulo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articulo",
                table: "Articulo");

            migrationBuilder.RenameTable(
                name: "Articulo",
                newName: "articulos");

            migrationBuilder.RenameIndex(
                name: "IX_Articulo_CategoriaId",
                table: "articulos",
                newName: "IX_articulos_CategoriaId");

            migrationBuilder.AlterColumn<string>(
                name: "UrlImagen",
                table: "articulos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FechaCreacion",
                table: "articulos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_articulos",
                table: "articulos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_articulos_Categoria_CategoriaId",
                table: "articulos",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
