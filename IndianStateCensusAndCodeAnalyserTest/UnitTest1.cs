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
        static string WrongIndianStateCesusFileTypePath = @"C:\Users\HP\source\repos\IndianStateCensusAndCodeAnalyser\IndianStateCensusAndCodeAnalyserTest\CSVFiles\IndianStateCensusData.txt";
        static string IndianStateCesusFilePathWithWrongDelimeter = @"C:\Users\HP\source\repos\IndianStateCensusAndCodeAnalyser\IndianStateCensusAndCodeAnalyserTest\CSVFiles\IndianStateCensusDataWithWrongDelimeter.csv";
        static string IndianStateCesusFilePathWithWrongHeader = @"C:\Users\HP\source\repos\IndianStateCensusAndCodeAnalyser\IndianStateCensusAndCodeAnalyserTest\CSVFiles\WrongHeaderInIndiaStateCensusData.csv";

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

        /// <summary>
        /// Given Wrong Indian Census Data File Type Should Return Custom Exception as INVALID_FILE_TYPE
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, WrongIndianStateCesusFileTypePath, indianStateCensusHeader));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }

        /// <summary>
        /// Given Indian Census Data File When Wrong Delimeter is givnen, Should Return Custom Exception as INCORRECT_DELIMITER
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenWrongDelimeter_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCesusFilePathWithWrongDelimeter, indianStateCensusHeader));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }

        /// <summary>
        /// Given Indian Census Data File When Wrong Header is given,Should Return Custom Exception as INCORRECT_HEADER
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenWrongHeader_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCesusFilePathWithWrongHeader, indianStateCensusHeader));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
    }
}