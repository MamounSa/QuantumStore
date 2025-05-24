namespace QuantumStore
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } // علاقة مع العميل
        public ICollection<OrderDetail> OrderDetails { get; set; } // علاقة مع تفاصيل الطلب
                                                                   // 
        public Shipment Shipment { get; set; }

        public ICollection<Return> Returns { get; set; }


        public Payment Payment { get; set; }

    }

}
