using ERP.Business.Interfaces.BackOfficeUsers;
using ERP.Business.Models;
using ERP.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Data.Repository
{
    public class BackOfficeUserRepository : Repository<BackOfficeUser>, IBackOfficeUsersRepository
    {
        public BackOfficeUserRepository(DataContext db) : base (db)
        {

        }
    }
}
