using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace BixbyShop_LK.Models.Item.Services
{
    public class ShopItemService
    {
        private readonly IMongoCollection<ShopItem> shopItemCollection;

        public ShopItemService(IMongoDatabase database)
        {
            shopItemCollection = database.GetCollection<ShopItem>("shopItems");
        }

        public List<ShopItem> GetAllShopItems()
        {
            return shopItemCollection.Find(_ => true).ToList();
        }

        public ShopItem GetShopItemById(string shopItemId)
        {
            var objectId = new ObjectId(shopItemId);
            return shopItemCollection.Find(shopItem => shopItem.Id == objectId).FirstOrDefault();
        }

        public void CreateShopItem(ShopItem shopItem)
        {
            shopItemCollection.InsertOne(shopItem);
        }

        public void UpdateShopItem(string shopItemId, ShopItem updatedShopItem)
        {
            var objectId = new ObjectId(shopItemId);
            shopItemCollection.ReplaceOne(shopItem => shopItem.Id == objectId, updatedShopItem);
        }

        public void DeleteShopItem(string shopItemId)
        {
            var objectId = new ObjectId(shopItemId);
            shopItemCollection.DeleteOne(shopItem => shopItem.Id == objectId);
        }
    }
}
