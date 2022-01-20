using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.Entities
{
    public class Profit : EntityBase
    {
        [Required]
        public float Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Order Order { get; set; }

        [Required]
        public Employee Employee { get; set; }

    }
}
