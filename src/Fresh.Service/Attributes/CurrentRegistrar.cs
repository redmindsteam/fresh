using Fresh.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Service.Attributes
{
    public static class CurrentRegistrar
    {
        public static User Registrar { get; set; } = new User();
    }
}
