using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using src.VecRepositories.Entities;

namespace src.VecRepositories.MigrationScripts
{
    [DbContext(typeof(VecDbContext))]
    [Migration("V202105111630_InitialCreate")]
    public class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            OrganizationEntity.CreateMe(migrationBuilder);
        }
    }
}