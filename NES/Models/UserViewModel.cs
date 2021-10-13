using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NES.Models
{
    public class UserViewModel
    {
        public int UserID { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = "Required field!")]
        //[RegularExpression(@"/^[a-z0-9_-]{4,16}$/", ErrorMessage = "Length 4-16 chars, letters, numbers or dashes!")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Must be from 4 to 50 characters long!")]
        [RegularExpression(@"^[\w\-. ]+$", ErrorMessage = "Special Characters are not allowed!")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        //[RegularExpression(@"/^[a-z0-9_-]{3,16}$/", ErrorMessage = "Strong password! Min. length 6 chars, must contain: 1 uppercase letter, 1 lowercase letter, 1 number, 1 special character!")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Must be from 4 to 50 characters long!")]
        [Required(ErrorMessage = "Required field!")]
        public string Password { get; set; }

        [DisplayName("First Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be from 2 to 50 characters long!")]
        [Required(ErrorMessage = "Required field!")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be from 2 to 50 characters long!")]
        [Required(ErrorMessage = "Required field!")]
        public string LastName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Note { get; set; }

        [DisplayName("Role")]
        [Required(ErrorMessage = "Required field!")]
        public int RoleID { get; set; }

        public string RoleName { get; set; }

        [DisplayName("Date Created")]
        [DataType(DataType.Date)]
        //[RegularExpression(@"/^((0[1-9]|[12][012345678]|19)\.(0[1-9]|1[012])|29\.(0[13-9]|1[012])|30\.(0[13-9]|1[012])|31\.(0[13578]|1[02]))\.(19|20)\d\d|29\.02\.(19|20)([02468][048]|[13579][26])$/", ErrorMessage = "Date format: dd.mm.yyyy!")]
        //[StringLength(10, MinimumLength = 10, ErrorMessage = "Must be dd.mm.yyyy!")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yy}")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateCreated { get; set; }

        [DisplayName("Activated?")]
        public Nullable<bool> IsActivated { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; }

        [DisplayName("Org. Unit")]
        public Nullable<int> OrgUnitID { get; set; }

        public string OrgUnitName { get; set; }

        [DisplayName("Department")]
        public Nullable<int> DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        [DisplayName("Position")]
        public Nullable<int> PositionID { get; set; }

        public string PositionName { get; set; }
    }
}