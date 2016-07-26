using System;
using System.ComponentModel.DataAnnotations;

namespace MediaLogSite.Models
{
    public class UserMetadata
    {
        [StringLength(50)]
        [Display(Name = "User Name")]
        public string UserName;

        [StringLength(50)]
        [Display(Name = "Email")]
        [Required]
        public string Email;

        [StringLength(20, MinimumLength = 8)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required]
        public string Password;
    }

    public class LogMetadata
    {
        [StringLength(50)]
        [Display(Name = "Title")]
        public string Title;

        [Range(0, 10)]
        [Display(Name = "Rating")]
        public Nullable<decimal> Rating;

        [Range(0, 1000)]
        [Display(Name = "Time")]
        public Nullable<decimal> Time;
    }
}