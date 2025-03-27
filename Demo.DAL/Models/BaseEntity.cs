using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class BaseEntity
    {
        public int Id { get; set; } // PK
        public int CreatedBy { get; set; } // User ID
        public DateTime? CreatedOn { get; set; } // time of create

        public int LastModifiedON { get; set; } //User ID

        public DateTime? LastModifiedOn { get; set; } // Time of Create

        public bool IsDeleted { get; set; } //Soft Delete



    }
}
