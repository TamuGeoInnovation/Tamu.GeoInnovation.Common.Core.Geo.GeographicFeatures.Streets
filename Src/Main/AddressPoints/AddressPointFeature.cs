using USC.GISResearchLab.Common.Addresses;
using USC.GISResearchLab.Common.Geometries.Points;

namespace USC.GISResearchLab.Common.Core.Geographics.Features.Addresses
{
    public class AddressPointFeature : Point
    {
        #region Properties

        private string _Id;
        public new string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _AddressId;
        public string AddressId
        {
            get { return _AddressId; }
            set { _AddressId = value; }
        }


        private string _Source;
        public string Source
        {
            get { return _Source; }
            set { _Source = value; }
        }

        public StreetAddress StreetAddress { get; set; }

        #endregion


        #region Constructors
        public AddressPointFeature()
        {
            StreetAddress = new StreetAddress();
            AddressId = "";
            Source = "";
        }
        #endregion
    }
}
