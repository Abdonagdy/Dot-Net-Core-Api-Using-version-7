using Domian;

namespace Application.Contracts
{
    public interface IUserReviewRepository : IRepository<UserReview, int>
    {
        Task<IEnumerable<UserReview>> FilterByAsync();

    }
}
