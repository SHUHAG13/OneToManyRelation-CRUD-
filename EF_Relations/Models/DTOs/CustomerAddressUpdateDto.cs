namespace EF_Relations.Models.DTOs
{
    public class CustomerAddressUpdateDto
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}
