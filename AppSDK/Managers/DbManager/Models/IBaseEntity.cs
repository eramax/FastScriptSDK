using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Models
{
    public interface IBaseEntity
    {
        object Id { get; set; }
        DateTime CreatedDate { get; set; }
        int CreatedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        int? ModifiedBy { get; set; }
        DateTime? DeletedDate { get; set; }
        int? DeletedBy { get; set; }
        int Version { get; set; }
        int? Status { get; set; }
    }
    public interface IBaseEntity<PK> : IBaseEntity
    {
        new PK Id { get; }
    }
}
