using NUnit.Framework;
using IndianStateCensusAndCodeAnalyser.POCO;
using System.Collections.Generic;
using static IndianStateCensusAndCodeAnalyser.CensusAnalyser;

namespace IndianStateCensusAndCodeAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeader = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo, State Name, TIN, StateCode";
        static string indianStateCesusFilePath = @"C:\Users\HP\source\repos\IndianStateCensusAndCodeAnalyser\IndianStateCensusAndCodeAnalyserTest\CSVFiles\IndianStateCensusData.csv";
        static string WrongIndianStateCesusFilePath = @"C:\Users\HP\source\repos\CensusAnalyserProblemDemo\NUnitTestProject1\CSVFiles\WrongIndianStateCensus.csv";
        static string WrongIndianStateCesusFileTypePath = @"C:\Users\HP\source\repos\IndianStateCensusAndCodeAnalyser\IndianStateCensusAndCodeAnalyserTest\CSVFiles\IndianStateCensusData.txt";
        static string IndianStateCesusFilePathWithWrongDelimeter = @"C:\Users\HP\source\repos\IndianStateCensusAndCodeAnalyser\IndianStateCensusAndCodeAnalyserTest\CSVFiles\IndianStateCensusDataWithWrongDelimeter.csv";
        static string IndianStateCesusFilePathWithWrongHeader = @"C:\Users\HP\source\repos\IndianStateCensusAndCodeAnalyser\IndianStateCensusAndCodeAnalyserTest\CSVFiles\WrongHeaderInIndiaStateCensusData.csv";
        static string indianStateCodePath = @"C:\Users\HP\source\repos\IndianStateCensusAndCodeAnalyser\IndianStateCensusAndCodeAnalyserTest\CSVFiles\IndianStateCode.csv";
        static string WrongIndianStateCodeFilePath = @"C:\Users\HP\source\repos\CensusAnalyserProblemDemo\NUnitTestProject1\CSVFiles\WrongStateCode.csv";
        static string WrongIndianStateCodeFileTypePath = @"C:\Users\HP\source\repos\IndianStateCensusAndCodeAnalyser\IndianStateCensusAndCodeAnalyserTest\CSVFiles\IndianStateCode.txt";
        static string IndianStateCodeFilePathWrongDelimeter = @"C:\Users\HP\source\repos\IndianStateCensusAndCodeAnalyser\IndianStateCensusAndCodeAnalyserTest\CSVFiles\IndianStateCodeWithWrongDelimeter.csv";

        IndianStateCensusAndCodeAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecords;
        Dictionary<string, CensusDTO> stateRecords;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCensusAndCodeAnalyser.CensusAnalyser();
            totalRecords = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        ///  TC1.1 - Given Indian Census Data File, Should Return Census Data Count
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecords = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCesusFilePath, indianStateCensusHeader);
            Assert.AreEqual(17, totalRecords.Count);
        }

        /// <summary>
        /// TC1.2 - Given Wrong Indian Census Data File Path Should Return Custom Exception as FILE_NOT_FOUND
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, WrongIndianStateCesusFilePath, indianStateCensusHeader));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }

        /// <summary>
        /// TC1.3 - Given Wrong Indian Census Data File Type Should Return Custom Exception as INVALID_FILE_TYPE
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, WrongIndianStateCesusFileTypePath, indianStateCensusHeader));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }

        /// <summary>
        /// TC1.4 - Given Indian Census Data File When Wrong Delimeter is givnen, Should Return Custom Exception as INCORRECT_DELIMITER
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenWrongDelimeter_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCesusFilePathWithWrongDelimeter, indianStateCensusHeader));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }

        /// <summary>
        /// TC1.5 - Given Indian Census Data File When Wrong Header is given,Should Return Custom Exception as INCORRECT_HEADER
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenWrongHeader_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCesusFilePathWithWrongHeader, indianStateCensusHeader));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }

        /// <summary>
        /// TC2.1 - Given Indian State Code File Should Return Code Data Count
        /// </summary>
        [Test]
        public void GivenIndianStateCodeFile_WhenRead_ShouldReturnCensusDataCount()
        {
            stateRecords = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodePath, indianStateCodeHeaders);
            Assert.AreEqual(17, stateRecords.Count);
        }

        /// <summary>
        /// TC2.2 - Given Wrong State Code File Should Return Custom Exception as FILE_NOT_FOUND
        /// </summary>
        [Test]
        public void GivenWrongStateCodeFile_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, WrongIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        /// <summary>
        /// TC2.3 -Given Indian State Code File when Fily Type is  Wrong, Should Return Custom Exception as INVALID_FILE_TYPE
        /// </summary>
        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, WrongIndianStateCodeFileTypePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }

        /// <summary>
        /// TC2.4 - Given Indian State Code File When Wrong Delimeter is given, Should Return Custom Exception as INCORRECT_DELIMITER
        /// </summary>
        [Test]
        public void GivenIndianStateCodeFile_WhenWrongDelimeter_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCodeFilePathWrongDelimeter, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }
    }
}