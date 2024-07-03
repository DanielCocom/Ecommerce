using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daniel.Ecommerce.Domain.Entity
{
    public class Usuario
    {
        public string nombreUsuario { get; set; }
        public string contraseña { get; set;}
        public string token { get; set;}
    }
}
