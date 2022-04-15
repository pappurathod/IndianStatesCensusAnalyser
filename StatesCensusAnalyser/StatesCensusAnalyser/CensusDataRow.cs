using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesCensusAnalyser
{
    public class CensusDataRow
    {
        string state;
        int population;
        int area;
        int density;
        int serialNumber;
        string stateName;
        int tin;
        string stateCode;

        public CensusDataRow(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = Convert.ToInt32(population);
            this.area = Convert.ToInt32(area);
            this.density = Convert.ToInt32(density);
        }
        public CensusDataRow(CensusDataRowStateCode censusDataRowStateCode)
        {
            this.stateName = censusDataRowStateCode.stateName;
            this.serialNumber = censusDataRowStateCode.serialNumber;
            this.tin = censusDataRowStateCode.tin;
            this.stateCode = censusDataRowStateCode.stateCode;
        }
    }
}
