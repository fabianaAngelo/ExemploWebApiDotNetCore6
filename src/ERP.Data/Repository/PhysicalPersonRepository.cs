using ERP.Business.Interfaces.PhysicalPersons;
using ERP.Business.Models;
using ERP.Data.Context;

namespace ERP.Data.Repository
{
    public class PhysicalPersonRepository : Repository<PhysicalPerson>, IPhysicalPersonRepository
    {
        public PhysicalPersonRepository(DataContext db) : base(db)
        {
        }
    }
}
