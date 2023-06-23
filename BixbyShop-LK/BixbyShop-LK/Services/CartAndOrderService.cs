using BixbyShop_LK.Models.Order;

namespace BixbyShop_LK.Services
{
    public class CartAndOrderService
    {
        private readonly AppDbContext _dbContext;

        public CartAndOrderService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CartAndOrder> GetAllCartAndOrders()
        {
            return _dbContext.CartAndOrders.ToList();
        }

        public CartAndOrder GetCartAndOrderById(long id)
        {
            return _dbContext.CartAndOrders.FirstOrDefault(co => co.Id == id);
        }

        public void CreateCartAndOrder(CartAndOrder cartAndOrder)
        {
            _dbContext.CartAndOrders.Add(cartAndOrder);
            _dbContext.SaveChanges();
        }

        public void UpdateCartAndOrder(CartAndOrder cartAndOrder)
        {
            _dbContext.CartAndOrders.Update(cartAndOrder);
            _dbContext.SaveChanges();
        }

        public void DeleteCartAndOrder(CartAndOrder cartAndOrder)
        {
            _dbContext.CartAndOrders.Remove(cartAndOrder);
            _dbContext.SaveChanges();
        }
    }
}
