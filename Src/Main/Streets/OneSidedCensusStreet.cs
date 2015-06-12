using USC.GISResearchLab.Common.GeographicFeatures.Streets;

namespace USC.GISResearchLab.Common.Core.Geographics.Features.Streets
{
    public class OneSidedCensusStreet : OneSidedStreet
    {
        #region Properties
        private string _Cfcc;
        public string Cfcc
        {
            get { return _Cfcc; }
            set { _Cfcc = value; }
        }

        private string _CensusTract;
        public string CensusTract
        {
            get { return _CensusTract; }
            set { _CensusTract = value; }
        }

        private string _CensusBlock;
        public string CensusBlock
        {
            get { return _CensusBlock; }
            set { _CensusBlock = value; }
        }
        
        #endregion

    }
}
