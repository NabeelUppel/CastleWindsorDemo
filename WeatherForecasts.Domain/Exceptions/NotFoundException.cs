using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeatherForecasts.Domain.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException(){}

        public NotFoundException(string ex) :base(String.Format("Entity Not Found: {0}", ex)) {}

    }
}
