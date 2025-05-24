namespace QuantumStore
{
    public class PaymentMethod
    {
        public int Id { get; set; } // معرّف طريقة الدفع
        public string Name { get; set; } // اسم طريقة الدفع (مثل Visa، PayPal)
        public decimal? Fee { get; set; } // الرسوم الإضافية (إن وُجدت)
        public bool IsActive { get; set; } // حالة التفعيل (مفعل/غير مفعل)
        public ICollection<Payment> Payments { get; set; } // علاقة مع المدفوعات
    }


}
