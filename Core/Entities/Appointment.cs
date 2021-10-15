using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Appointment
    {
        public long id { get; set; }
        public Guid UserId { get; set; }
        public int CourseId { get; set; }
        public int MentorId { get; set; }
        public long TransactionID { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public bool IsPaid { get; set; }
        public DateTime PaidDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedDateTime { get; set; }
    }
}
