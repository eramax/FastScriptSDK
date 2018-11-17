using System;
using System.ComponentModel.DataAnnotations;
using DbManager.Models;
namespace ApiApp1.Models
{
    public class Movie : BaseEntity<Int64>
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int CateogryId { get; set; }
        public Cateogry Cateogry { get; set; }
    }

    public class Cateogry : BaseEntity<int>
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}