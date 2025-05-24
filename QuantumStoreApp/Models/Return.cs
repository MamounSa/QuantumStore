namespace QuantumStore
{
    public class Return
    {
        public int Id { get; set; } // معرّف الإرجاع
        public int OrderId { get; set; } // الطلب المرتبط بالإرجاع
        public Order Order { get; set; } // العلاقة مع الطلب
        public int CustomerId { get; set; } // العميل الذي قام بالإرجاع
        public Customer Customer { get; set; } // العلاقة مع العميل
        public string Reason { get; set; } // سبب الإرجاع
        public DateTime ReturnDate { get; set; } // تاريخ الإرجاع
        public string Status { get; set; } // حالة الإرجاع (مقبول، مرفوض، تحت المراجعة)
    }


}
