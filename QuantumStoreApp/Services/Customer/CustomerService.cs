using AutoMapper;

namespace QuantumStore
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        // جلب جميع العملاء
        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();
            if (customers == null)
            {
                return Enumerable.Empty<CustomerDTO>();
            }

            return customers.Select(c => _mapper.Map<CustomerDTO>(c));
        }

        // جلب عميل بواسطة ID
        public CustomerDTO GetCustomerById(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);
            return customer != null ? _mapper.Map<CustomerDTO>(customer) : null;
        }

        // جلب عميل بواسطة البريد الإلكتروني
        public CustomerDTO GetCustomerByEmail(string email)
        {
            var customer = _customerRepository.GetCustomerByEmail(email);
            return customer != null ? _mapper.Map<CustomerDTO>(customer) : null;
        }

        // إضافة عميل جديد
        public bool AddCustomer(CustomerDTO customerDTO)
        {
            if (!ValidateCustomerData(customerDTO, out string validationError))
            {
                Console.WriteLine($"Validation Failed: {validationError}");
                return false; // البيانات غير صالحة
            }

            try
            {
                var customer = _mapper.Map<Customer>(customerDTO);
                _customerRepository.AddCustomer(customer);
                return true; // تم الإضافة بنجاح
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Adding Customer: {ex.Message}");
                return false; // فشل الإضافة
            }
        }

        // تحديث بيانات عميل موجود
        public bool UpdateCustomer(CustomerDTO customerDTO)
        {
            var existingCustomer = _customerRepository.GetCustomerById(customerDTO.Id);
            if (existingCustomer == null)
            {
                return false; // العميل غير موجود
            }

            var updatedCustomer = _mapper.Map(customerDTO, existingCustomer);
            try
            {
                _customerRepository.UpdateCustomer(updatedCustomer);
                return true; // تم التحديث بنجاح
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Updating Customer: {ex.Message}");
                return false; // فشل التحديث
            }
        }

        // حذف عميل بناءً على ID
        public bool DeleteCustomer(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return false; // العميل غير موجود
            }

            try
            {
                _customerRepository.DeleteCustomer(id);
                return true; // تم الحذف بنجاح
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Deleting Customer: {ex.Message}");
                return false; // فشل الحذف
            }
        }

        // التحقق من صحة بيانات العميل
        private bool ValidateCustomerData(CustomerDTO customerDTO, out string validationError)
        {
            validationError = string.Empty;

            if (string.IsNullOrWhiteSpace(customerDTO.Name))
            {
                validationError = "Customer name is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(customerDTO.Email) || !customerDTO.Email.Contains("@"))
            {
                validationError = "A valid email is required.";
                return false;
            }

            return true; // البيانات صالحة
        }
    }
}
