using ERP.Business.Interfaces.Exemplos;
using ERP.Business.Models;
using ERP.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Data.Repository
{
    public class ExemploRepository : Repository<Exemplo>, IExemploRepository
    {
        public ExemploRepository(DataContext db) : base (db)
        {

        }
    }
}
