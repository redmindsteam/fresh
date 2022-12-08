using Fresh.Domain.Entities;

namespace Fresh.Service.Attributes
{
    public static class CurrentRegistrar
    {
        public static User Registrar { get; set; } = new User();
    }
}
