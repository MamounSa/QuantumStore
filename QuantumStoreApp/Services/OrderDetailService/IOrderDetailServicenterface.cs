namespace QuantumStore
{
    using System.Collections.Generic;

    public interface IOrderDetailService
    {
        IEnumerable<OrderDetailDTO> GetAllOrderDetails(); // جلب جميع تفاصيل الطلب
        OrderDetailDTO GetOrderDetailById(int id); // جلب تفاصيل طلب باستخدام ID
        bool AddOrderDetail(OrderDetailDTO orderDetailDTO); // إضافة تفاصيل طلب جديد
        bool UpdateOrderDetail(OrderDetailDTO orderDetailDTO); // تعديل تفاصيل طلب
        bool DeleteOrderDetail(int id); // حذف تفاصيل طلب
    }

}
