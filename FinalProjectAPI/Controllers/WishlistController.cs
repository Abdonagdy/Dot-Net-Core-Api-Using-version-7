using Application.Features.Wishlists.Command.Create;
using Application.Features.Wishlists.Command.Delete;
using DbContextL;
using Domian;
using Dtos.Product;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<User> _userManager;
        private readonly Context _context;

        public WishlistController(IMediator mediator,UserManager<User> user,Context context)
        {
            _mediator = mediator;
            _userManager = user;
            _context = context;
        }




        [HttpPost("AddWishlist")]
        public async Task<IActionResult> AddWishlist([FromBody] CreateWishlistCommand command)
        {
          
                return Ok(await _mediator.Send(command));


        
        }
        [HttpDelete("RemoveWishlist")]
        public async Task<IActionResult> RemoveWishlist([FromQuery] int Uid, [FromQuery] long Pid)
        {


            return Ok(await _mediator.Send(new DeleteWishlistCommand { Pid=Pid , Uid = Uid}));

        }

        [HttpGet("ShowAllWishlist")]
        public async Task<List<ProductLargeDto>> ShowAllWishlist([FromQuery] int uid)
        {

            try
            {
                if(uid == null)
                {
                    return null!;
                }

                else
                {
                   var pro= _context.Users.FirstOrDefault(a=>a.Id==uid);
                    
                    if(pro == null)
                    {
                        return null!;
                    }
                    else
                    { 
                        var result = _context.WishLists.Where(a=>a.User.Id==uid).Include(p=>p.Product).ToList();
                        var allproduct= result.Select(a=>a.Product);



                        List<ProductLargeDto> listt = new List<ProductLargeDto>(); 
                        foreach (var item in allproduct)
                        { 

                            
                      ProductLargeDto p = new ProductLargeDto
                        {
                            Id = item.Id,
                            Name = item.Name,
                            NameEN=item.NameEN,
                            Description = item.Description,
                            DiscountPercentage = item.DiscountPercentage,
                            OldPrice = item.OldPrice,
                            Price = item.Price,
                            ServiceCode = item.ServiceCode,
                            Quantity = item.Quantity,
                            Images=item.ImageURL,
                            ShortDescription = item.ShortDescription,
                            ShortDescriptionEN=item.ShortDescriptionEN,
                           

                        };
                            foreach (var item1 in item.Categories)
                            {
                                p.CategoriesNames.Add(item1.Id);

                            }
                            listt.Add(p);
                        }
                        return listt;
                    }
                }

            }
            catch (Exception ex)
            {
                return null!;
            }
        }

    }

}
