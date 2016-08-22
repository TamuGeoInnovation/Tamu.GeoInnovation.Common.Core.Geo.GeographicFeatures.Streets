using System;
using USC.GISResearchLab.Common.Addresses;
using USC.GISResearchLab.Common.Core.Addresses.Interfaces;
using USC.GISResearchLab.Common.Core.Geographics.Features.Interfaces;
using USC.GISResearchLab.Common.Geometries;
using USC.GISResearchLab.Common.Geometries.Points;

namespace USC.GISResearchLab.Common.GeographicFeatures.AddressPoints
{
    /// <summary>
    /// Summary description for RawSegment.
    /// 
    /// This class is the raw result of selecting a matching segment from the database source 
    /// 
    /// </summary>
    public class PennyAddressPoint : AbstractStreetAddressableGeographicFeature, IStreetAddressBase, ICloneable
    {
        #region Properties

        public string StreetId { get; set; }
        public string Number { get; set; }
        public string NumberFractional { get; set; }        

        public StreetNumberRangeParity StreetNumberParity { get; set; }        

        #endregion

        public PennyAddressPoint() { }

        public PennyAddressPoint(Point point)
        {
            Geometry = point;
        }

        public PennyAddressPoint(Geometry geometry)
        {
            Geometry = geometry;
        }

        //public PennyAddressPoint(Geometry geometry, Geometry geometry_source)
        //{
        //    Geometry = geometry;
        //    GeometrySource = geometry_source;
        //}

        #region Cloning Functions

        object ICloneable.Clone()
        {
            return Clone();
        }

        public new PennyAddressPoint Clone()
        {
            PennyAddressPoint x = (PennyAddressPoint)MemberwiseClone();
            return x;
        }

        #endregion
    }
}