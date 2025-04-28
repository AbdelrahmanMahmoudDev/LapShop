using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LapShop.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CategoryBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShowInHomePage = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    ItemTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.ItemTypeId);
                });

            migrationBuilder.CreateTable(
                name: "OperatingSystems",
                columns: table => new
                {
                    OperatingSystemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatingSystemName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShowInHomePage = table.Column<bool>(type: "bit", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingSystems", x => x.OperatingSystemId);
                });

            migrationBuilder.CreateTable(
                name: "BusinessInfo",
                columns: table => new
                {
                    BusinessInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessCardNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OfficePhone = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessInfo", x => x.BusinessInfoId);
                    table.ForeignKey(
                        name: "FK_BusinessInfo_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CashTransactions",
                columns: table => new
                {
                    CashTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    CashValue = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashTransactions", x => x.CashTransactionId);
                    table.ForeignKey(
                        name: "FK_CashTransactions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SalesPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    CreatedBy = table.Column<DateTime>(type: "DateTime", nullable: false),
                    CurrentState = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<DateTime>(type: "DateTime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Gpu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    HardDisk = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Processor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RamSize = table.Column<int>(type: "int", nullable: true),
                    ScreenResolution = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ScreenSize = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ItemTypeId = table.Column<int>(type: "int", nullable: true),
                    OperatingSystemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "ItemTypeId");
                    table.ForeignKey(
                        name: "FK_Items_OperatingSystems_OperatingSystemId",
                        column: x => x.OperatingSystemId,
                        principalTable: "OperatingSystems",
                        principalColumn: "OperatingSystemId");
                });

            migrationBuilder.CreateTable(
                name: "CustomerxItems",
                columns: table => new
                {
                    CustomerxItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerxItems", x => x.CustomerxItemId);
                    table.ForeignKey(
                        name: "FK_CustomerxItems_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerxItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemDiscounts",
                columns: table => new
                {
                    ItemDiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountPercent = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDiscounts", x => x.ItemDiscountId);
                    table.ForeignKey(
                        name: "FK_ItemDiscounts_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemImages",
                columns: table => new
                {
                    ItemImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemImageName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemImages", x => x.ItemImageId);
                    table.ForeignKey(
                        name: "FK_ItemImages_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessInfo_CustomerId",
                table: "BusinessInfo",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CashTransactions_CustomerId",
                table: "CashTransactions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerxItems_CustomerId",
                table: "CustomerxItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerxItems_ItemId",
                table: "CustomerxItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDiscounts_ItemId",
                table: "ItemDiscounts",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemImages_ItemId",
                table: "ItemImages",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeId",
                table: "Items",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OperatingSystemId",
                table: "Items",
                column: "OperatingSystemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessInfo");

            migrationBuilder.DropTable(
                name: "CashTransactions");

            migrationBuilder.DropTable(
                name: "CustomerxItems");

            migrationBuilder.DropTable(
                name: "ItemDiscounts");

            migrationBuilder.DropTable(
                name: "ItemImages");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "OperatingSystems");
        }
    }
}
