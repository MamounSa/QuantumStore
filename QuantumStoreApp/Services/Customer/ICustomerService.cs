namespace QuantumStore
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDTO> GetAllCustomers(); // جلب جميع العملاء
        CustomerDTO GetCustomerById(int id); // جلب عميل بناءً على ID
        CustomerDTO GetCustomerByEmail(string email); // جلب عميل بناءً على البريد الإلكتروني
        bool AddCustomer(CustomerDTO customerDTO); // إضافة عميل جديد
        bool UpdateCustomer(CustomerDTO customerDTO); // تحديث بيانات عميل موجود
        bool DeleteCustomer(int id); // حذف عميل بناءً على ID
    }
}
