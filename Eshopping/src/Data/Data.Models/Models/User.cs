using Data.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models.Models
{
    public class User: BaseModel
    {
        [Required]
        [StringLength(13,MinimumLength ='4')]
        public string UserName{ get; set; }
        [Required]
        public string Password { get; set; }
    }
}
