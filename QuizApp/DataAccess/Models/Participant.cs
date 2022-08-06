using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Participant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Score { get; set; }
        public int TimeTaken { get; set; }
        public Participant()
        {
            Id = Guid.NewGuid();
        }
    }
}
