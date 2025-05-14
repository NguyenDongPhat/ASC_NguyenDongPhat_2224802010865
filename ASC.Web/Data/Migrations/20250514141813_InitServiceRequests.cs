using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASC.WEB.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitServiceRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "ServiceRequests",
               columns: table => new
               {
                   PartitionKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                   RowKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                   VehicleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   RequestedServices = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                   CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                   ServiceEngineer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                   UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                   IsDeleted = table.Column<bool>(type: "bit", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_ServiceRequests", x => new { x.PartitionKey, x.RowKey });
               });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceRequests");
        }
    }
}
