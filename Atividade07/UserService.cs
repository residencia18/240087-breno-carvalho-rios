using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade07
{
    public class UserService
    {
        private readonly IDatabase _db;

        public UserService(IDatabase db)
        {
            _db = db;
        }

        public void SaveUser(User user)
        {
            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email))
            {
                throw new ArgumentException("User must have a name and email");
            }
            _db.SaveUser(user);
        }
    }
}
