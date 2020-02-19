using System.IO;
using USC.GISResearchLab.Common.Addresses.AbstractClasses;
using USC.GISResearchLab.Common.Geometries;

namespace USC.GISResearchLab.Common.Core.Geographics.Features.Interfaces
{
    public abstract class AbstractStreetAddressableGeographicFeature : AbstractStreetAddressBase, IStreetAddressableGeographicFeature
    {

        #region Properties

        public Geometry Geometry { get; set; }
        public Geometry GeometrySource { get; set; }

        public string CensusBlock { get; set; }
        public string CensusBlockGroup { get; set; }
        public string CensusTract { get; set; }

        public string CensusYear { get; set; }
        public string CensusNAACCRCertCode { get; set; }
        public string CensusNAACCRCertType { get; set; }
        public string CensusCountyFips { get; set; }
        public string CensusPlaceFips { get; set; }
        public string CensusMSAFips { get; set; }
        public string CensusMCDFips { get; set; }
        public string CensusCBSAFips { get; set; }
        public string CensusCBSAMicro { get; set; }
        public string CensusMetDivFips { get; set; }
        public string CensusStateFips { get; set; }


        #endregion

        public AbstractStreetAddressableGeographicFeature()
        {
        }


        // this is from http://social.msdn.microsoft.com/Forums/en/sqlspatial/thread/e2e2fca8-2ef2-483c-ba42-c8a71e8fb00c
        public byte[] GetGeometryAsWKB()
        {
            byte[] ret = null;

            if (Geometry != null)
            {

                if (Geometry.SqlGeometry != null)
                {
                    MemoryStream ms = new MemoryStream();
                    BinaryWriter bw = new BinaryWriter(ms);
                    ret = Geometry.SqlGeometry.STAsBinary().Buffer;
                    bw.Write(ret);
                }
            }

            return ret;
        }

        // this is from http://social.msdn.microsoft.com/Forums/en/sqlspatial/thread/e2e2fca8-2ef2-483c-ba42-c8a71e8fb00c
        public void SetGeometryFromWKB(byte[] wkb, int srid)
        {

            if (Geometry != null)
            {
                var udtBinary = new System.Data.SqlTypes.SqlBytes(wkb);
                Geometry.SqlGeometry = Microsoft.SqlServer.Types.SqlGeometry.STGeomFromWKB(udtBinary, srid);
            }
        }
    }
}