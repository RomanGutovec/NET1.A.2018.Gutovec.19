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
    public class XMLStorage : IStorage
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
        public void Write(XDocument documentToWrite)
        {
            documentToWrite.Save(pathToWrite);
        }
        #endregion
    }
}
