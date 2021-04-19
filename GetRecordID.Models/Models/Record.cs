using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetRecordID.Models.Models
{
    public class Record
    {
        public string BogusName { get; set; }
        public string CourtDate { get; set; }
        public decimal AmountOwed { get; set; }
        public Guid RecordId { get; set; }
    }
}
