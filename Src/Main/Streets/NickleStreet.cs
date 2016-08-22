using System;
using USC.GISResearchLab.Common.Addresses;
using USC.GISResearchLab.Common.Core.Addresses.Interfaces;
using USC.GISResearchLab.Common.Core.Geographics.Features.Interfaces;
using USC.GISResearchLab.Common.Geometries;
using USC.GISResearchLab.Common.Geometries.Lines;
using USC.GISResearchLab.Common.Geometries.Points;
using USC.GISResearchLab.Common.Geometries.Polygons;

namespace USC.GISResearchLab.Common.GeographicFeatures.Streets
{
    /// <summary>
    /// Summary description for RawSegment.
    /// 
    /// This class is the raw result of selecting a matching segment from the database source 
    /// 
    /// </summary>
    public class NickleStreet : AbstractStreetAddressableGeographicFeature, IStreetSegmentAddress, ICloneable
    {
        #region Properties

        public string StreetId { get; set; }
        public String AddressRangeFromRaw { get; set; }
        public String AddressRangeToRaw { get; set; }
        public AddressRange AddressRangeMajor { get; set; }
        public AddressRange AddressRangeMinor { get; set; }
        public AddressRange AddressRangeHouseNumberRangeMajor { get; set; }
        public AddressRange AddressRangeHouseNumberRangeMinor { get; set; }

        public AddressRange AddressRangeSuper { get; set; }

        public double NumberOfLots { get; set; }
        
        public string LaneCategoryStr { get; set; }
        public double NumberOfLanes { get; set; }
        public bool IsWesternHemisphere { get; set; }
        public bool IsNorthernHemisphere { get; set; }
        

        public StreetNumberRangeParity StreetNumberRangeParity { get; set; }
        public StreetNumberRangeType StreetNumberRangeType { get; set; }
        public StreetNumberRangeNumericSubType StreetNumberRangeNumericSubType { get; set; }

        #endregion

        public NickleStreet() {
            Geometry = new Point(0, 0);
            GeometrySource = new Polygon();
        }

        public NickleStreet(Point start, Point end)
        {
            Geometry = new Line(start, end);
        }

        public NickleStreet(Geometry geometry)
        {
            Geometry = geometry;
        }

        public double GetMinBlocksAway(StreetAddress address, double avgBlockSize)
        {
            double ret = double.MaxValue;

            double distanceAddressRange1Major = double.MaxValue;
            double distanceAddressRange1MajorHouseNumber = double.MaxValue;
            double distanceAddressRange1Minor = double.MaxValue;
            double distanceAddressRange1MinorHouseNumber = double.MaxValue;

            if (AddressRangeMajor != null)
            {
                distanceAddressRange1Major = AddressRangeMajor.DistanceFrom(address.Number);
            }

            if (AddressRangeHouseNumberRangeMajor != null)
            {
                distanceAddressRange1MajorHouseNumber = AddressRangeHouseNumberRangeMajor.DistanceFrom(address.Number);
            }

            if (AddressRangeMinor != null)
            {
                distanceAddressRange1Minor = AddressRangeMinor.DistanceFrom(address.Number);
            }

            if (AddressRangeHouseNumberRangeMinor != null)
            {
                distanceAddressRange1MinorHouseNumber = AddressRangeHouseNumberRangeMinor.DistanceFrom(address.Number);
            }

            double min1 = Math.Min(distanceAddressRange1Major, distanceAddressRange1MajorHouseNumber);
            double min2 = Math.Min(distanceAddressRange1Minor, distanceAddressRange1MinorHouseNumber);

            double min = Math.Min(min1, min2);

            if (min == 0)
            {
                ret = 0;
            }
            else if (min > 0)
            {
                ret = min / avgBlockSize;
            }

            return ret;
        }

        public void CreateSuperAddressRange()
        {
            if (AddressRangeMajor != null && AddressRangeHouseNumberRangeMajor != null)
            {
                int superFrom = -1;
                int superTo = -1;

                if (AddressRangeMajor.StreetNumberRangeOrderType == AddressRangeHouseNumberRangeMajor.StreetNumberRangeOrderType)
                {
                    if (AddressRangeMajor.FromAddress != AddressRangeHouseNumberRangeMajor.FromAddress)
                    {
                        superFrom = Math.Min(AddressRangeMajor.FromAddress, AddressRangeHouseNumberRangeMajor.FromAddress);
                    }
                    if (AddressRangeMajor.ToAddress != AddressRangeHouseNumberRangeMajor.ToAddress)
                    {
                        superTo = Math.Max(AddressRangeMajor.ToAddress, AddressRangeHouseNumberRangeMajor.ToAddress);
                    }
                }
                else
                {
                    if (AddressRangeMajor.StreetNumberRangeOrderType == StreetNumberRangeOrderType.LowHi && AddressRangeHouseNumberRangeMajor.StreetNumberRangeOrderType == StreetNumberRangeOrderType.HiLow)
                    {

                        if (AddressRangeMajor.FromAddress != AddressRangeHouseNumberRangeMajor.ToAddress)
                        {
                            superFrom = Math.Min(AddressRangeMajor.FromAddress, AddressRangeHouseNumberRangeMajor.ToAddress);
                        }
                        if (AddressRangeMajor.ToAddress != AddressRangeHouseNumberRangeMajor.FromAddress)
                        {
                            superTo = Math.Max(AddressRangeMajor.ToAddress, AddressRangeHouseNumberRangeMajor.FromAddress);
                        }
                    }
                    else if (AddressRangeMajor.StreetNumberRangeOrderType == StreetNumberRangeOrderType.HiLow && AddressRangeHouseNumberRangeMajor.StreetNumberRangeOrderType == StreetNumberRangeOrderType.LowHi)
                    {
                        if (AddressRangeMajor.ToAddress != AddressRangeHouseNumberRangeMajor.FromAddress)
                        {
                            superFrom = Math.Min(AddressRangeMajor.ToAddress, AddressRangeHouseNumberRangeMajor.FromAddress);
                        }

                        if (AddressRangeMajor.FromAddress != AddressRangeHouseNumberRangeMajor.ToAddress)
                        {
                            superTo = Math.Max(AddressRangeMajor.FromAddress, AddressRangeHouseNumberRangeMajor.ToAddress);
                        }
                    }
                }

                if (superFrom > 0 && superTo > 0)
                {
                    AddressRangeSuper = new AddressRange(superFrom, superTo);
                }
            }
        }

        public Point InterpolateUniform(double lotNumber)
        {
            Point ret = new Point();

            //double streetLength = ProjectionUtils.distance(street.FromY, street.FromX, street.ToY, street.ToX, 'D');
            //double lotSize = streetLength / numberOfLots;

            double lotRatio = ((lotNumber + .5) / NumberOfLots);
            double lotCenterLat = (((Line)Geometry).Start.Y + (lotRatio * (((Line)Geometry).End.Y - ((Line)Geometry).Start.Y)));
            double lotCenterLon = (((Line)Geometry).Start.X + (lotRatio * (((Line)Geometry).End.X - ((Line)Geometry).Start.X)));

            ret.Y = lotCenterLat;
            ret.X = lotCenterLon;
            //ret.GeocodedError.ErrorBounds = streetLength;

            return ret;
        }

        #region Cloning Functions

        object ICloneable.Clone()
        {
            return Clone();
        }

        public new Street Clone()
        {
            Street x = (Street) MemberwiseClone();
            return x;
        }

        #endregion
    }
}