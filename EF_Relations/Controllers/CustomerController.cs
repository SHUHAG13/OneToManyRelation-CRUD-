using AutoMapper;
using EF_Relations.Interfaces;
using EF_Relations.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_Relations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet]
        public async Task<IActionResult>Get()
        {
            var customer = await _customerRepository.GetAllAsync();
            return Ok(customer);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult>GetById(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if(customer!=null)
            {
                return Ok(customer);
            }
            return NotFound($"Customer with id {id} not found");
        }
        //[HttpGet("{id:int}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var customer = await _dbContext.Customer.Include(c => c.customerAddresses).FirstOrDefaultAsync(c => c.Id == id);
        //    if (customer != null)
        //    {
        //        return Ok(customer);
        //    }
        //    return NotFound($"Customer with ID {id} not found");

        //}

        [HttpPost]
        public async Task<IActionResult>Create(CustomerDto customerDto)
        {
            var newCustomer = await _customerRepository.CreateAsync(customerDto);
            return CreatedAtAction(nameof(GetById), new { id = newCustomer.Id }, newCustomer);
        }

        //[HttpPost]
        //public async Task<IActionResult>Post(CustomerDto customerDto)
        //{
        //var _newCustomer = _mapper.Map<Customer>(customerDto);
        //_dbContext.Customer.Add(_newCustomer);
        //await _dbContext.SaveChangesAsync();
        //return CreatedAtAction(nameof(GetById), new { id =_newCustomer.Id },_newCustomer);

        //}
        [HttpPut]
        public async Task<IActionResult>UpdateCustomer(CustomerDto customerDto)
        {
            var updateCustomer = await _customerRepository.UpdateAsync(customerDto);
            return Ok(new
            {
                Message = "Customer updated successfully",
                Data = updateCustomer
            });

        }
        //[HttpPut]
        //public async Task<IActionResult>Put(CustomerDto customerDto)
        //{
        //var updateCustomer = _mapper.Map<Customer>(customerDto);
        //_dbContext.Customer.Update(updateCustomer);
        //    await _dbContext.SaveChangesAsync();
        //        return Ok(new
        //        {
        //            Message = "Customer updated successfully",
        //            Data = updateCustomer
        //});
        //}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult>Delete(int id)
        {
            var customertoDelete = await _customerRepository.DeleteAsync(id);
            if (customertoDelete != null)
            {
                return Ok($"Deleted with id {id} successfull");

            }
            return NotFound($"Customer with Id {id} is not found");
        }

        //[HttpDelete("{id:int}")]
        //public async Task<IActionResult>Delete(int id)
        //{
    //    var customerToDelete = await _dbContext.Customer.Include(c => c.customerAddresses).Where(c => c.Id == id).FirstOrDefaultAsync();
    //        if(customerToDelete == null)
    //        {
    //            return NotFound();
    //}
    //_dbContext.Customer.Remove(customerToDelete);
    //        await _dbContext.SaveChangesAsync();
    //    return Ok($"Deleted with id {id} successfull");


    //}

}
}
