namespace QuantumStore
{
    public class Shipment
    {
        public int Id { get; set; }
        public string TrackingNumber { get; set; } // رقم التتبع للشحنة
        public DateTime ShipmentDate { get; set; } // تاريخ الشحن
        public int OrderId { get; set; }
        public Order Order { get; set; } // علاقة مع الطلب
    }

}
