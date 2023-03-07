using ERP.Api.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Api.ViewModels.BackOfficeUsers
{
    public class BackOfficeUserCreateViewModel
    {
        public DateTime? CreateAt { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
    }
}
