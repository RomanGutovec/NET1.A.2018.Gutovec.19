using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlLib.Interfaces;

namespace XmlLib
{
    /// <summary>
    /// Represents opportunity parse some type to another
    /// </summary>
    /// <typeparam name="TSource">Source type to convert</typeparam>
    /// <typeparam name="TResult">Result type of the conversation</typeparam>
    public class Mapper<TSource, TResult>
    {
        #region
        private readonly IParser<TSource, TResult> parser;
        private readonly IValidator validator;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialized instance of the Mapper class with specified parser's instance and validator instance
        /// </summary>
        /// <param name="parser">Type which can convert source type to result type </param>
        /// <param name="validator">Type which checks parameters</param>
        public Mapper(IParser<TSource, TResult> parser, IValidator validator)
        {
            this.parser = parser ?? throw new ArgumentNullException($"Parser {nameof(parser)} has no instance");
            this.validator = validator ?? throw new ArgumentNullException($"Validator {nameof(validator)} has no instance");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Converts type TSource into TResult
        /// </summary>
        /// <param name="source">Source type for conversation</param>
        /// <returns>Result type after the conversation</returns>
        public TResult MapSomethingInSomething(TSource source)
        {
            if (validator.Check(source.ToString()))
            {
                return parser.Parse(source);
            }

            return default(TResult);
        }
        #endregion
    }
}
