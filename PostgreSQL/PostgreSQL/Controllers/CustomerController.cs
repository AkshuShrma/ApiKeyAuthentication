using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Models;
using PostgreSQL.Services;

namespace PostgreSQL.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _customerService.GetAllAsync();
            if (data.Count()!=0) return Ok(data);
            return NotFound(data);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetId(int id)
        {
            var data = await _customerService.GetByIdAsync(id);
            if(data == null) return NotFound("Id not matched");
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Customer model)
        {
            if(model == null) return BadRequest("First fill the data");
            if (await _customerService.CustomerExists(model.FirstName))
            {
                ModelState.AddModelError("", $"Customer Already Exists!!{model.Id}");
                return NotFound("Customer Already Exists!!");
            }
            if (!await _customerService.CreateAsync(model))
            {
                ModelState.AddModelError("", $"Something went wrong while save data!!{model.Id}");
                return BadRequest("Data not added");
            }
            return Ok(model);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Customer model)
        {
            if (model == null) return BadRequest();
            if (!await _customerService.UpdateAsync(model))
            {
                ModelState.AddModelError("", $"Something went wrong while update data!!{model.Id}");
                return BadRequest("Data not updated");
            }
            return Ok(model);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _customerService.GetByIdAsync(id);
            if (data == null) return NotFound("Id Not Found");
            if (!await _customerService.DeleteAsync(data))
            {
                ModelState.AddModelError("", $"Something went wrong while Delete data!!{data.Id}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(data);
        }
    }
}
