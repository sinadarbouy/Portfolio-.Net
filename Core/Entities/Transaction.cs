using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Transaction
    {
        public long Id { get; set; }
        public Guid FromUserID { get; set; }
        public Guid ToUserID { get; set; }
        public decimal Amount { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string Transactionnumber { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime DeletedDatetime { get; set; }


    }
}
