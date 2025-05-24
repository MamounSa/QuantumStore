namespace QuantumStore
{
    using System.Collections.Generic;

    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetAllOrderDetails(); // جلب جميع تفاصيل الطلب
        OrderDetail GetOrderDetailById(int id); // جلب تفاصيل طلب باستخدام ID
        bool AddOrderDetail(OrderDetail orderDetail); // إضافة تفاصيل طلب جديد
        bool UpdateOrderDetail(OrderDetail orderDetail); // تعديل تفاصيل طلب
        bool DeleteOrderDetail(int id); // حذف تفاصيل طلب
    }
}
