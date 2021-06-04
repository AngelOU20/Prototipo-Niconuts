using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Prototipo_Niconuts.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_t_pre_pedido",
                table: "t_pre_pedido");

            migrationBuilder.RenameTable(
                name: "t_pre_pedido",
                newName: "DataPrePedido");

            migrationBuilder.RenameColumn(
                name: "cantidad",
                table: "DataPrePedido",
                newName: "Cantidad");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "DataPrePedido",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "productoid",
                table: "DataPrePedido",
                newName: "Producto");

            migrationBuilder.RenameColumn(
                name: "precio",
                table: "DataPrePedido",
                newName: "PrecioUnit");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "DataPrePedido",
                newName: "Correo");

            migrationBuilder.AlterColumn<string>(
                name: "telefono",
                table: "t_contacto",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "t_contacto",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "mensaje",
                table: "t_contacto",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "t_contacto",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "apellido",
                table: "t_contacto",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Producto",
                table: "DataPrePedido",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "DataPrePedido",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "DataPrePedido",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataPrePedido",
                table: "DataPrePedido",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "proforma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserID = table.Column<string>(type: "text", nullable: true),
                    Productoid = table.Column<int>(type: "integer", nullable: true),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    Precio = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proforma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_proforma_t_producto_Productoid",
                        column: x => x.Productoid,
                        principalTable: "t_producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_reclamaciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    apellido = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    telefono = table.Column<string>(type: "text", nullable: false),
                    mensaje = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_reclamaciones", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_proforma_Productoid",
                table: "proforma",
                column: "Productoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "proforma");

            migrationBuilder.DropTable(
                name: "t_reclamaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DataPrePedido",
                table: "DataPrePedido");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "DataPrePedido");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "DataPrePedido");

            migrationBuilder.RenameTable(
                name: "DataPrePedido",
                newName: "t_pre_pedido");

            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "t_pre_pedido",
                newName: "cantidad");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "t_pre_pedido",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Producto",
                table: "t_pre_pedido",
                newName: "productoid");

            migrationBuilder.RenameColumn(
                name: "PrecioUnit",
                table: "t_pre_pedido",
                newName: "precio");

            migrationBuilder.RenameColumn(
                name: "Correo",
                table: "t_pre_pedido",
                newName: "email");

            migrationBuilder.AlterColumn<string>(
                name: "telefono",
                table: "t_contacto",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "t_contacto",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "mensaje",
                table: "t_contacto",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "t_contacto",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "apellido",
                table: "t_contacto",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "productoid",
                table: "t_pre_pedido",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_pre_pedido",
                table: "t_pre_pedido",
                column: "id");
        }
    }
}
