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
        public enum StatusEnum
        {
            inQueue,
            inDiagnosis,
            waitingForTheClientDecision,
            inRepair,
            Repaired,
            Closed,
            Resigned
        }

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

        public float PayedPrice { get; set; }

        [Required]
        public StatusEnum RepairStatus { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public List<OrderHistory> OrderHistories { get; set; }

        public List<Document> Documents { get; set; }
    }
}
