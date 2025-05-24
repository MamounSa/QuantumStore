namespace QuantumStore
{
    public interface IOrderService
    {
        IEnumerable<OrderDTO> GetAllOrders(); // جلب جميع الطلبات
        OrderDTO GetOrderById(int id); // جلب طلب باستخدام ID
        bool AddOrder(OrderDTO orderDTO); // إضافة طلب جديد
        bool UpdateOrder(OrderDTO orderDTO); // تعديل طلب
        bool DeleteOrder(int id); // حذف طلب
    }

}
