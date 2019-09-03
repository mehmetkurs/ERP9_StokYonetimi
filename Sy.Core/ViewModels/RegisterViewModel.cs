using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sy.Core.Abstracts;

namespace Sy.Core.ViewModels
{
    class RegisterViewModel
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(50)]

        public string Surname { get; set; }
        [Required, StringLength(50)]

        public string Password { get; set; }

        [Required, StringLength(50)]
        public string Email { get; set; }
    }
}
