namespace EF_Relations.Data
{
    public class CustomerAddresses
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int CustomerId { get; set; }//Foreign Key

        /*This is also a navigation property that
         * allows each CustomerAddresses entity 
         * to reference its related Customer. 
         * This property acts as a pointer back to
         * the Customer entity that owns the address,
         * which helps EF Core navigate from an address
         * to the customer it belongs to.*/
        public Customer Customer { get; set; }
    }
}
