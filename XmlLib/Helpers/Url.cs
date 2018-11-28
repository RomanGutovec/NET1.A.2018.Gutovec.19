using System;
using System.Collections.Generic;

namespace XmlLib
{ 
    /// <summary>
    /// Represents 
    /// </summary>
    public class Url
    {
        #region Fields
        private string host;
        private List<string> segments;
        private Dictionary<string, string> parameters;
        #endregion

        #region Properties
        public string Host
        {
            get { return host; }
            set { host = value; }
        }

        public List<string> Segments
        {
            get { return segments; }
            set { segments = value; }
        }

        public Dictionary<string, string> Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }
        #endregion
    }
}
