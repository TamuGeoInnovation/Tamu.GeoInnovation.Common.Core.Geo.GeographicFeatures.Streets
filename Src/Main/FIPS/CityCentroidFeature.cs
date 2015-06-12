namespace USC.GISResearchLab.Common.GeographicFeatures.FIPS.Cities
{
	/// <summary>
	/// Summary description for City.
	/// </summary>
    public class CityCentroidFeature : FIPSPointFeature
    {
        #region Properties
        private int _Place;

        public int Place
        {
            get { return _Place; }
            set { _Place = value; }
        }

        #endregion
	}
}
