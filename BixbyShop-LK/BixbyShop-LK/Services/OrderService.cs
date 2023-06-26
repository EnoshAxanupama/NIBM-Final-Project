using MongoDB.Bson;
using MongoDB.Driver;

namespace BixbyShop_LK.Models.Order.Services
{
    public class OrderService
    {
        private readonly IMongoCollection<Order> orderCollection;

        public OrderService(IMongoDatabase database)
        {
            orderCollection = database.GetCollection<Order>("orders");
        }

        public List<Order> GetAllOrders()
        {
            return orderCollection.Find(_ => true).ToList();
        }

        public Order GetOrderById(string orderId)
        {
            var objectId = new ObjectId(orderId);
            return orderCollection.Find(order => order.Id == objectId).FirstOrDefault();
        }

        public void CreateOrder(Order order)
        {
            orderCollection.InsertOne(order);
        }

        public void UpdateOrder(string orderId, Order updatedOrder)
        {
            var objectId = new ObjectId(orderId);
            orderCollection.ReplaceOne(order => order.Id == objectId, updatedOrder);
        }

        public void DeleteOrder(string orderId)
        {
            var objectId = new ObjectId(orderId);
            orderCollection.DeleteOne(order => order.Id == objectId);
        }
    }
}
