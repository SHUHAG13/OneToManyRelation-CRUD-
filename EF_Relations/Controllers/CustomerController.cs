using AutoMapper;
using EF_Relations.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_Relations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerController(CustomerDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult>Get()
        {
            var customer = await _dbContext.Customer.Include(c => c.customerAddresses).ToListAsync();
            return Ok(customer);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        { 
                var customer = await _dbContext.Customer.Include(c => c.customerAddresses).FirstOrDefaultAsync(c => c.Id == id);
                if(customer != null)
                   {
                     return Ok(customer);
                   } 
            return NotFound($"Customer with ID {id} not found");           
            
        }


        [HttpPost]
        public async Task<IActionResult>Post(CustomerDto customerDto)
        {
            var _newCustomer = _mapper.Map<Customer>(customerDto);
            _dbContext.Customer.Add(_newCustomer);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id =_newCustomer.Id },_newCustomer);

        }
        [HttpPut]
        public async Task<IActionResult>Put(CustomerDto customerDto)
        {
            var updateCustomer = _mapper.Map<Customer>(customerDto);
            _dbContext.Customer.Update(updateCustomer);
            await _dbContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "Customer updated successfully",
                Data = updateCustomer
            });
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult>Delete(int id)
        {
            var customerToDelete = await _dbContext.Customer.Include(c=>c.customerAddresses).Where(c=>c.Id == id).FirstOrDefaultAsync();
            if(customerToDelete == null)
            {
                return NotFound();
            }
            _dbContext.Customer.Remove(customerToDelete);
            await _dbContext.SaveChangesAsync();
            return Ok($"Deleted with id {id} successfull");


        }

    }
}
