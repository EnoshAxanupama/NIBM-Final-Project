using MongoDB.Bson;
using MongoDB.Driver;

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

        public CartAndOrder GetCartAndOrderById(ObjectId cartAndOrderId)
        {
            return cartAndOrderCollection.Find(cartAndOrder => cartAndOrder.Id == cartAndOrderId).FirstOrDefault();
        }

        public void CreateCartAndOrder(CartAndOrder cartAndOrder)
        {
            cartAndOrderCollection.InsertOne(cartAndOrder);
        }

        public void UpdateCartAndOrder(ObjectId cartAndOrderId, CartAndOrder updatedCartAndOrder)
        {
            cartAndOrderCollection.ReplaceOne(cartAndOrder => cartAndOrder.Id == cartAndOrderId, updatedCartAndOrder);
        }

        public void DeleteCartAndOrder(ObjectId cartAndOrderId)
        {
            cartAndOrderCollection.DeleteOne(cartAndOrder => cartAndOrder.Id == cartAndOrderId);
        }
    }
}
