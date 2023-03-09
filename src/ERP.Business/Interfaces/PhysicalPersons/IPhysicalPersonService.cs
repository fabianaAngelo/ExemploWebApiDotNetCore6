using ERP.Business.Models;

namespace ERP.Business.Interfaces.PhysicalPersons
{
    public interface IPhysicalPersonService : IDisposable
    {
        Task<bool> Add(PhysicalPerson physicalPerson);

        Task Update(PhysicalPerson physicalPerson);
    }
}
