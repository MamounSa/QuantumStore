using QuantumStore;

public class OrderDTO
{
    public int Id { get; set; } // معرف الطلب
    public DateTime OrderDate { get; set; } // تاريخ الطلب
    public int CustomerId { get; set; } // معرف العميل المرتبط    
}
