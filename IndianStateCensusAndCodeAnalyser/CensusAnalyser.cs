using System;
using System.Collections.Generic;
using IndianStateCensusAndCodeAnalyser.POCO;

namespace IndianStateCensusAndCodeAnalyser
{
    public class CensusAnalyser
    {
        public enum Country
        {
            INDIA, US, BRAZIL
        }
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvfilePath, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvfilePath, dataHeaders);
            return dataMap;
        }
    }
}
