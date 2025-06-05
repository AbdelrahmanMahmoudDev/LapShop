using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LapShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class added_item_view : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW [VwItems] AS
SELECT dbo.Items.ItemName, dbo.Items.SalesPrice, dbo.Items.PurchasePrice, dbo.Items.ImageName, dbo.Items.Gpu, dbo.Items.HardDisk, dbo.Items.Processor, dbo.Items.RamSize, dbo.Items.ScreenResolution, dbo.Items.ScreenSize, 
                  dbo.Items.Weight, dbo.Categories.CategoryName, dbo.ItemTypes.ItemTypeName, dbo.OperatingSystems.OperatingSystemName
FROM     dbo.Items INNER JOIN
                  dbo.Categories ON dbo.Items.CategoryId = dbo.Categories.CategoryId INNER JOIN
                  dbo.ItemTypes ON dbo.Items.ItemTypeId = dbo.ItemTypes.ItemTypeId INNER JOIN
                  dbo.OperatingSystems ON dbo.Items.OperatingSystemId = dbo.OperatingSystems.OperatingSystemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
