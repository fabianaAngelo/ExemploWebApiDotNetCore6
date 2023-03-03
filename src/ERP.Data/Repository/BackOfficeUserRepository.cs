using ERP.Business.Interfaces.BackOfficeUsers;
using ERP.Business.Models;
using ERP.Data.Context;

namespace ERP.Data.Repository
{
    public class BackOfficeUserRepository : Repository<BackOfficeUser>, IBackOfficeUserRepository
    {
        public BackOfficeUserRepository(DataContext db) : base(db)
        {
        }
    }
}
