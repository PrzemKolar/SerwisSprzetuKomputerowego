using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.Entities
{
    public class Client : EntityBase
    {
        [Required]
        [MaxLength(30)]
        public string FirstNaem { get; set; }

        [Required]
        [MaxLength(60)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(9)]
        public string PhoneNumer { get; set; }

        [Required]
        [MaxLength(30)]
        public string Street { get; set; }

        [Required]
        public int HouseNumber { get; set; }

        public int ApartmentNumber { get; set; }

        [Required]
        public string PostCode { get; set; }

        public int Discount { get; set; }
    }
}
