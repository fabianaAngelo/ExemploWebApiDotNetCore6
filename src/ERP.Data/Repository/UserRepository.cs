using ERP.Business.Interfaces.Users;
using ERP.Business.Models;
using ERP.Data.Context;
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
        protected readonly DbSet<ApplicationUser> DbSet;

        public UserRepository(DataContext db)
        {
            Db = db;
            DbSet = db.Set<ApplicationUser>();
        }
    }
}
