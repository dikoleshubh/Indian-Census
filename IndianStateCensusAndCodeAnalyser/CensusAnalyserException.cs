using System;

namespace IndianStateCensusAndCodeAnalyser.POCO
{
    public class CensusAnalyserException : Exception
    {
        public enum ExceptionType //Exceptions in regards to parameters
        {
            FILE_NOT_FOUND, INVALID_FILE_TYPE, INCORRECT_DELIMITER, INCORRECT_HEADER, NO_SUCH_COUNTTY
        }
        public ExceptionType eType;
        public CensusAnalyserException(string message, ExceptionType exceptionType) : base(message)
        {
            this.eType = exceptionType;
        }
    }
}
