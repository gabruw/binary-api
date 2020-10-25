using Domain.Entity;
using Domain.IRepository;
using Repository.Context;

namespace Repository.Repository
{
    public class DiffLeftRepository : BaseRepository<DiffLeft>, IDiffLeftRepository
    {
        public DiffLeftRepository(ApiContext apiContext) : base(apiContext)
        {

        }
    }
}