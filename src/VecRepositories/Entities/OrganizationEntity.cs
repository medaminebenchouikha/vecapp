using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using src.VecRepositories.Abstractions;
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace src.VecRepositories.Entities
{
    [Table(name: DbConstants.OrganizationTableName)]
    public class OrganizationEntity : IEntity
    {
        [Key]
        public int OrganizationId { get; set; }

        [Required]
        [StringLength(200)]
        public string OrganizationName { get; set; }

        [Required]
        [StringLength(20)]
        public string OrganizationPhone { get; set; }

        [StringLength(500)]
        public string OrganizationAddress1 { get; set; }


        internal static void CreateMe(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: DbConstants.OrganizationTableName,
                columns: table => new
                {
                    OrganizationId = table.Column<int>(nullable: false),
                    OrganizationName = table.Column<string>(nullable: false, maxLength: 200),
                    OrganizationPhone = table.Column<string>(nullable: false, maxLength: 20),
                    OrganizationAddress = table.Column<string>(nullable: true, maxLength: 500)
                },
                constraints: table =>
                {
                    table.PrimaryKey($"PK_{DbConstants.OrganizationTableName}", x => x.OrganizationId);
                });
        }

    }
}