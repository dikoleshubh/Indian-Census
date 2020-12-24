using System;
using IndianStateCensusAndCodeAnalyser.POCO;
using System.Collections.Generic;

namespace IndianStateCensusAndCodeAnalyser
{
    public class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvfilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensus().LoadCensusData(csvfilePath, dataHeaders);
                default:
                    throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTTY);
            }
        }
    }
}
