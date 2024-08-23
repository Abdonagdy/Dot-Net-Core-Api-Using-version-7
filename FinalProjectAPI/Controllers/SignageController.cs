using DbContextL;
using Domian;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignageController : ControllerBase
    {
        private readonly Context _dbContext;

        public SignageController(Context dbContext)
        {

            _dbContext = dbContext;

        }

        [HttpGet("signageList")]
        public async Task<IActionResult> SignageList()
        {
            try
            {
                var signages = await _dbContext.signages
                    .Where(s => s.IsActive == true)
                    .OrderBy(r => r.DisplayOrder)
                    .ToListAsync();

                return Ok(signages);
            }
            catch (Exception ex)
            {
                // Log the exception or return an error response
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
