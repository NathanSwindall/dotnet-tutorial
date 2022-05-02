namespace Domain
{
    public class Country
    {
        public Guid Id { get; set; }
        public string CountryName { get; set; }
        public int Population { get; set; }
        public int GDP { get; set; } // in billions
        public string Language { get; set; }
        public string GovernmentType { get; set; }
        public string Leader { get; set; }
    }
}