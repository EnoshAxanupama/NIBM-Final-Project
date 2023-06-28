using BixbyShop_LK.Models.Order;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace BixbyShop_LK.Services
{
    public class OrderService
    {
        private readonly IMongoCollection<Order> orderCollection;

        public OrderService()
        {
            var client = new MongoClient("mongodb://admin:p%40ssw0rd@localhost:27017/?authMechanism=SCRAM-SHA-256");
            var database = client.GetDatabase("BixbyShop_LK");
            orderCollection = database.GetCollection<Order>("Orders");
        }

        public List<Order> GetAllOrders()
        {
            return orderCollection.Find(_ => true).ToList();
        }

        public Order GetOrderById(ObjectId orderId)
        {
            return orderCollection.Find(order => order.Id == orderId).FirstOrDefault();
        }

        public void CreateOrder(Order order)
        {
            orderCollection.InsertOne(order);
        }

        public void UpdateOrder(ObjectId orderId, Order updatedOrder)
        {
            orderCollection.ReplaceOne(order => order.Id == orderId, updatedOrder);
        }

        public void DeleteOrder(ObjectId orderId)
        {
            orderCollection.DeleteOne(order => order.Id == orderId);
        }
    }
}
