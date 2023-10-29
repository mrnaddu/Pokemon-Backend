using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokemon_WebApi.Migrations
{
    public partial class nlkj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PokemonImageUrl",
                table: "Pokemons",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PokemonImageUrl",
                table: "Pokemons");
        }
    }
}
