using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using XmlLib.Interfaces;

namespace XmlLib
{
    public class DataProcessor<TSource, TResult>
    {
        #region Fields
        private List<TSource> sourceElements;
        private List<TResult> resultElements;

        private IProvider<TSource> provider;
        private Mapper<TSource, TResult> mapper;
        private IStorage<TResult> storage;
        #endregion

        #region Constructors
        public DataProcessor(IProvider<TSource> provider, Mapper<TSource, TResult> mapper, IStorage<TResult> storage)
        {
            this.provider = provider ?? throw new ArgumentNullException(nameof(provider));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.storage = storage ?? throw new ArgumentNullException(nameof(storage));
            sourceElements = new List<TSource>();
            resultElements = new List<TResult>();
        }
        #endregion

        #region Methods
        public void Process()
        {
            sourceElements = provider.Load().ToList<TSource>();

            foreach (var item in sourceElements)
            {
                if (mapper.MapSomethingInSomething(item) != null)
                {
                    resultElements.Add(mapper.MapSomethingInSomething(item));
                }
            }

            storage.Write(resultElements);
        }
        #endregion
    }
}
