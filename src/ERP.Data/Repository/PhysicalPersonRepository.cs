using ERP.Business.Interfaces.PhysicalPersons;
using ERP.Business.Models;
using ERP.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Data.Repository
{
    public class PhysicalPersonRepository : Repository<PhysicalPerson>, IPhysicalPersonRepository
    {
        public PhysicalPersonRepository(DataContext db) : base(db)
        {
        }
    }
}
