using Fresh.Domain.Entities;

namespace Fresh.Service.Attributes
{
    public sealed class CurrentUserSingelton
    {
        public CurrentUserSingelton() { }
        public static User _currentUser = null;

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
