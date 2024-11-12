using AutoMapper;
using EF_Relations.Data;
using EF_Relations.Interfaces;
using EF_Relations.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EF_Relations.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly CustomerDbContext _dbContext;
        private readonly IMapper _mapper;
        public CustomerRepository(CustomerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

      
        public  async Task<List<Customer>> GetAllAsync()
        {
            return await _dbContext.Customer.Include(c => c.customerAddresses).ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _dbContext.Customer.Include(c => c.customerAddresses).FirstOrDefaultAsync(c => c.Id == id);
            
        }
        public async Task<Customer> CreateAsync(CustomerDto customerDto)
        {
            var _newCustomer =  _mapper.Map<Customer>(customerDto);
            _dbContext.Customer.Add(_newCustomer);
            await _dbContext.SaveChangesAsync();
            return _newCustomer;

        }

        public async  Task<Customer> UpdateAsync(CustomerDto customerDto)
        {
            var updateCustomer = _mapper.Map<Customer>(customerDto);
            _dbContext.Customer.Update(updateCustomer);
            await _dbContext.SaveChangesAsync();
            return updateCustomer;
        }

        public async  Task<bool> DeleteAsync(int id)
        {
            var customerToDelete = await _dbContext.Customer.Include(c => c.customerAddresses).Where(c => c.Id == id).FirstOrDefaultAsync();
          
            _dbContext.Customer.Remove(customerToDelete);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
