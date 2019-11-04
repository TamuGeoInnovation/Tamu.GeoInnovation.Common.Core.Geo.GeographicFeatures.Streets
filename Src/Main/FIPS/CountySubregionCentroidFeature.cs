namespace USC.GISResearchLab.Common.GeographicFeatures.FIPS.CountySubregions
{
    /// <summary>
    /// Summary description for CountySubregion.
    /// </summary>
    public class CountySubregionCentroidFeature : FIPSPointFeature
    {
        #region Properties

        private int _County;
        private string _CountySubregion;

        public int County
        {
            get { return _County; }
            set { _County = value; }
        }

        public string CountySubregion
        {
            get { return _CountySubregion; }
            set { _CountySubregion = value; }
        }

        #endregion

        public CountySubregionCentroidFeature()
        {
            County = 0;
            CountySubregion = "";
        }
    }
}
