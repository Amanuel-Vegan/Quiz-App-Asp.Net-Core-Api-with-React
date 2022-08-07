using DataAccess;
using DataAccess.Data;

namespace BussinessLogic.Repository
{
    public class ParticipantRepository : GenericRepository<Questions>
    {
        public ParticipantRepository(AppDbContext context): base(context)
        {
     
        }
    }
}
