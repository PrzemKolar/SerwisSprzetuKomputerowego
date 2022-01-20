using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.Entities
{
    public class Regulation : EntityBase
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }

    }
}
