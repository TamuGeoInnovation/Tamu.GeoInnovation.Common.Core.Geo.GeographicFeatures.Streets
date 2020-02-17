namespace USC.GISResearchLab.Common.GeographicFeatures.FIPS.CountySubregions
{
    /// <summary>
    /// Summary description for CountySubregion.
    /// </summary>
    public class CountySubregionCentroidFeature : FIPSPointFeature
    {
        #region Properties



        public int County { get; set; }
        public string CountySubregion { get; set; }
        #endregion

        public CountySubregionCentroidFeature()
        {
            County = 0;
            CountySubregion = "";
        }
    }
}
