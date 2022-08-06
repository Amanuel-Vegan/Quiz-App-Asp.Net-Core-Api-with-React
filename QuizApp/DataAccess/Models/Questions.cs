using System;


namespace DataAccess
{
    public class Questions
    {
        public Guid Id { get; set; }
        public string QnInWord { get; set; }
        public string ImageName { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }

        public Questions()
        {
            Id = Guid.NewGuid();
        }
    }
}
