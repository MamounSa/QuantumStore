namespace QuantumStore
{
    public class Warehouse
    {
        public int Id { get; set; } // معرّف المستودع
        public string Name { get; set; } // اسم المستودع
        public string Location { get; set; } // موقع المستودع
        public ICollection<Inventory> InventoryItems { get; set; } // المنتجات داخل المستودع
    }

}
