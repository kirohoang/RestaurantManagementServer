using Microsoft.AspNetCore.Mvc;
using RestaurantManagementServer.Data;
using RestaurantManagementServer.Models.Dto.Add;
using RestaurantManagementServer.Models.Dto.Update;
using RestaurantManagementServer.Models.Entities;

namespace RestaurantManagementServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly FinalTermContext branchContext;

        public BranchesController(FinalTermContext branchContext)
        {
            this.branchContext = branchContext;
        }

        [HttpGet]
        public IActionResult getAllBranch()
        {
            var allBranch = branchContext.Branches.ToList();

            return Ok(allBranch);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult getBranchById(int id)
        {
            var branch = branchContext.Branches.Find(id);
            if (branch is null)
            {
                return NotFound("Branch doesn't exist");
            }
            return Ok(branch);
        }

        [HttpPost]
        public IActionResult addBranch(AddBranchDto addBranchDto)
        {
            var branch = new Branch()
            {
                BranchName = addBranchDto.BranchName,
                BranchAddress = addBranchDto.BranchAddress,
            };
            branchContext.Branches.Add(branch);
            branchContext.SaveChanges();
            return Ok(branch);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult updateBranch(int id, UpdateBranchDto updateBranchDto)
        {
            var branch = branchContext.Branches.Find(id);

            if (branch is null)
            {
                return NotFound("Branch doesn't exist");
            }
            branch.BranchName = updateBranchDto.BranchName;
            branch.BranchAddress = updateBranchDto.BranchAddress;

            branchContext.SaveChanges();
            return Ok("Updated Successfully!");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult deleteBranch(int id)
        {
            var branch = branchContext.Branches.Find(id);

            if (branch is null)
            {
                return NotFound("Branch doesn't exist");
            }

            branchContext.Branches.Remove(branch);
            branchContext.SaveChanges();
            return Ok("Deleted Successfully!");
        }
    }
}
