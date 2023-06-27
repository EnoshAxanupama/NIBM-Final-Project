using BixbyShop_LK.Models.Comments;
using BixbyShop_LK.Services;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace BixbyShop_LK.Models.Order.Services
{
    public class CartAndOrderService
    {
        private readonly IMongoCollection<CartAndOrder> cartAndOrderCollection;

        public CartAndOrderService()
        {
            var client = new MongoClient("mongodb://admin:p%40ssw0rd@localhost:27017/?authMechanism=SCRAM-SHA-256");
            var database = client.GetDatabase("BixbyShop_LK");
            cartAndOrderCollection = database.GetCollection<CartAndOrder>("CartAndOrders");
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
