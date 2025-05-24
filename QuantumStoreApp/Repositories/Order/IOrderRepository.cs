using QuantumStore;
using System.Collections.Generic;

namespace QuantumStore
{


    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders(); // جلب جميع الطلبات
        Order GetOrderById(int id); // جلب طلب باستخدام ID
        bool AddOrder(Order order); // إضافة طلب جديد
        bool UpdateOrder(Order order); // تعديل طلب
        bool DeleteOrder(int id); // حذف طلب
    }
}