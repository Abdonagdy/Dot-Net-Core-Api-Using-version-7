using Application.Contracts;
using Dtos.UserReview;
using MediatR;

namespace Application.Features.UserReviews.Queries.FilterUserReviews
{
    public class FilterUserReviewsQueryHandler : IRequestHandler<FilterUserReviewsQuery, IEnumerable<UserReviewLargeDto>>
    {
        private readonly IUserReviewRepository _userReviewRepository;

        public FilterUserReviewsQueryHandler(IUserReviewRepository userReviewRepository)
        {
            _userReviewRepository = userReviewRepository;
        }
        public async Task<IEnumerable<UserReviewLargeDto>> Handle(FilterUserReviewsQuery request, CancellationToken cancellationToken)
        {
            var results = await _userReviewRepository.FilterByAsync();
            if (results != null)
            {
                return (results).Select(x => new UserReviewLargeDto
                {
                    Comment = x.Comment,
                    RatingValue = x.RatingValue,
                    Date = x.Date,
                    ProductID = x.Product.Id,
                    UserName = x!.User!.UserName!,
                    UserId = x.userdId,
                    Published = x.Published
                }) ; 

            }
            else
                throw new Exception("No Reviews");
        }
    }
}
