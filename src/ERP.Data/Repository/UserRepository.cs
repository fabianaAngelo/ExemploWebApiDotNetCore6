using ERP.Business.Interfaces.Users;
using ERP.Business.Models;
using ERP.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext Db;
        protected readonly DbSet<IdentityUser> DbSet;

        public UserRepository(DataContext db)
        {
            Db = db;
            DbSet = db.Set<IdentityUser>();
        }

        //public async Task<IdentityUser> GetByIdWithPerson(Guid id)
        //{
        //    return await Db.ApplicationUsers.AsNoTracking()
        //        .Include(c => c.PhysicalPerson)
        //        .Include(c => c.JuridicalPerson)
        //        .Include(c => c.Sender)
        //        .SingleOrDefaultAsync(c => c.Id == id);
        //}

        //public async Task RemoveWithoutLogicaDeletion(IdentityUser applicationUser)
        //{
        //    DbSet.Remove(applicationUser);
        //    await Db.SaveChangesWithoutLogicaDeletionAsync();
        //}
    }
}
