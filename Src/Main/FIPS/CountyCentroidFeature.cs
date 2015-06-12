namespace USC.GISResearchLab.Common.GeographicFeatures.FIPS.Counties
{
	/// <summary>
	/// Summary description for County.
	/// </summary>
    public class CountyCentroidFeature : FIPSPointFeature
    {
        #region Properties

        private int _County;
        public int County
        {
            get { return _County; }
            set { _County = value; }
        }

        public string CountyName { get; set; }

        #endregion

		public CountyCentroidFeature()
		{
			County = 0;
		}
	}
}
