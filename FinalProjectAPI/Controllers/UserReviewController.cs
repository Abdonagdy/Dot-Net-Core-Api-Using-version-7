using Application.Features.UserReviews.Command.CreateReview;
using Application.Features.UserReviews.Queries.FilterUserReviews;
using Application.Features.UserReviews.Queries.GetUserReviewDetails;
using DbContextL;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserReviewController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly Context _context;

        public UserReviewController(IMediator mediator,Context context)
        {
            _mediator = mediator;
            _context = context;
        }

        // POST: ReviewController/Create
        [HttpPost("CreateReview")]
        public async Task<IActionResult> CreateReview([FromBody] CreateUserReviewCommand review)
        {
            try
            {
                var r = _context.UserReviews.FirstOrDefault(a => a.userdId == review.UserId && a.ProdcutId == review.ProductId);
             if(r == null)
                {
                    return Ok(await _mediator.Send(new CreateUserReviewCommand
              (
                review.Comment!, review.RatingValue, review.Date, review.UserId, review.ProductId
               )));

                }

                else
                {
                    CreateUserReviewCommand review1 = new CreateUserReviewCommand();
                    review.UserId = 0;
                    review1.Comment = "you are commented in before";
                    review1.RatingValue = 0;
                    review1.Date = DateTime.Now;
                    review1.ProductId = 0;
                    return Ok(review1);

                }

            }
            catch (Exception e)
            {
                return NotFound(e.Message + "hello");
            }
        }

       

        [HttpGet("allreview")]
        public async Task<IActionResult> GetAllUserReviews([FromQuery] FilterUserReviewsQuery query,bool bublis)
        {
            try
            {
                var reviews = await _mediator.Send(query);
                if (query.productId != null)
                {
                   
                    reviews = reviews.Where(r => r.ProductID == query.productId && r.Published ==true);
                    return Ok(reviews);

                }
                else
                {
                    return Ok("notfound");
                }

                //return Ok(reviews);

            }
            catch (Exception e)
            {
                return NotFound("Error 404!");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserReviewDetails([FromQuery] int? id)
        {
            if (id == null)
                return NotFound($"No ID with this {id}");
            try
            {
                return Ok(await _mediator.Send(new GetUserReviewDetailsQuery() { Id = id.Value }));

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
      
    }
}
