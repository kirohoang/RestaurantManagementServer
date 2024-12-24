using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementServer.Data;
using RestaurantManagementServer.Models.Dto.Add;
using RestaurantManagementServer.Models.Dto.Update;
using RestaurantManagementServer.Models.Entities;

namespace RestaurantManagementServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailsController : ControllerBase
    {
        private readonly FinalTermContext customerDetailsContext;

        private string customerNotFound = "Customer details doesn't exist";

        public CustomerDetailsController(FinalTermContext customerDetailsContext)
        {
            this.customerDetailsContext = customerDetailsContext;
        }

        [HttpGet]
        public IActionResult getAllCustomerDetails()
        {
            var customersDetails = customerDetailsContext.CustomerDetails.ToList();
            return Ok(customersDetails);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult getCustomerDetailsById(int id)
        {
            var customerDetails = customerDetailsContext.CustomerDetails.Find(id);
            if (customerDetails is null)
            {
                return NotFound(customerNotFound);
            }

            return Ok(customerDetails);
        }

        [HttpGet]
        [Route("get-customer-details-by-customer-id/{customerId:int}")]
        public IActionResult getCustomerDetailsByCustomerId(int customerId)
        {
            var customerDetails = customerDetailsContext.CustomerDetails.FirstOrDefault(cd => cd.CustomerId == customerId);
            if (customerDetails is null)
            {
                return NotFound(customerNotFound);
            }

            return Ok(customerDetails);
        }

        [HttpPost]
        public IActionResult addCustomerDetails(AddCustomerDetailsDto addCustomerDetailsDto)
        {
            var customerDetails = new CustomerDetail()
            {
                CustomerId = addCustomerDetailsDto.CustomerId,
                CustomerBudget = addCustomerDetailsDto.CustomerBudget,
                Status = addCustomerDetailsDto.Status,
            };
            customerDetailsContext.CustomerDetails.Add(customerDetails);
            customerDetailsContext.SaveChanges();
            return Ok(customerDetails);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult updateCustomerDetails(int id, UpdateCustomerDetailsDto updateCustomerDetailsDto)
        {
            var customersDetails = customerDetailsContext.CustomerDetails.Find(id);

            if (customersDetails is null)
            {
                return NotFound(customerNotFound);
            }

            customersDetails.CustomerId = updateCustomerDetailsDto.CustomerId;
            customersDetails.CustomerBudget = updateCustomerDetailsDto.CustomerBudget;
            customersDetails.Status = updateCustomerDetailsDto.Status;

            customerDetailsContext.SaveChanges();

            return Ok(customersDetails);
        }

        [HttpPut]
        [Route("update-budget/{id:int}")]
        public IActionResult updateCustomerDetailsBudget(int id, UpdateCustomerBudgetDto updateCustomerBudgetDto)
        {
            var customersDetails = customerDetailsContext.CustomerDetails.Find(id);

            if (customersDetails is null)
            {
                return NotFound(customerNotFound);
            }

            customersDetails.CustomerBudget += updateCustomerBudgetDto.CustomerBudget;

            customerDetailsContext.SaveChanges();

            return Ok(customersDetails);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult deleteCustomer(int id)
        {
            var customerDetails = customerDetailsContext.CustomerDetails.Find(id);

            if (customerDetails is null)
            {
                return NotFound(customerNotFound);
            }

            customerDetailsContext.CustomerDetails.Remove(customerDetails);
            customerDetailsContext.SaveChanges();
            return Ok("Removed Successfully");
        }
    }
}
