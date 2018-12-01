using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using XmlLib.Helpers;
using XmlLib.Interfaces;

namespace XmlLib.DependencyResolver
{

    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IProvider<string>>().To<UriStringDataProvider>().WithConstructorArgument("source.txt");
            Bind<IParser<string, Url>>().To<ToUrlParser>();
            Bind<IStorage<Url>>().To<XMLStorage>().WithConstructorArgument("resultURLS.xml");
            Bind<IValidator<string>>().To<UriValidator>();
           
        }
    }

}
