﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AryarajsinhHarma_0516_Models.ViewModels
{
   public  class RegisterModel
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^\S+@\S+\.\S+$", ErrorMessage = "Please enter valid Email Id")]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Please Add one Uppercase ,One LowerCase ,One Digit ,One Special Character And Should be 8 haracters")]
        public string password { get; set; }
        [Required]
        [Compare("password",ErrorMessage ="Please Enter Currect Conform Password")]
        public string conformpassword { get; set; }
        public string Token { get; set; }
    }
}