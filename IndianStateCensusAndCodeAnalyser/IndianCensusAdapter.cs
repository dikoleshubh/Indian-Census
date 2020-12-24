using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using IndianStateCensusAndCodeAnalyser.POCO;

namespace IndianStateCensusAndCodeAnalyser
{
    public class IndianCensus : CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvfilePath, string dataHeaders)
        {
            dataMap = new Dictionary<string, CensusDTO>();
            censusData = GetCensusData(csvfilePath, dataHeaders);
            foreach (string data in censusData.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File Contains wrong Delimeter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
                string[] column = data.Split(",");
                if (csvfilePath.Contains("IndianStateCode.csv"))
                {
                    dataMap.Add(column[0], new CensusDTO(new StateCodeDAO(column[0], column[1], column[2], column[3])));
                }
                if (csvfilePath.Contains("IndianStateCensusData.csv"))
                {
                    dataMap.Add(column[0], new CensusDTO(new CensusDataDAO(column[0], column[1], column[2], column[3])));
                }
            }
            return dataMap.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
