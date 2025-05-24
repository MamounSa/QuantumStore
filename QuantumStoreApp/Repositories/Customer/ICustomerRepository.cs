
namespace QuantumStore
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers(); // جلب جميع العملاء
        Customer GetCustomerById(int id); // جلب عميل معين باستخدام ID
        Customer GetCustomerByEmail(string email); // جلب عميل معين باستخدام البريد الإلكتروني

        bool AddCustomer(Customer customer); // إضافة عميل جديد
        bool UpdateCustomer(Customer customer); // تحديث بيانات عميل موجود
        bool DeleteCustomer(int id); // حذف عميل بناءً على ID
    }
}


