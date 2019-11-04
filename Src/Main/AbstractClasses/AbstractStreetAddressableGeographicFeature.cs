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
