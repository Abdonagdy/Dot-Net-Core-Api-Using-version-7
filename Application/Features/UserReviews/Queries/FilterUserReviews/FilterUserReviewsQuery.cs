using Dtos.UserReview;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.UserReviews.Queries.FilterUserReviews
{
    public class FilterUserReviewsQuery : IRequest<IEnumerable<UserReviewLargeDto>>
    {

        public int Id { get; set; }
        public string? Comment { get; set; }
        public int? RatingValue { get; set; }
        public DateTime? Date { get; set; }
        public int? userId { get; set; }
        public long? productId { get; set; }

        public Boolean? Published { get; set; }





    }
}
