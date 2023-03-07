using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Business.Models
{
    public class BackOfficeUser : Entity
    {
        public DateTime? CreateAt { get; set; }
        public string Nome { get; set; }
        public Boolean IsActive { get; set; }
        public BackOfficeUser(string nome)
        {
            CreateAt = DateTime.Now;
            Nome = nome;
            IsActive = true;
        }
        public BackOfficeUser()
        {

        }
    }
}
