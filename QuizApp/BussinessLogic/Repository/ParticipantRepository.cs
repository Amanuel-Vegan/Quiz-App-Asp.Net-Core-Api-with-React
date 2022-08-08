using DataAccess;
using DataAccess.Data;
using DataAccess.Models;

namespace BussinessLogic.Repository
{
    public class ParticipantRepository : GenericRepository<Participant>
    {
        public ParticipantRepository(AppDbContext context): base(context)
        {
     
        }
    }
}
