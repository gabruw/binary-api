using Domain.Entity;
using Domain.IRepository;
using Repository.Context;

namespace Repository.Repository
{
    public class DiffRightRepository : BaseRepository<DiffRight>, IDiffRightRepository
    {
        public DiffRightRepository(ApiContext apiContext) : base(apiContext)
        {

        }
    }
}