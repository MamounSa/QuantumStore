namespace QuantumStore
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentMethodId { get; set; } // معرّف طريقة الدفع
        public PaymentMethod PaymentMethod { get; set; } // علاقة مع PaymentMethod
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }


    


}
