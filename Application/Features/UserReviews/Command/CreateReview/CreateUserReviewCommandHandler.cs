using Application.Contracts;
using DbContextL;
using Domian;
using Dtos.UserReview;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Runtime.InteropServices;

namespace Application.Features.UserReviews.Command.CreateReview
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateUserReviewCommand, UserReviewLargeDto>
    {
        private readonly IUserReviewRepository _userReviewRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository userRepository;
        private readonly UserManager<User> _userManager;
        private readonly Context _context;
        public CreateAppointmentCommandHandler(IUserReviewRepository userReviewRepository,
            IProductRepository productRepository, IUserRepository userRepository, UserManager<User> userManager, Context context)
        {
            _userReviewRepository = userReviewRepository;
            _productRepository = productRepository;
            this.userRepository = userRepository;
            _userManager = userManager;
            _context = context;
        }
        public async Task<UserReviewLargeDto> Handle(CreateUserReviewCommand request, CancellationToken cancellationToken)
        {

            var r = _context.UserReviews.FirstOrDefault(a => a.userdId == request.UserId && a.ProdcutId == request.ProductId);

            if (r == null)
            {

                UserReview ur = new UserReview
                {
                    Comment = request.Comment!,
                    RatingValue = request.RatingValue,
                    Date = DateTime.Now,
                    ProdcutId = request.ProductId,
                    userdId = request.UserId,
                    Published=false
                };

                await _userReviewRepository.CreateAsync(ur);
                var user = await _userManager.FindByIdAsync(request.UserId.ToString());
                return new UserReviewLargeDto
                {
                    Comment = request.Comment,
                    RatingValue = request.RatingValue,
                    Date = ur.Date,
                    UserName = user!.UserName!,
                    ProductID = request.ProductId,
                    UserId = request.UserId,

                };
            }
            else
            {
                return new UserReviewLargeDto { Comment = "لقد قمت بعمل تعليق من قبل" };
            }






        }
    }
}
