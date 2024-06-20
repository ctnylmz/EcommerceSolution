using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shareds.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Base64Img { get; set; }
        [Required,Range(1,99999)]
        public int Quantity { get; set; }
        public bool Featured { get; set; } = false; 
        public DateTime DateUploaded { get; set; } = DateTime.Now;
    }
}
