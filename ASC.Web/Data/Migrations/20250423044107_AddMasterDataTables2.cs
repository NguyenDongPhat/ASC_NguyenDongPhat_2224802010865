using ASC.Model.BaseTypes;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace ASC.WEB.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMasterDataTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterDataKeys",
                columns: table => new
                {
                    PartitionKey = table.Column<string>(maxLength: 450, nullable: false),
                    RowKey = table.Column<string>(maxLength: 450, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    // Các cột từ BaseEntity
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterDataKeys", x => new { x.PartitionKey, x.RowKey });
                });

            migrationBuilder.CreateTable(
                name: "MasterDataValues",
                columns: table => new
                {
                    PartitionKey = table.Column<string>(maxLength: 450, nullable: false),
                    RowKey = table.Column<string>(maxLength: 450, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    // Các cột từ IAuditTracker
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterDataValues", x => new { x.PartitionKey, x.RowKey });
                });

            // Thêm index nếu cần
            migrationBuilder.CreateIndex(
                name: "IX_MasterDataKeys_IsActive",
                table: "MasterDataKeys",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDataValues_IsActive",
                table: "MasterDataValues",
                column: "IsActive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterDataKeys");

            migrationBuilder.DropTable(
                name: "MasterDataValues");
        }
    }
}