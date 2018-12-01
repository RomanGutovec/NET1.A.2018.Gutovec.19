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
    /// Represents classstorage for Xml documents
    /// </summary>
    public class XMLStorage : IStorage<Url>
    {
        #region Fields
        private readonly string pathToWrite;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialized instance of storage to keep Xml documents
        /// </summary>
        /// <param name="pathToWrite">Path in whic would like to write Xml documents</param>
        public XMLStorage(string pathToWrite)
        {
            this.pathToWrite = pathToWrite ?? throw new ArgumentNullException($"Path {nameof(pathToWrite)} has null value");
        }
        #endregion

        #region Implementations
        /// <summary>
        /// Writes XDocument to the specified path
        /// </summary>
        /// <param name="documentToWrite">Xml document to write</param>
        public void Write(IEnumerable<Url> urls)
        {
            XDocument documentToWrite = CreateDocument(urls);
            documentToWrite.Save(pathToWrite);
        }


        //можно объединить
        public XDocument CreateDocument(IEnumerable<Url> urls)
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
        private XElement CreateElementDocument(Url url)
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