using ERP.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business.Interfaces.PhysicalPersons
{
    public interface IPhysicalPersonService : IDisposable
    {
        Task<bool> Add(PhysicalPerson physicalPerson);

        Task Update(PhysicalPerson physicalPerson);
    }
}
