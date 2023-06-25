using BixbyShop_LK.Config.DI;
using BixbyShop_LK.Models.Item;

namespace BixbyShop_LK.Services
{
    [Component]
    public class ShopItemService
    {
        private readonly AppDbContext _dbContext;

        public ShopItemService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ShopItem> GetAllShopItems()
        {
            return _dbContext.ShopItems.ToList();
        }

        public ShopItem GetShopItemById(long id)
        {
            return _dbContext.ShopItems.FirstOrDefault(si => si.Id == id);
        }

        public void CreateShopItem(ShopItem shopItem)
        {
            _dbContext.ShopItems.Add(shopItem);
            _dbContext.SaveChanges();
        }

        public void UpdateShopItem(ShopItem shopItem)
        {
            _dbContext.ShopItems.Update(shopItem);
            _dbContext.SaveChanges();
        }

        public void DeleteShopItem(ShopItem shopItem)
        {
            _dbContext.ShopItems.Remove(shopItem);
            _dbContext.SaveChanges();
        }
    }
}
