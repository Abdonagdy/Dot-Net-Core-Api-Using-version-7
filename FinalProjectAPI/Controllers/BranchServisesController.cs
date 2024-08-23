using DbContextL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchServisesController : ControllerBase
    {
        private readonly Context _dbContext;

        public BranchServisesController(Context dbContext)
        {

            _dbContext = dbContext;
        
        }

        [HttpGet("GetAllServices")]
        public IActionResult GetAllServices()
        {
            var r = _dbContext.branshes.Include(a => a.branchServices).ToList();

            return Ok(r);
        }

        [HttpGet("GetAllServicesByBranchId")]
        public IActionResult GetAllServicesByBranchId([FromQuery]long brid)
        {
            var r = _dbContext.branshes.Include(a=>a.branchServices).Where(a=>a.brannum==brid).ToList();
            return Ok(r);
        }


    }
    }
