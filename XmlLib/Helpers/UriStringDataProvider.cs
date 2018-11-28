using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlLib.Interfaces;

namespace XmlLib
{
    /// <summary>
    /// 
    /// </summary>
    public class UriStringDataProvider : IProvider<string>
    {
        #region Fields
        private List<string> pathList;
        private string path;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the UriStringDataProvider class that
        /// has the specified initial path.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when path has null value</exception>
        /// <param name="path">Path from which will read data</param>
        public UriStringDataProvider(string path)
        {
            this.path = path ?? throw new ArgumentNullException($"Path {nameof(path)} has null value");
            pathList = new List<string>();
        }
        #endregion

        #region Implementations
        /// <summary>
        /// Loads data from text file
        /// </summary>
        /// <returns>String collection of not validated url addresses</returns>
        public IEnumerable<string> Load()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    pathList.Add(line);
                }
            }

            return pathList;
        }
        #endregion
    }
}
