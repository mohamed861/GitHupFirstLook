using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCD08Lab.Models
{
    public class Department
    {
        public Department()
        {
            this.Employees = new HashSet<Employee>();
        }
        [Key]
        public int DeptId { get; set; }
        [Display(Name ="Department Name")]
        public string DeptName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
