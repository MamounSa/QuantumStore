using Microsoft.EntityFrameworkCore;

namespace QuantumStore
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context; // سياق قاعدة البيانات

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        // جلب جميع العملاء
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        // جلب عميل معين باستخدام ID
        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        // جلب عميل معين باستخدام البريد الإلكتروني
        public Customer GetCustomerByEmail(string email)
        {
            return _context.Customers.FirstOrDefault(c => c.Email == email);
        }

        // إضافة عميل جديد
        public bool AddCustomer(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return true; // العملية نجحت
            }
            catch
            {
                return false; // حدث خطأ
            }
        }

        // تحديث بيانات عميل موجود
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                var existingCustomer = GetCustomerById(customer.Id);
                if (existingCustomer == null) return false; // العميل غير موجود
                _context.SaveChanges();
                return true; // العملية نجحت
            }
            catch
            {
                return false; // حدث خطأ
            }
        }

        // حذف عميل بناءً على ID
        public bool DeleteCustomer(int id)
        {
            var customer = GetCustomerById(id);
            if (customer == null) return false; // العميل غير موجود

            try
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return true; // العملية نجحت
            }
            catch
            {
                return false; // حدث خطأ
            }
        }
    }
}
