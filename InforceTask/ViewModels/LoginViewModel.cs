﻿using System.ComponentModel.DataAnnotations;

namespace InforceTestASP.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string? Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
