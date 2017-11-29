﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Deneme1MVC.Models
{
    public class Register
    {
        [Required]

        [Display(Name = "Ad")]

        public string Ad { get; set; }



        [Required]

        [Display(Name = "Soyad")]

        public string Soyad { get; set; }



        [Required]

        [Display(Name = "Kullanıcı Adı")]

        public string Username { get; set; }



        [Required]

        [EmailAddress]

        public string Email { get; set; }



        [Required]

        [Display(Name = "Şifre")]

        public string Password { get; set; }



        [Required]

        [Display(Name = "Şifre Tekrar")]

        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]

        public string ConfirmPassword { get; set; }
    }
}