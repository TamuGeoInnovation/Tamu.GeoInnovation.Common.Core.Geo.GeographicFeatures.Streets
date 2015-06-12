using USC.GISResearchLab.Common.Core.Addresses.Interfaces;
using USC.GISResearchLab.Common.Geometries;

namespace USC.GISResearchLab.Common.Core.Geographics.Features.Interfaces
{
    public interface IStreetAddressableGeographicFeature: IStreetAddressBase
    {

        #region Properties

        Geometry Geometry { get; set; }

        #endregion

        byte[] GetGeometryAsWKB();
        void SetGeometryFromWKB(byte[] wkb, int srid);
    }
}
