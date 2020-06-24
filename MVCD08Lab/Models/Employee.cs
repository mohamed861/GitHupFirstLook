using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace MVCD08Lab.Models
{
    public class Employee
    {
        [Key]
        [Display(Name ="SSN")]
        
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage ="first name is required")]
        public string Fname { get; set; }

        [Display(Name = "Last Name")]
        public string Lname { get; set; }

        [Range(18,60,ErrorMessage ="age must between 18 and 60")]
        public int? Age { get; set; }

        public int Salary { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="password is required")]
        public string Pwd { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "confirm password is required")]
        [Compare("Pwd",ErrorMessage ="does npt match")]
        [NotMapped]
        public string ConPwd { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Unvalid Email")]
        [Required(ErrorMessage ="enter email address")]
        [Remote("chkEmail","Employee",ErrorMessage ="email is used before")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Blog URL")]
        [DataType(DataType.Url,ErrorMessage ="unvalid Url")]
        public string URL { get; set; }

        [Display(Name = "Birthdate")]
        [DataType(DataType.Date,ErrorMessage ="unvalid date")]
        [Required(ErrorMessage ="date is required field")]
        public DateTime? DOB { get; set; }

        [Display(Name = "Hiredate")]
        [DataType(DataType.Date,ErrorMessage ="unvalid date")]
        [Required(ErrorMessage = "date is required field")]
        public DateTime? DOH { get; set; }

        [Display(Name ="Phone Number")]
        [DataType(DataType.PhoneNumber,ErrorMessage ="unvalid phone number")]
        [Required(ErrorMessage ="phone number is required")]
        [Remote("chkPhone","Employee", ErrorMessage ="phone number used before")]
        [RegularExpression("[0-9]{3}-[0-9]{3}-[0-9]{3}",ErrorMessage ="follow the stamp:***-***-***")]
        public string Phone { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public virtual Department Department { get; set; }
    }
}
