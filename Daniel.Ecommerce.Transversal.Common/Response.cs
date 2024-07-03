using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daniel.Ecommerce.Transversal.Common
{
    // objeto generico usado como molde para resepresentar los datos y respuesta de nuesto programa
    public class Response<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
