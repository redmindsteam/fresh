using Fresh.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.Attributes
{
    public sealed class CurrentUserSingelton
    {
        private CurrentUserSingelton() { }
        private static User _currentUser = null;

        public static User Instance
        {
            get { return _currentUser; }
            set
            {
                if (_currentUser == null)
                    _currentUser = value;
            }
        }
    }
}
