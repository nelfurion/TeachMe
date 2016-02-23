//namespace TeachMe.Data.Services
//{
//    using System.Linq;
//    using Contracts;
//    using TeachMe.Data.Common;
//    using TeachMe.Data.Models;

//    public class UsersService : IUsersService
//    {
//        private IDbRepository<ApplicationUser> users;

//        public UsersService(IDbRepository<ApplicationUser> users)
//        {
//            this.users = users;
//        }

//        public IQueryable<ApplicationUser> GetAll()
//        {
//            return this.users.All();
//        }

//        public int GetCount()
//        {
//            return this.users.All().Count();
//        }
//    }
//}
