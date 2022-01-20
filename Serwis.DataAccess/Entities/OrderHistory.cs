using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.Entities
{
    public class OrderHistory : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Employee Employee { get; set; }

        [Required]
        public Order Order { get; set; }
    }
}
