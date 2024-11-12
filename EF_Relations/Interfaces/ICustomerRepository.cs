using EF_Relations.Data;
using EF_Relations.Models.DTOs;

namespace EF_Relations.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> CreateAsync(CustomerDto customerDto);
        Task<Customer> UpdateAsync(CustomerDto customerDto);
        Task<bool> DeleteAsync(int id);
    }
}
