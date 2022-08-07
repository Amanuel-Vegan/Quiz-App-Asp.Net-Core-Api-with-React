using System;

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
