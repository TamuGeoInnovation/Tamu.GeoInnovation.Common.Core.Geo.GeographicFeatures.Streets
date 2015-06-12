using USC.GISResearchLab.Common.Core.Geographics.Features.Addresses;

namespace USC.GISResearchLab.Common.GeographicFeatures.FIPS
{
    public class FIPSPointFeature : AddressPointFeature, IFIPSFeature
    {

        #region Properties

        public int FIPSFeatureId { get; set; }
        public int FIPSStateId { get; set; }
        public string FeatureName { get; set; }
        public double Population { get; set; }
        public double Housing { get; set; }
        public double LandAreaMeters { get; set; }
        public double WaterAreaMeters { get; set; }
        public double LandAreaMiles { get; set; }
        public double WaterAreaMiles { get; set; }

        #endregion


    }
}
