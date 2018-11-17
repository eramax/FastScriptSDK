using DbManager.DAL;
using DbManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Models
{
    public class Movie : BaseEntity<Int64>
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int CateogryId { get; set; }
        public virtual Cateogry Cateogry { get; set; }

        //[NotMapped]
        //public virtual IEnumerable<SelectListItem> CateogryOptions
        //{
        //    get
        //    {
        //        var cats = new GenericRepository<Cateogry>(new DbxContext()).Entities();
        //        return new SelectList(cats, "Id", "Name").AsEnumerable();
        //    }
        //}
    }

    public class Cateogry : BaseEntity<int>
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}