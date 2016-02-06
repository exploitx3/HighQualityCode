namespace BangaloreUniversityLearningSystem.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;

    public class UsersRepository : Repository<User>, IUsersRepository
    {
        private readonly IDictionary<string, User> users;

        public UsersRepository()
        {
            this.users = new Dictionary<string, User>();
        }

        public User GetByUsername(string username)
        {
            return this.users.ContainsKey(username) ? this.users[username] : null;
        }

        public override void Add(User item)
        {
            this.users.Add(item.Username, item);
            base.Add(item);
        }
    }
}
