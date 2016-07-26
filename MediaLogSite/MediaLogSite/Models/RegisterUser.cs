using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace MediaLogSite.Models
{
    using System;
    using System.Collections.Generic;

    public partial class RegisterUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RegisterUser()
        {
            
        }

        public int UserID { get; set; }
        [StringLength(50)]
        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }
        [StringLength(50)]
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 8)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [StringLength(20, MinimumLength = 8)]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Required]
        [Compare("Password",
            ErrorMessage = "The password and confirmation password do not match.")]
        public string Confirm { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Log> Logs { get; set; }
    }
}