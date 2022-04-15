using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StatesCensusAnalyser
{
    public class CensusAnalyser
    {
        public Dictionary<string, CensusDataRow> datamap;

        public Dictionary<string, CensusDataRow> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            datamap = new Dictionary<string, CensusDataRow>();
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.FILE_NOT_EXISTS, "File does not exists");
            }
            if (Path.GetExtension(csvFilePath)  != ".csv")
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.IMPROPER_EXTENSION, "Improper file extension");
            }

            string[] censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, "Incorrect Header");
            }
            foreach(string row in censusData.Skip(1))
            {
                if (!row.Contains(","))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.DELIMITER_NOT_FOUND, "Delimiter not found");
                }
                string[] column = row.Split(',');
                if (csvFilePath.Contains("StateCode"))
                    datamap.Add(column[0], new CensusDataRow(new CensusDataRowStateCode(column[0], column[1], column[2], column[3])));
                else
                    datamap.Add(column[0], new CensusDataRow(column[0], column[1], column[2], column[3]));
            }
            return datamap;
        }
    }
}
