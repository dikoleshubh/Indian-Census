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
    }
}