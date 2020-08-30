namespace CarRentalAPI.Models
{
    public class Car
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int DiscountDays { get; set; }
        public int BonusPoints { get; set; }
        public bool IsAvailable { get; set; }
    }
}