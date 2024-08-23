using DbContextL;
using Domian;
using FinalProjectAPI.EmailTemplate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Dtos.Comment;
using Application.Features.UserReviews.Queries.GetUserReviewDetails;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticalController : ControllerBase
    {
        private readonly Context _Context;
        private readonly UserManager<User> UserManager;
        private readonly IConfiguration _Configuration;
     
             

       // var _user = await UserManager.FindByEmailAsync(loginModel.Email);

        public ArticalController(Context context, UserManager<User> _userManager ,IConfiguration configuration)
        {
            _Context = context;
            UserManager = _userManager;
            _Configuration = configuration;
            _Configuration = configuration;

        }

        [HttpGet("GetAllArtical")]
        public async Task<IActionResult> GetAllArtical()
        {
            try
            {

                return Ok(_Context.articals.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetAllArticalDetails")]
        public async Task<IActionResult> GetAllArticalDetails([FromQuery] int? ArticalId)
        {

            try
            {
                var r = _Context.articals.FirstOrDefault(a=>a.ArticalId==ArticalId);

                return Ok(r);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        ///Comment
        [HttpPost("CreateComment")]
        public async Task<CommentMinimalDTO> CreateComment([FromBody] Comment query)
        {
            if (!ModelState.IsValid)
               return new CommentMinimalDTO { text = "لقد حدث خطا ما الرجاء المحاوله مره أخرى" }; ;

            try
            {
                     Comment query1 = new Comment();
                     query1.Commentt = query.Commentt;
                     query1.UserName = query.UserName;
                     query1.ArticalId= query.ArticalId;
                     query1.Show = false;
                    _Context.comments.Add(query1);
                    _Context.SaveChanges();
                    return new CommentMinimalDTO { text = "لقد تم حفظ تعليقك", Name =query.UserName, Date = DateTime.Now };
               

            }
            catch (Exception ex) {

                return new CommentMinimalDTO { text = "حدث خطأ ما الرجاء المحاوله مره اخرى" }; ;
            
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllComment([FromQuery] int? id)
        {
            if (id == null)
                return NotFound($"No ID with this {id}");
            try
            {
                var data =await _Context.comments.Where(a=>a.ArticalId == id && a.Show==true).ToListAsync();
                if(data != null)
                { 
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}