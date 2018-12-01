using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using Ninject;
using XmlLib;
using XmlLib.DependencyResolver;
using XmlLib.Helpers;
using XmlLib.Interfaces;

namespace XmlLibConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel ninjectKernel = new StandardKernel(new Bindings());
            DataProcessor<string,Url> processor = ninjectKernel.Get<DataProcessor<string, Url>>();
            
            Validation("newresult.xml", "AddressesSchema.xsd");
            Console.ReadLine();
        }

        private static void Validation(string pathXML, string pathSchemaXSD)
        {
            XDocument doc = XDocument.Load(pathXML);
            XmlSchemaSet set = new XmlSchemaSet();
            set.Add(null, pathSchemaXSD);
            StringBuilder errors = new StringBuilder();
            doc.Validate(set, (sender, args) =>
            {
                errors.AppendLine(args.Exception.Message);
            }
                         );
            Console.WriteLine(errors.ToString());
        }
    }
}
