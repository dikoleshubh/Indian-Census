using NUnit.Framework;
using IndianStateCensusAndCodeAnalyser.POCO;
using System.Collections.Generic;
using static IndianStateCensusAndCodeAnalyser.CensusAnalyser;

namespace IndianStateCensusAndCodeAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeader = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCesusFilePath = @"C:\Users\HP\source\repos\IndianStateCensusAndCodeAnalyser\IndianStateCensusAndCodeAnalyserTest\CSVFiles\IndianStateCensusData.csv";
        static string WrongIndianStateCesusFilePath = @"C:\Users\HP\source\repos\CensusAnalyserProblemDemo\NUnitTestProject1\CSVFiles\WrongIndianStateCensus.csv";

        IndianStateCensusAndCodeAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecords;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCensusAndCodeAnalyser.CensusAnalyser();
            totalRecords = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        ///  Given Indian Census Data File, Should Return Census Data Count
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecords = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCesusFilePath, indianStateCensusHeader);
            Assert.AreEqual(17, totalRecords.Count);
        }

        /// <summary>
        /// Given Wrong Indian Census Data File Path Should Return Custom Exception as FILE_NOT_FOUND
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, WrongIndianStateCesusFilePath, indianStateCensusHeader));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
    }
}