using Application.Contracts;
using DbContextL;
using Domian;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure
{
    public class UserReviewRepository : Repository<UserReview, int>, IUserReviewRepository
    {
        public UserReviewRepository(Context context) : base(context)
        {

        }

        public  async Task<IEnumerable<UserReview>> FilterByAsync()
        {
            var result= _context.UserReviews.Include(a=>a.Product).Include(a=>a.User).ToList();
            return  result;
        }
    }

}
