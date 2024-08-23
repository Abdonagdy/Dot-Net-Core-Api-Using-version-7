
using Application.Features.Categories.Queries.GetAllCategories;
using Application.Features.Categories.Queries.GetCategoryDetails;
using DbContextL;
using Domian;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly Context _contex;
        public CategoryController(IMediator medaitor,Context context)
        {
            _mediator = medaitor;
            _contex = context;
        }

        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> FilterCategories([FromQuery] FilterCategoriesQuery query)
        {

            return Ok(await _mediator.Send(query));
        }
        [HttpGet("asd")]
        public async Task<IActionResult> GetCategoryDetails([FromQuery] GetCategoryDetailsQuery q)
        {
            return Ok(await _mediator.Send(q));
        }
        [HttpGet("GetAllCategoryBycategory")]
        public async Task<Category> GetcategorybyCategory([FromQuery] int query)
        {
           
            var r = await _contex.Categories.Include(a=>a.SubCategories).ThenInclude(a=>a.Products).Where(a=>a.Id==query).FirstOrDefaultAsync();
           if(r== null)
                return null!;
           else
            return r;
        }
       
    }
}