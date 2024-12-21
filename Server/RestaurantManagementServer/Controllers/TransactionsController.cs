using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementServer.Data;
using RestaurantManagementServer.Models.Dto.Add;
using RestaurantManagementServer.Models.Entities;

namespace RestaurantManagementServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly FinalTermContext transactionContext;

        public TransactionsController(FinalTermContext transactionContext)
        {
            this.transactionContext = transactionContext;
        }

        [HttpGet]
        public IActionResult getAllTransactions()
        {
            var transaction = transactionContext.Transactions.ToList();
            return Ok(transaction);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult getTransactionById(int id)
        {
            var transaction = transactionContext.Transactions.Find(id);
            if (transaction is null)
            {
                return NotFound("Transaction doesn't exist");
            }

            return Ok(transaction);
        }

        [HttpPost]
        public IActionResult addTransaction(AddTransactionDto addTransactionDto)
        {
            var transaction = new Transaction()
            {
                CustomerId = addTransactionDto.CustomerId,
                Amount = addTransactionDto.Amount,
                TransactionDate = addTransactionDto.TransactionDate,
                TransactionType = addTransactionDto.TransactionType,
                Description = addTransactionDto.Description
            };

            var customerDetails = transactionContext.CustomerDetails.FirstOrDefault(cd => cd.CustomerId == addTransactionDto.CustomerId);

            if (customerDetails is null)
            {
                return NotFound("Customer doesn't exist");
            }

            if (transaction.TransactionType == "Deposit")
            {
                customerDetails.CustomerBudget += transaction.Amount;
            }
            else if (transaction.TransactionType == "Withdraw")
            {
                if (customerDetails.CustomerBudget < transaction.Amount)
                {
                    return BadRequest("Not enough budget");
                }
                customerDetails.CustomerBudget -= transaction.Amount;
            }
            else // Purchase
            {
                customerDetails.CustomerBudget -= transaction.Amount;
            }
            transactionContext.Add(transaction);
            transactionContext.SaveChanges();
            return Ok(transaction);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult updateTransaction(int id, AddTransactionDto addTransactionDto)
        {
            var transaction = transactionContext.Transactions.Find(id);
            if (transaction is null)
            {
                return NotFound("Transaction doesn't exist");
            }

            transaction.CustomerId = addTransactionDto.CustomerId;
            transaction.Amount = addTransactionDto.Amount;
            transaction.TransactionDate = addTransactionDto.TransactionDate;
            transaction.TransactionType = addTransactionDto.TransactionType;
            transaction.Description = addTransactionDto.Description;

            transactionContext.SaveChanges();
            return Ok(transaction);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult deleteTransaction(int id)
        {
            var transaction = transactionContext.Transactions.Find(id);
            if (transaction is null)
            {
                return NotFound("Transaction doesn't exist");
            }

            transactionContext.Remove(transaction);
            transactionContext.SaveChanges();
            return Ok(transaction);
        }
    }
}
