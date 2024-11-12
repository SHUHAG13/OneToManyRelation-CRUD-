using EF_Relations.Data;

namespace EF_Relations.Models.DTOs
{
    public class CustomerUpdateDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public List<CustomerAddresses> customerAddresses { get; set; }
    }
}
