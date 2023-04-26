namespace ServiceStation.DAL.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int JobId { get; set; }

        public DateTime IssueDate { get; set; }
        public bool Delivered { get; set; }


    }
}
