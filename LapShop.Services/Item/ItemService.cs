using LapShop.Data;
using LapShop.Domains;
using LapShop.Domains.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LapShop.Services.Item
{
    public class ItemService : IItemService
    {
        private readonly MainContext _MainContext;

        public ItemService(MainContext mainContext)
        {
            _MainContext = mainContext;
        }

        public VwItemsVM GetSingle(int? id)
        {
            if (id.HasValue)
            {
                var item = _MainContext.Items
                .Include(i => i.Category)
                .Include(i => i.ItemType)
                .Include(i => i.OperatingSystem)
                .AsQueryable()
                .Where(i => i.ItemId == id)
                .Select(i => new VwItemsVM
                {

                    ItemId = i.ItemId,
                    ItemName = i.ItemName,
                    SalesPrice = i.SalesPrice,
                    PurchasePrice = i.PurchasePrice,
                    ImageName = i.ImageName ?? string.Empty,
                    Gpu = i.Gpu ?? string.Empty,
                    HardDisk = i.HardDisk ?? string.Empty,
                    Processor = i.Processor ?? string.Empty,
                    RamSize = i.RamSize ?? 0,
                    ScreenResolution = i.ScreenResolution ?? string.Empty,
                    ScreenSize = i.ScreenSize ?? string.Empty,
                    Weight = i.Weight ?? string.Empty,
                    CategoryId = i.CategoryId,
                    Categories = _MainContext.Categories.ToList(),
                    ItemTypeId = i.ItemTypeId ?? 0,
                    ItemTypes = _MainContext.ItemTypes.ToList(),
                    OperatingSystemId = i.OperatingSystemId ?? 0,
                    OperatingSystems = _MainContext.OperatingSystems.ToList()
                })
                .FirstOrDefault();
                return item ?? throw new Exception($"Passed invalid id: {id}");
            }

            return new VwItemsVM()
            {
                Categories = _MainContext.Categories.ToList(),
                ItemTypes = _MainContext.ItemTypes.ToList(),
                OperatingSystems = _MainContext.OperatingSystems.ToList()
            };
        }
        public IQueryable<VwItemsVM> PrepareDashboard(string searchValue)
        {
            var result = _MainContext.Items
                         .Include(i => i.Category)
                         .Include(i => i.ItemType)
                         .Include(i => i.OperatingSystem)
                         .AsQueryable()
                         .Where(i => i.ItemName.Contains(searchValue) || searchValue == null || searchValue == "")
                         .Select(i => new VwItemsVM()
                         {
                             ItemId = i.ItemId,
                             ItemName = i.ItemName,
                             SalesPrice = i.SalesPrice,
                             PurchasePrice = i.PurchasePrice,
                             ImageName = i.ImageName ?? string.Empty,
                             Gpu = i.Gpu ?? string.Empty,
                             HardDisk = i.HardDisk ?? string.Empty,
                             Processor = i.Processor ?? string.Empty,
                             RamSize = i.RamSize ?? 0,
                             ScreenResolution = i.ScreenResolution ?? string.Empty,
                             ScreenSize = i.ScreenSize ?? string.Empty,
                             Weight = i.Weight ?? string.Empty,
                             CategoryId = i.CategoryId,
                             CategoryName = i.Category.CategoryName ?? string.Empty,
                             Categories = _MainContext.Categories.ToList(),
                             ItemTypeId = i.ItemTypeId ?? 0,
                             ItemTypeName = i.ItemType.ItemTypeName ?? string.Empty,
                             ItemTypes = _MainContext.ItemTypes.ToList(),
                             OperatingSystemId = i.OperatingSystemId ?? 0,
                             OperatingSystemName = i.OperatingSystem.OperatingSystemName ?? string.Empty,
                             OperatingSystems = _MainContext.OperatingSystems.ToList(),
                         });

            return result;
        }
        private async Task SaveNew(VwItemsVM itemVM)
        {
            Domains.Item newItem = new Domains.Item
            {
                ItemName = itemVM.ItemName,
                SalesPrice = itemVM.SalesPrice,
                PurchasePrice = itemVM.PurchasePrice,
                Gpu = itemVM.Gpu,
                HardDisk = itemVM.HardDisk,
                Processor = itemVM.Processor,
                RamSize = itemVM.RamSize,
                ScreenResolution = itemVM.ScreenResolution,
                ScreenSize = itemVM.ScreenSize,
                Weight = itemVM.Weight,
                CategoryId = itemVM.CategoryId,
                ItemTypeId = itemVM.ItemTypeId,
                OperatingSystemId = itemVM.OperatingSystemId
            };

            if (itemVM.File != null)
            {
                try
                {
                    newItem.ImageName = await Utilities.FileUtility.SaveFile(itemVM.File, "Images\\Items", [".jpg", ".jpeg", ".png"]);
                }
                catch (InvalidOperationException ex)
                {
                    throw new Exception($"Error while saving file: {ex.Message}");
                }
            }
            else
            {
                newItem.ImageName = string.Empty;
            }

            try
            {
                newItem.CreatedDate = DateTime.Now;
                newItem.CreatedBy = "Admin";
                newItem.CurrentState = true;
                await _MainContext.Items.AddAsync(newItem);
                await _MainContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while setting CreatedDate or CreatedBy: {ex.Message}");
            }
        }
        private async Task SaveUpdate(VwItemsVM itemVM)
        {
            var existingItem = _MainContext.Items.Find(itemVM.ItemId);
            if (existingItem == null) throw new InvalidOperationException("Cannot update non-existant item entity");

            existingItem.ItemName = itemVM.ItemName;
            existingItem.SalesPrice = itemVM.SalesPrice;
            existingItem.PurchasePrice = itemVM.PurchasePrice;
            existingItem.Gpu = itemVM.Gpu;
            existingItem.HardDisk = itemVM.HardDisk;
            existingItem.Processor = itemVM.Processor;
            existingItem.RamSize = itemVM.RamSize;
            existingItem.ScreenResolution = itemVM.ScreenResolution;
            existingItem.ScreenSize = itemVM.ScreenSize;
            existingItem.Weight = itemVM.Weight;
            existingItem.CategoryId = itemVM.CategoryId;
            existingItem.ItemTypeId = itemVM.ItemTypeId;
            existingItem.OperatingSystemId = itemVM.OperatingSystemId;

            if (itemVM.File != null)
            {
                try
                {
                    existingItem.ImageName = await Utilities.FileUtility.SaveFile(itemVM.File, "Images\\Items", [".jpg", ".jpeg", ".png"]);
                }
                catch (InvalidOperationException ex)
                {
                    throw new Exception($"Error while saving file: {ex.Message}");
                }
            }

            try
            {
                existingItem.UpdatedDate = DateTime.Now;
                existingItem.UpdatedBy = DateTime.Now;
                _MainContext.Items.Update(existingItem);
                await _MainContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while setting UpdatedDate or UpdatedBy: {ex.Message}");
            }
        }
        public async Task Save(VwItemsVM itemVM)
        {
            if (itemVM.ItemId == 0)
            {
                await SaveNew(itemVM);
            }
            else
            {
                await SaveUpdate(itemVM);
            }
        }
        public async Task Delete(int id)
        {
            var item = await _MainContext.Items.FindAsync(id);
            if (item == null) throw new InvalidOperationException("Cannot delete non-existant item entity");
            if (!string.IsNullOrEmpty(item.ImageName))
            {
                try
                {
                    Utilities.FileUtility.DeleteFile(item.ImageName);
                }
                catch (InvalidOperationException ex)
                {
                    throw new Exception($"Error while deleting file: {ex.Message}");
                }
            }
            _MainContext.Items.Remove(item);
            await _MainContext.SaveChangesAsync();
        }
        public HomepageVM PrepareHomepage(HomepageVM homepageVM = null)
        {
            if(homepageVM == null)
            {
                homepageVM = new HomepageVM();
            }

            homepageVM.TopCollections = _MainContext.VwItems
                .OrderByDescending(i => i.SalesPrice)
                .Take(5)
                .ToList();
            homepageVM.NewProducts = _MainContext.VwItems
                .OrderByDescending(i => i.SalesPrice)
                .Take(5)
                .ToList();
            homepageVM.FeaturedProducts = _MainContext.VwItems
                .OrderByDescending(i => i.SalesPrice)
                .Take(5)
                .ToList();
            homepageVM.BestSellers = _MainContext.VwItems
                .OrderByDescending(i => i.SalesPrice)
                .Take(5)
                .ToList();

            return homepageVM;
        }
    }
}
