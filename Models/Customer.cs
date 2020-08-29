namespace CarRentalAPI.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BonusPoints { get; set; }
    }
}