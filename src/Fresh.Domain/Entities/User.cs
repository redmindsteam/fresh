using Fresh.Domain.Common;

namespace Fresh.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool IsAdmin { get; set; }

        public string PasswordHash { get; set; } = string.Empty;

        public string Salt { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string PassportSeria { get; set; } = string.Empty;
    }
}
