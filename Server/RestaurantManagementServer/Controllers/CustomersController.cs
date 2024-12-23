using Microsoft.AspNetCore.Mvc;
using RestaurantManagementServer.Data;
using RestaurantManagementServer.Models.Dto.Add;
using RestaurantManagementServer.Models.Dto.Update;
using RestaurantManagementServer.Models.Entities;
using System.Net.Mail;
using System.Net;

namespace RestaurantManagementServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly FinalTermContext customerContext;

        private string customerNotFound = "Customer doesn't exist";
        public CustomersController(FinalTermContext customerContext)
        {
            this.customerContext = customerContext;
        }

        [HttpGet]
        public IActionResult getAllCustomers()
        {
            var customer = customerContext.Customers.ToList();
            return Ok(customer);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult getCustomerById(int id)
        {
            var customer = customerContext.Customers.Find(id);
            if (customer is null)
            {
                return NotFound(customerNotFound);
            }

            return Ok(customer);
        }

        [HttpGet]
        [Route("get-customer-by-username/{username}")]
        public IActionResult getCustomerByUsername(string username)
        {
            var customer = customerContext.Customers.FirstOrDefault(c => c.Username == username);
            if (customer is null)
            {
                return NotFound(customerNotFound);
            }

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult addCustomer(AddCustomerDto addCustomerDto)
        {
            var customerEntity = new Customer()
            {
                CustomerName = addCustomerDto.CustomerName,
                Username = addCustomerDto.Username,
                Password = addCustomerDto.Password,
                Address = addCustomerDto.Address,
                Email = addCustomerDto.Email,
                Phone = addCustomerDto.Phone
            };
            customerContext.Customers.Add(customerEntity);
            customerContext.SaveChanges();
            return Ok(customerEntity);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult updateCustomer(int id, UpdateCustomerDto updateCustomerDto)
        {
            var customer = customerContext.Customers.Find(id);

            if (customer is null)
            {
                return NotFound(customerNotFound);
            }

            customer.CustomerName = updateCustomerDto.CustomerName;
            customer.Password = updateCustomerDto.Password;
            customer.Address = updateCustomerDto.Address;
            customer.Email = updateCustomerDto.Email;
            customer.Phone = updateCustomerDto.Phone;

            customerContext.SaveChanges();

            return Ok(customer);
        }

        private static int randomOTP()
        {
            Random random = new Random();

            return random.Next(100000, 999999);
        }

        private static int sendOTP = randomOTP();

        private void sendMail(string receiveEmail)
        {
            string fromMail = "trunghoang1124@gmail.com";
            string fromPassword = "almtsqdrgsyrmdno";

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(fromMail);
            mailMessage.Subject = "RESET PASSWORD FROM TRUNG'S PALACE";
            mailMessage.To.Add(new MailAddress(receiveEmail));
            mailMessage.Body = $"Here is your OTP to reset your password {sendOTP}";

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true
            };

            smtpClient.Send(mailMessage);
        }

        [HttpPost]
        [Route("{email}")]
        public IActionResult sendEmail(string email)
        {
            var customerMail = customerContext.Customers.FirstOrDefault(c => c.Email == email);

            if (customerMail is null)
            {
                return NotFound("Email doesn't exist");
            }
            sendMail(email);
            return Ok("Sent");
        }

        [HttpGet]
        [Route("check-otp/{otp:int}")]
        public IActionResult checkOTP(int otp)
        {
            if (otp == sendOTP)
            {
                return Ok("OTP is correct");
            }
            return BadRequest("OTP is incorrect");
        }

        [HttpPut]
        [Route("update-password/{email}")]
        public IActionResult updateCustomerPassword(string email, UpdateCustomerPassword updateCustomerPassword)
        {
            if (updateCustomerPassword == null || string.IsNullOrEmpty(updateCustomerPassword.Password))
            {
                return BadRequest("Invalid password data.");
            }

            var customer = customerContext.Customers.FirstOrDefault(c => c.Email == email);

            if (customer is null)
            {
                return NotFound("Email doesn't exist.");
            }

            customer.Password = updateCustomerPassword.Password;
            try
            {
                customerContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return Ok(customer);
        }


        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult deleteCustomer(int id)
        {
            var customer = customerContext.Customers.Find(id);

            if (customer is null)
            {
                return NotFound(customerNotFound);
            }

            customerContext.Customers.Remove(customer);
            customerContext.SaveChanges();
            return Ok("Removed Successfully");
        }
    }
}
