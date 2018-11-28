using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlLib.Interfaces;

namespace XmlLib
{
    /// <summary>
    /// Represents class-converter from string to Url class
    /// </summary>
    public class XMLDataProcessor : DataProcessor<string, Url>
    {
        #region Constructors
        /// <summary>
        /// Initialize instance of the class XMLDataProcessor
        /// </summary>
        /// <param name="provider">Represents opportunity to load information</param>
        /// <param name="mapper">Converter from string to url</param>
        /// <param name="storage">Storage for the Xml document</param>
        public XMLDataProcessor(IProvider<string> provider, Mapper<string, Url> mapper, IStorage storage) :
            base(provider, mapper, storage)
        {
        }
        #endregion

        #region Overrided methods
        /// <summary>
        /// Creates Xml document from the list of the url list
        /// </summary>
        /// <param name="urls">List of the url addresses</param>
        /// <returns>Instance of the Xml document</returns>
        protected override XDocument CreateDocument(IEnumerable<Url> urls)
        {
            XElement urlAdresses = new XElement("urlAddresses");
            foreach (var item in urls)
            {
                urlAdresses.Add(this.CreateElementDocument(item));
            }

            XDocument xDocument = new XDocument(urlAdresses);
            return xDocument;
        }

        /// <summary>
        /// Creates Xml element for the Xml document from the url address
        /// </summary>
        /// <param name="url">Url address as string</param>
        /// <returns>Element of the Xml document</returns>
        protected override XElement CreateElementDocument(Url url)
        {
            XElement uri = new XElement("uri");
            foreach (var item in url.Segments)
            {
                uri.Add(new XElement("segment", item));
            }

            XElement parameters = new XElement("parameters");
            foreach (var item in url.Parameters)
            {
                parameters.Add(new XElement("parameter", new XAttribute("value", item.Value), new XAttribute("key", item.Key)));
            }

            XElement urlAdress = new XElement(
                        "urlAdress",
                        new XElement("host", new XAttribute("name", url.Host)),
                        uri,
                        parameters);

            return urlAdress;
        }
        #endregion
    }
}
