using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhamacyOn.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string PrescriptionPhotoPath { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public double TotalPrice { get; set; }
    }
}
