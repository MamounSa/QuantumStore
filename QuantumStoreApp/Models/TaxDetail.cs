namespace QuantumStore
{
    public class TaxDetail
    {
        public int Id { get; set; }
        public decimal TaxAmount { get; set; } // مقدار الضريبة
        public int OrderId { get; set; }
        public Order Order { get; set; } // علاقة مع الطلب
    }

}
