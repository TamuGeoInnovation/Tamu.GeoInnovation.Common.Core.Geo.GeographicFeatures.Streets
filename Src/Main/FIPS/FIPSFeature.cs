
namespace USC.GISResearchLab.Common.GeographicFeatures.FIPS
{
    public interface IFIPSFeature
    {

        int FIPSFeatureId
        {
            get;
            set;
        }

        int FIPSStateId
        {
            get;
            set;
        }

        string FeatureName
        {
            get ;
            set;
        }
        double Population
        {
            get ;
            set ;
        }
        double Housing
        {
            get ;
            set ;
        }
        double LandAreaMeters
        {
            get ;
            set ;
        }
        double WaterAreaMeters
        {
            get ;
            set ;
        }
        double LandAreaMiles
        {
            get ;
            set ;
        }
        double WaterAreaMiles
        {
            get ;
            set ;
        }

    }
}
