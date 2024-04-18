using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace edgeshop.Models
{
    public partial class Catagory
    {
        public Catagory()
        {
            Products = new HashSet<Product>();
        }

        public int CatagoryId { get; set; }
        public string CatagoryName { get; set; } = null!;
        public string? CatagoryPicturePath { get; set; }
        public virtual ICollection<Product> Products { get; set; }=new List<Product>();
    }
}
