using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infolimpiadas.Domain.Entity
{
    public class LoginRequestCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
