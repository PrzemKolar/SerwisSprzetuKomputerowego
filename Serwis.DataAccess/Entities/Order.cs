using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.Entities
{
    public class Order : EntityBase
    {
        [Required]
        public Client Client { get; set; }

        public Employee Employee { get; set; }

        [Required]
        [MaxLength(250)]
        public string DeviceName { get; set; }

        [Required]
        [MaxLength(30)]
        public string DeviceSN { get; set; }

        [Required]
        public string DescriptionFault { get; set; }

        public string Diagnosis { get; set; }

        public float Price { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public List<OrderHistory> OrderHistories { get; set; }

        [Required]
        public List<Document> Documents { get; set; }
    }
}
