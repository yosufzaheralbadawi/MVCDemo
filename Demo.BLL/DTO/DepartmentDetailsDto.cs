using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DTO
{
    public class DepartmentDetailsDto
    {
        public int Id { get; set; } // PK
        public int CreatedBy { get; set; } // User ID
        public DateOnly CreatedOn { get; set; } // time of create
        public int LastModifiedON { get; set; } //User ID
        public bool IsDeleted { get; set; } //Soft Delete
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }

    }
}
