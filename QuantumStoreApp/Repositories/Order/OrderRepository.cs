using Microsoft.EntityFrameworkCore;
using QuantumStore;
using System.Collections.Generic;
using System.Linq;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Order> GetAllOrders()
    {
        return _context.Orders.Include(o => o.Customer).ToList();
            /*.Include(o => o.Customer)
            .Include(o => o.OrderDetails)
            .Include(o => o.Shipment)
            .Include(o => o.Returns)
            .Include(o => o.Payment)
            .ToList();*/
    }
    public IEnumerable<Order> GetAllOrdersOrderDate(Datetime  datetime)
{
    return _context.Orders.Include(o => o.Customer).where(x=>x.OrderDate== datetime).ToList();
   
}

    public Order GetOrderById(int id)
    {
        return _context.Orders.Include(o => o.Customer)
            .FirstOrDefault(o => o.Id == id);
    }

    public bool AddOrder(Order order)
    {
        try
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool UpdateOrder(Order order)
    {
        try
        {
            var existingOrder = _context.Orders.FirstOrDefault(o => o.Id == order.Id);
            if (existingOrder == null) return false;

            existingOrder.OrderDate = order.OrderDate;
            existingOrder.CustomerId = order.CustomerId;
            existingOrder.OrderDetails = order.OrderDetails;
            existingOrder.Shipment = order.Shipment;
            existingOrder.Returns = order.Returns;
            existingOrder.Payment = order.Payment;

            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteOrder(int id)
    {
        try
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return false;

            _context.Orders.Remove(order);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
