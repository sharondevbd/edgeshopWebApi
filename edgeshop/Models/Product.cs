using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace edgeshop.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal ProductPrice { get; set; }
        public string ProductModel { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public string? ProductPicturePath { get; set; }
        [ForeignKey("Catagory")]
        public int CatagoryId { get; set; }
        [ValidateNever]
        public Catagory? Catagory { get; set; } = null!;
    }
}
