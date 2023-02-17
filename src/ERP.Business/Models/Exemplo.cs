using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business.Models
{
    public class Exemplo : Entity
    {
        public DateTime? CreateAt { get; set; }
        public string Nome { get; set; }
        public Boolean IsActive { get; set; }
        public string CpfCnpj { get; set; }
        public TipoExemplo TipoDocumento { get; set; }

        public Exemplo(string nome, string cpfCnpj)
        {
            CreateAt = DateTime.Now;
            Nome = nome;
            IsActive = true;
            CpfCnpj = cpfCnpj;
            TipoDocumento = TipoExemplo.PessoaJuridica;
        }
        public Exemplo()
        {

        }
    }
}
