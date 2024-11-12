namespace EF_Relations.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }

      
        public List<CustomerAddresses> customerAddresses { get; set; }
    }
}
