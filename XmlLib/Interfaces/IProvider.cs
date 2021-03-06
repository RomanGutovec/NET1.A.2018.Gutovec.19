﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlLib.Interfaces
{
    public interface IProvider<out TSource>
    {
        IEnumerable<TSource> Load();
    }
}
