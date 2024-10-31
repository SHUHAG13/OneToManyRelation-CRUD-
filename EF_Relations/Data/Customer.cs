namespace EF_Relations.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }

        /*This line is the navigation property that 
         * enables a one-to-many relationship between 
         * Customer and CustomerAddresses. It indicates
         * that a single Customer can have 
         * multiple CustomerAddresses associated with it.*/
        public List<CustomerAddresses> customerAddresses { get; set; }
    }
}
