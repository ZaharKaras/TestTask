using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
	public class OrderService : IOrderService
	{
		private DbSet<Order> _orders;

		public OrderService(ApplicationDbContext context)
		{
			_orders = context.Set<Order>();
		}

		public async Task<Order> GetOrder()
		{
			return await _orders.OrderByDescending(o => o.Price * o.Quantity)
				.FirstOrDefaultAsync();
		}

		public async Task<List<Order>> GetOrders()
		{
			return await _orders.Where(o => o.Quantity > 10)
				.ToListAsync();
		}
	}
}
