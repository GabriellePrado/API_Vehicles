using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_API_Vehicles.Models.Exceptions
{
    public class Exceptions : Exception
    {
        public Exceptions(string message) : base(message)
        {

        }
    }
}
