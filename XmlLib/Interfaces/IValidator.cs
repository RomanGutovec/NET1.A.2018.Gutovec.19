using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlLib.Interfaces
{
    public interface IValidator<in T>
    {
        bool Check(T elementTocheck);
    }
}
