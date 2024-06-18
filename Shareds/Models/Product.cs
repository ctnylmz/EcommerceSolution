using System;
using System.Collections.Generic;
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
        public int Quantity { get; set; }
        public bool Featured { get; set; }
        public DateTime DateUploaded { get; set; }
    }
}
