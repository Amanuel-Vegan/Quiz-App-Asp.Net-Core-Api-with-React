using DataAccess;
using DataAccess.Data;

namespace BussinessLogic.Repository
{
    public class QuestionRepository : GenericRepository<Questions>
    {
        public QuestionRepository(AppDbContext context): base(context)
        {
     
        }
    }
}
