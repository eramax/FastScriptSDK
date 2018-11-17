using System;
using System.ComponentModel.DataAnnotations;
using DbManager.Models;

namespace ApiApp1.Models
{
    public class Animal : BaseEntity<Int64>
    {
        [Required]
        public string AnimalName { get; set; }

        [Required]
        public Int64 Barcode { get; set; }
    }
}