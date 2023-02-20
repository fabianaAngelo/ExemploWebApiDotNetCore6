using ERP.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace ERP.Api.ViewModels.Exemplos
{
    public class ExemploViewModel
    {
        [Key]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Id { get; set; }
        public DateTime? CreateAt { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CpfCnpj { get; set; }

    }
}
