namespace TeachMe.Data.Services
{
    using Contracts;
    using System.Linq;
    using System;
    using Models;
    using Repositories;
    public class UsersService : IUsersService
    {
        private IRepository<User> users;

        public UsersService(IRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public int GetCount()
        {
            return this.users.All().Count();
        }
    }
}
