using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using XmlLib.Interfaces;

namespace XmlLib
{
    /// <summary>
    /// Represents opportunity to check specified uri
    /// </summary>
    public class UriValidator : IValidator<string>
    {
        /// <summary>
        /// Checks specified url address
        /// </summary>
        /// <param name="stringUrl">String representation of the url address</param>
        /// <returns>Boolean value(true if the url is correct)</returns>
        public bool Check(string stringUrl)
        {
            if (stringUrl == null)
            {
                return false;
            }

            return Uri.IsWellFormedUriString(stringUrl, UriKind.Absolute);
        }
    }
}