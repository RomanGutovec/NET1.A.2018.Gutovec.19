using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlLib.Interfaces
{
    public interface IStorage<in T>
    {
        void Write(IEnumerable<T> items);
    }
}
