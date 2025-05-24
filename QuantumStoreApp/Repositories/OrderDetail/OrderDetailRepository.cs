using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace QuantumStore
{
    

    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly AppDbContext _context;

        public OrderDetailRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            return _context.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Product)
                .ToList();
        }

        public OrderDetail GetOrderDetailById(int id)
        {
            return _context.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Product)
                .FirstOrDefault(od => od.Id == id);
        }

        public bool AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                _context.OrderDetails.Add(orderDetail);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                var existingOrderDetail = _context.OrderDetails.FirstOrDefault(od => od.Id == orderDetail.Id);
                if (existingOrderDetail == null) return false;

                existingOrderDetail.Quantity = orderDetail.Quantity;
                existingOrderDetail.TotalPrice = orderDetail.TotalPrice;

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteOrderDetail(int id)
        {
            try
            {
                var orderDetail = _context.OrderDetails.FirstOrDefault(od => od.Id == id);
                if (orderDetail == null) return false;

                _context.OrderDetails.Remove(orderDetail);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
