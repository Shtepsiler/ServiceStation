namespace ServiceStation.DAL.Entities
{
    public class Part
    {
        public int PartId { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int VendorId { get; set; }
        public int StockQty { get; set; }

    }
}
