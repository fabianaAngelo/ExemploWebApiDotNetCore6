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
        public Exemplo(string nome)
        {
            CreateAt = DateTime.Now;
            Nome = nome;
            IsActive = true;    
        }
        public Exemplo()
        {

        }
    }
}
