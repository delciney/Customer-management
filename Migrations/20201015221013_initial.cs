using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CustomerManagement.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CNPJ = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    EnderecoBairro = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    EnderecoCep = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true),
                    EnderecoCidade = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    EnderecoEstado = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    EnderecoLogradouro = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    EnderecoNro = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    NomeContato = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    NomeFantasia = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    RazaoSocial = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
