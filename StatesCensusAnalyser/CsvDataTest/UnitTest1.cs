using NUnit.Framework;
using StatesCensusAnalyser;

namespace CsvDataTest
{
    public class Tests
    {
        string folderPath = @"C:\Users\Pappu Rathod\source\repos\IndianStatesCensusAnalyser\StatesCensusAnalyser\Files\";
        string validStateCensusFileState = "IndiaStateCensusData.csv";
        string invalidExtensionFileState = "IndiaStateCode.txt";
        string invalidDelimiterFileState = "DelimiterIndiaStateCensusData.csv";
        string invalidHeaderState = "WrongIndiaStateCensusData.csv";
        CensusAnalyser censusAnalyser;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
        }
        /// <summary>
        /// TC1.1 Check number of record matches
        /// </summary>
        [Test]
        public void GivenCSVFileTestIfRecordsAreSame()
        {
            censusAnalyser.datamap = censusAnalyser.LoadCensusData(folderPath + validStateCensusFileState, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, censusAnalyser.datamap.Count);
        }
        /// <summary>
        /// TC1.2 given the file if incorrect returns a custom exception
        /// </summary>
        [Test]
        public void GivenIncorrectFileNameReturnsCustomException()
        {
            CensusAnalyserException Exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + validStateCensusFileState + "abc", "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_EXISTS, Exception.type);
        }
        /// <summary>
        /// TC1.3 Given correct file but file type incorrect return custom exception
        /// </summary>
        [Test]
        public void GivenIncorrectTypeReturnsCustomException()
        {
            CensusAnalyserException Exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidExtensionFileState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.IMPROPER_EXTENSION, Exception.type);
        }
        /// <summary>
        /// TC1.4 Given correct file but file delimiter incorrect return custom exception
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiterReturnsCustomException()
        {
            CensusAnalyserException Exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidDelimiterFileState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.DELIMITER_NOT_FOUND, Exception.type);
        }
        /// <summary>
        /// TC1.5 Given correct file but file header incorrect return custom exception
        /// </summary>
        [Test]
        public void GivenIncorrectHeaderReturnsCustomException()
        {
            CensusAnalyserException Exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidHeaderState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, Exception.type);
        }

    }
}

