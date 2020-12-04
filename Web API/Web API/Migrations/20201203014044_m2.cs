using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_API.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apuestas_Usuarios_UsuarioId",
                table: "Apuestas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_Usuarios_UsuarioId",
                table: "Cuentas");

            migrationBuilder.DropColumn(
                name: "RefCuentaBancaria",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "RefEvento",
                table: "Mercados");

            migrationBuilder.DropColumn(
                name: "RefMercado",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "RefEvento",
                table: "Apuestas");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Cuentas",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Apuestas",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "EventoId", "EquipoLocal", "EquipoVisitante", "Fecha" },
                values: new object[,]
                {
                    { 1, "Valencia", "Español", "2020/02/20" },
                    { 2, "Madrid", "Barcelona", "2020/03/30" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Apellidos", "Edad", "Nombre" },
                values: new object[,]
                {
                    { 1, "Salvador", 19, "Jesus" },
                    { 2, "Gonzalez", 20, "Pedro" }
                });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "ApuestaId", "Cuota", "DinieroApostado", "EventoId", "Fecha", "Mercado", "TipoApuesta", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1.8999999999999999, 100.0, 1, "2020/02/20", 1, "Over", 1 },
                    { 2, 1.8999999999999999, 50.0, 2, "2020/02/20", 2, "Under", 1 }
                });

            migrationBuilder.InsertData(
                table: "Cuentas",
                columns: new[] { "CuentaId", "NombreBanco", "Saldo", "UsuarioId" },
                values: new object[,]
                {
                    { 1, "Bankia", 500.0, 1 },
                    { 2, "Bankia", 500.0, 2 }
                });

            migrationBuilder.InsertData(
                table: "Mercados",
                columns: new[] { "MercadoId", "CuotaOver", "CuotaUnder", "DineroOver", "DineroUnder", "EventoId", "TipoMercado" },
                values: new object[,]
                {
                    { 1, 1.8999999999999999, 1.8999999999999999, 100.0, 100.0, 1, 1.5 },
                    { 2, 1.8999999999999999, 1.8999999999999999, 100.0, 100.0, 2, 2.5 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Apuestas_Usuarios_UsuarioId",
                table: "Apuestas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_Usuarios_UsuarioId",
                table: "Cuentas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apuestas_Usuarios_UsuarioId",
                table: "Apuestas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_Usuarios_UsuarioId",
                table: "Cuentas");

            migrationBuilder.DeleteData(
                table: "Apuestas",
                keyColumn: "ApuestaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apuestas",
                keyColumn: "ApuestaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cuentas",
                keyColumn: "CuentaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cuentas",
                keyColumn: "CuentaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mercados",
                keyColumn: "MercadoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mercados",
                keyColumn: "MercadoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Eventos",
                keyColumn: "EventoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Eventos",
                keyColumn: "EventoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Usuarios",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "RefCuentaBancaria",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RefEvento",
                table: "Mercados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RefMercado",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Cuentas",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Apuestas",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RefEvento",
                table: "Apuestas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Apuestas_Usuarios_UsuarioId",
                table: "Apuestas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_Usuarios_UsuarioId",
                table: "Cuentas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
