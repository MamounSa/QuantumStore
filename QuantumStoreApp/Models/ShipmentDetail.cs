namespace QuantumStore
{
    public class ShipmentDetail
    {
        public int Id { get; set; }
        public string Address { get; set; } // عنوان الشحن
        public string DeliveryStatus { get; set; } // حالة التوصيل
        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; } // علاقة مع الشحنة
    }

}
