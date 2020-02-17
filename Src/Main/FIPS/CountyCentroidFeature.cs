namespace USC.GISResearchLab.Common.GeographicFeatures.FIPS.Counties
{
    /// <summary>
    /// Summary description for County.
    /// </summary>
    public class CountyCentroidFeature : FIPSPointFeature
    {
        #region Properties

        public int County { get; set; }

        public string CountyName { get; set; }

        #endregion

        public CountyCentroidFeature()
        {
            County = 0;
        }
    }
}
