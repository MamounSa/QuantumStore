namespace QuantumStore
{
    public class Inventory
    {
        public int Id { get; set; } // معرّف المخزون
        public int WarehouseId { get; set; } // المستودع المرتبط
        public Warehouse Warehouse { get; set; } // العلاقة مع المستودع
        public int ProductId { get; set; } // المنتج المرتبط
        public Product Product { get; set; } // العلاقة مع المنتج
        public int Quantity { get; set; } // الكمية المتاحة داخل المستودع لهذا المنتج
    }


}
