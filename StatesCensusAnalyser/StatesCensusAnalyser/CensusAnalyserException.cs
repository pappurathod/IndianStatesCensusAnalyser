using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesCensusAnalyser
{
    public class CensusAnalyserException : Exception
    {
        public ExceptionType type;
        public enum ExceptionType
        {
            FILE_NOT_EXISTS,
            IMPROPER_EXTENSION,
            DELIMITER_NOT_FOUND,
            INCORRECT_HEADER
        }
        public CensusAnalyserException(ExceptionType type, string name) :base(name)
        {
            this.type = type;
        }
    }
}
