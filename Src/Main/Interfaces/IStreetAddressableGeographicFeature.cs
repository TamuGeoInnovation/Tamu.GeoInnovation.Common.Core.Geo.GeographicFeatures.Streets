using USC.GISResearchLab.Common.Core.Addresses.Interfaces;
using USC.GISResearchLab.Common.Geometries;

namespace USC.GISResearchLab.Common.Core.Geographics.Features.Interfaces
{
    public interface IStreetAddressableGeographicFeature : IStreetAddressBase
    {

        #region Properties

        Geometry Geometry { get; set; }
        Geometry GeometrySource { get; set; }

        string CensusBlock { get; set; }
        string CensusBlockGroup { get; set; }
        string CensusTract { get; set; }

        string CensusYear { get; set; }
        string CensusNAACCRCertCode { get; set; }
        string CensusNAACCRCertType { get; set; }
        string CensusCountyFips { get; set; }
        string CensusPlaceFips { get; set; }
        string CensusMSAFips { get; set; }
        string CensusMCDFips { get; set; }
        string CensusCBSAFips { get; set; }
        string CensusCBSAMicro { get; set; }
        string CensusMetDivFips { get; set; }
        string CensusStateFips { get; set; }

        #endregion

        byte[] GetGeometryAsWKB();
        void SetGeometryFromWKB(byte[] wkb, int srid);
    }
}