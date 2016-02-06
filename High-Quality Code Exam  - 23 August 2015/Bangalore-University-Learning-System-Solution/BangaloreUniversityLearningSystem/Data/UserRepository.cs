namespace BangaloreUniversityLearningSystem.Data
{
    using System.Collections.Generic;
    using Models;

    public class UsersRepository : Repository<User>
    {
        private Dictionary<string, User> usersByUsername;

        public UsersRepository()
        {
            this.usersByUsername = new Dictionary<string, User>();
        }

        public User GetByUsername(string username)
        {
            return this.usersByUsername.ContainsKey(username) ? this.usersByUsername[username] : null;
        }

        public override void Add(User item)
        {
            this.usersByUsername.Add(item.Username, item);
            base.Add(item);
        }
    }
}
