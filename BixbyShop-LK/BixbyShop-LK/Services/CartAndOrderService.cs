using BixbyShop_LK.Services;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace BixbyShop_LK.Models.Order.Services
{
    public class CartAndOrderService
    {
        private readonly IMongoCollection<CartAndOrder> cartAndOrderCollection;

        public CartAndOrderService(MongoDbContext mongoDbContext)
        {
            cartAndOrderCollection = mongoDbContext.CartAndOrders;
        }

        public List<CartAndOrder> GetAllCartAndOrders()
        {
            return cartAndOrderCollection.Find(_ => true).ToList();
        }

        public CartAndOrder GetCartAndOrderById(string cartAndOrderId)
        {
            var objectId = new ObjectId(cartAndOrderId);
            return cartAndOrderCollection.Find(cartAndOrder => cartAndOrder.Id == objectId).FirstOrDefault();
        }

        public void CreateCartAndOrder(CartAndOrder cartAndOrder)
        {
            cartAndOrderCollection.InsertOne(cartAndOrder);
        }

        public void UpdateCartAndOrder(string cartAndOrderId, CartAndOrder updatedCartAndOrder)
        {
            var objectId = new ObjectId(cartAndOrderId);
            cartAndOrderCollection.ReplaceOne(cartAndOrder => cartAndOrder.Id == objectId, updatedCartAndOrder);
        }

        public void DeleteCartAndOrder(string cartAndOrderId)
        {
            var objectId = new ObjectId(cartAndOrderId);
            cartAndOrderCollection.DeleteOne(cartAndOrder => cartAndOrder.Id == objectId);
        }
    }
}
