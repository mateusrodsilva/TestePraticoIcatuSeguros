using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class adicionandoNovaEntidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("fd4fff01-44dd-41c6-b6d1-40a60edd820e"));

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Preco", "Situacao" },
                values: new object[] { new Guid("f16b1ccc-1197-4ccb-887b-ae9b521efaa6"), 1, "Descricao01", "Produto01", 100m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("f16b1ccc-1197-4ccb-887b-ae9b521efaa6"));

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Preco", "Situacao" },
                values: new object[] { new Guid("fd4fff01-44dd-41c6-b6d1-40a60edd820e"), 1, "Descricao01", "Produto01", 100m, 1 });
        }
    }
}
