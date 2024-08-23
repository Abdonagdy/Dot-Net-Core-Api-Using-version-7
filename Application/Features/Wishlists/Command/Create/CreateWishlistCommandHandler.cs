using Application.Contracts;
using Application.Contracts.Wishlist;
using DbContextL;
using Domian;
using Dtos.WishList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Wishlists.Command.Create
{
    public class CreateWishlistCommandHandler : IRequestHandler<CreateWishlistCommand, WishListResult>
    {
        private readonly IWishlistRepository wishlist;
        private readonly IProductRepository productRepository;
        private readonly IUserRepository userRepository;
        private readonly Context _context;


        public CreateWishlistCommandHandler(IWishlistRepository wishlist, IProductRepository productRepository, IUserRepository userRepository,Context context )
        {
            this.wishlist = wishlist;
            this.productRepository = productRepository;
            this.userRepository = userRepository;
            _context = context;
        }
        public async Task<WishListResult> Handle(CreateWishlistCommand request, CancellationToken cancellationToken)
        {


            var r = _context.WishLists.FirstOrDefault(a => a.User.Id ==request.Uid && a.Product.Id == request.Pid);
            if (r != null)
            {
                return new WishListResult { Result = "you are added it before" };
            }
            else
            { 
                var user =await this.userRepository.GetByIdAsync(request.Uid);

            var product =await this.productRepository.GetDetailsAsync(request.Pid);


            if (user == null)
            {
                throw new Exception("Saleh&Adel Not found user");
            }
            WishList wl = new WishList
            {
                User = user,
                Product = product!
            };

            await this.wishlist.CreateAsync(wl);

            return new WishListResult { Result="Done" };
            }
        }
    }
}
