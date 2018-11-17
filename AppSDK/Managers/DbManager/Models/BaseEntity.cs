using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DbManager.Models
{
    public abstract class BaseEntity<PK> : IBaseEntity<PK>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public PK Id { get; set; }
        object IBaseEntity.Id
        {
            get => this.Id;
            set => this.Id = (PK)value;
        }

        public int CreatedBy { get; set; }

        private DateTime? createdDate;
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get => createdDate ?? DateTime.UtcNow;
            set { createdDate = value; }
        }

        public int? ModifiedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }

        public int? DeletedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedDate { get; set; }

        public int Version { get; set; }

        public int? Status { get; set; }
    }
}