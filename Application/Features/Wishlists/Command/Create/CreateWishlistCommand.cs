using Dtos.WishList;
using MediatR;

namespace Application.Features.Wishlists.Command.Create
{
    public class CreateWishlistCommand : IRequest<WishListResult>
    {
        public int Uid { get; set; }
        public long Pid { get; set; }

    }
}
