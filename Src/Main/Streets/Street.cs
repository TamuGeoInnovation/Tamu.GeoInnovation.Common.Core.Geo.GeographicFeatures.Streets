using System;
using USC.GISResearchLab.Common.Addresses;
using USC.GISResearchLab.Common.Census.FIPSAttributes;
using USC.GISResearchLab.Common.Exceptions.Geocoding.Parameters.Addresses;
using USC.GISResearchLab.Common.GeographicFeatures.Parcels;
using USC.GISResearchLab.Common.Geometries.Lines;
using USC.GISResearchLab.Common.Geometries.Points;
using USC.GISResearchLab.Common.Utils.Numbers;
using USC.GISResearchLab.Common.Utils.Strings;

namespace USC.GISResearchLab.Common.GeographicFeatures.Streets
{
    /// <summary>
    /// Summary description for RawSegment.
    /// 
    /// This class is the raw result of selecting a matching segment from the database source 
    /// 
    /// </summary>
    public class Street : Line, ICloneable
    {
        #region Properties

        // the from and to address range major and minor
        public string FromAddressRangeMajorRightStr { get; set; }
        public string FromAddressRangeMajorLeftStr { get; set; }
        public string ToAddressRangeMajorLeftStr { get; set; }
        public string ToAddressRangeMajorRightStr { get; set; }

        public string FromAddressRangeMinorRightStr { get; set; }
        public string FromAddressRangeMinorLeftStr { get; set; }
        public string ToAddressRangeMinorLeftStr { get; set; }
        public string ToAddressRangeMinorRightStr { get; set; }

        //the from and to house number major
        public string FromAddressHouseNumberMajorRightStr { get; set; }
        public string FromAddressHouseNumberMajorLeftStr { get; set; }
        public string ToAddressHouseNumberMajorLeftStr { get; set; }
        public string ToAddressHouseNumberMajorRightStr { get; set; }

        public string FromAddressHouseNumberMinorRightStr { get; set; }
        public string FromAddressHouseNumberMinorLeftStr { get; set; }
        public string ToAddressHouseNumberMinorLeftStr { get; set; }
        public string ToAddressHouseNumberMinorRightStr { get; set; }

        public double NumberOfLots { get; set; }
        //public string FePreDir { get; set; }
        //public string FeName { get; set; }
        //public string FeType { get; set; }
        //public string FePostDir { get; set; }
        public string Cfcc { get; set; }
        public string CensusTractLeft { get; set; }
        public string CensusTractRight { get; set; }
        public string CensusBlockLeft { get; set; }
        public string CensusBlockRight { get; set; }
        public string CensusBlockGroupLeft { get; set; }
        public string CensusBlockGroupRight { get; set; }
        public FIPSAttribute FIPSCountyLeft { get; set; }
        public FIPSAttribute FIPSCountySubLeft { get; set; }
        public FIPSAttribute FIPSMinorCivilDivisionLeft { get; set; }
        public FIPSAttribute FIPSConsolidatedCityLeft { get; set; }
        public FIPSAttribute FIPSPlaceLeft { get; set; }
        public FIPSAttribute FIPSCountyRight { get; set; }
        public FIPSAttribute FIPSCountySubRight { get; set; }
        public FIPSAttribute FIPSMinorCivilDivisionRight { get; set; }
        public FIPSAttribute FIPSConsolidatedCityRight { get; set; }
        public FIPSAttribute FIPSPlaceRight { get; set; }
        public string ZIPLeft { get; set; }
        public string ZipPlus1Left { get; set; }
        public string ZipPlus2Left { get; set; }
        public string ZipPlus3Left { get; set; }
        public string ZipPlus4Left { get; set; }
        public string ZipPlus5Left { get; set; }
        public string ZIPRight { get; set; }
        public string ZipPlus1Right { get; set; }
        public string ZipPlus2Right { get; set; }
        public string ZipPlus3Right { get; set; }
        public string ZipPlus4Right { get; set; }
        public string ZipPlus5Right { get; set; }
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string SoundexName { get; set; }
        public string SoundexDMName { get; set; }
        public string Suffix { get; set; }
        public string PreType { get; set; }
        public string PreQualifier { get; set; }
        public string PreDirectional { get; set; }
        public string PostDirectional { get; set; }
        public string PostQualifier { get; set; }
        public string Place { get; set; }
        public string ZIP { get; set; }
        public string ZIPPlus1 { get; set; }
        public string ZIPPlus2 { get; set; }
        public string ZIPPlus3 { get; set; }
        public string ZIPPlus4 { get; set; }
        public string ZIPPlus5 { get; set; }
        public string ConsolidatedCity { get; set; }
        public string MinorCivilDivision { get; set; }
        public string CountySubregion { get; set; }
        public string County { get; set; }
        public string State { get; set; }

        public string Country { get; set; }
        public string LaneCategoryStr { get; set; }
        public double NumberOfLanes { get; set; }
        public bool IsWesternHemisphere { get; set; }
        public bool IsNorthernHemisphere { get; set; }
        public Parcel[] Parcels { get; set; }
        public string ParcelsString { get; set; }
        public string InfoString { get; set; }

        public StreetNumberRangeParity StreetNumberRangeParity { get; set; }
        public StreetSide StreetSide { get; set; }
        public StreetNumberRangeType StreetNumberRangeType { get; set; }
        public StreetNumberRangeNumericSubType StreetNumberRangeNumericSubType { get; set; }

        #endregion

        public Street()
        {
            FIPSCountyLeft = new FIPSAttribute();
            FIPSCountySubLeft = new FIPSAttribute();
            FIPSMinorCivilDivisionLeft = new FIPSAttribute();
            FIPSConsolidatedCityLeft = new FIPSAttribute();
            FIPSPlaceLeft = new FIPSAttribute();

            FIPSCountyRight = new FIPSAttribute();
            FIPSCountySubRight = new FIPSAttribute();
            FIPSMinorCivilDivisionRight = new FIPSAttribute();
            FIPSConsolidatedCityRight = new FIPSAttribute();
            FIPSPlaceRight = new FIPSAttribute();
        }

        public Street(Point start, Point end)
            :base(start, end)
        {
            Start = start;
            End = end;

            FIPSCountyLeft = new FIPSAttribute();
            FIPSCountySubLeft = new FIPSAttribute();
            FIPSMinorCivilDivisionLeft = new FIPSAttribute();
            FIPSConsolidatedCityLeft = new FIPSAttribute();
            FIPSPlaceLeft = new FIPSAttribute();

            FIPSCountyRight = new FIPSAttribute();
            FIPSCountySubRight = new FIPSAttribute();
            FIPSMinorCivilDivisionRight = new FIPSAttribute();
            FIPSConsolidatedCityRight = new FIPSAttribute();
            FIPSPlaceRight = new FIPSAttribute();
        }

        public Street(ValidateableStreetAddress address, string fromAddressLeft, string toAddressLeft, string fromAddressRight,
                      string toAddressRight)
        {
            Name = address.StreetName;
            Suffix = address.Suffix;
            PreDirectional = address.PreDirectional;
            PostDirectional = address.PostDirectional;
            State = address.State;
            FromAddressHouseNumberMajorLeftStr = fromAddressLeft;
            ToAddressHouseNumberMajorLeftStr = toAddressLeft;
            FromAddressHouseNumberMajorRightStr = fromAddressRight;
            ToAddressHouseNumberMajorRightStr = toAddressRight;

            FIPSCountyLeft = new FIPSAttribute();
            FIPSCountySubLeft = new FIPSAttribute();
            FIPSMinorCivilDivisionLeft = new FIPSAttribute();
            FIPSConsolidatedCityLeft = new FIPSAttribute();
            FIPSPlaceLeft = new FIPSAttribute();

            FIPSCountyRight = new FIPSAttribute();
            FIPSCountySubRight = new FIPSAttribute();
            FIPSMinorCivilDivisionRight = new FIPSAttribute();
            FIPSConsolidatedCityRight = new FIPSAttribute();
            FIPSPlaceRight = new FIPSAttribute();
        }

        public double GetFirstDepth()
        {
            return Parcels[0].Depth;
        }

        public double GetFirstWidth()
        {
            return Parcels[0].Width;
        }

        public Parcel GetLastParcel()
        {
            Parcel ret = Parcels[Parcels.Length - 1].Clone();
            return ret;
        }

        public Parcel GetFirstParcel()
        {
            Parcel ret = Parcels[0].Clone();
            return ret;
        }

        public double GetLastDepth()
        {
            return Parcels[Parcels.Length - 1].Depth;
        }

        public double GetLastWidth()
        {
            return Parcels[Parcels.Length - 1].Width;
        }

        public double GetWidthOfParcelsSummation()
        {
            double ret = 0;
            for (int i = 0; i < Parcels.Length; i++)
            {
                Parcel Parcel = Parcels[i];
                ret += Parcel.Width;
            }

            return ret;
        }

        public void insertFirstParcel(Parcel firstParcel)
        {
            Parcel[] newParcels = new Parcel[Parcels.Length + 1];
            newParcels[0] = firstParcel;
            for (int i = 0; i < Parcels.Length; i++)
            {
                newParcels[i + 1] = Parcels[i];
            }
            Parcels = newParcels;
        }

        public void insertLastParcel(Parcel lastParcel)
        {
            Parcel[] newParcels = new Parcel[Parcels.Length + 1];

            for (int i = 0; i < Parcels.Length; i++)
            {
                newParcels[i] = Parcels[i];
            }
            newParcels[newParcels.Length - 1] = lastParcel;
            Parcels = newParcels;
        }

        public void setInfoStrings()
        {
            InfoString += Start.Y + " " + Start.X + "|";
            InfoString += End.Y + " " + End.X + "|";
            InfoString += Source + "|";
            InfoString += Id + "|";
            InfoString += FromAddressHouseNumberMajorLeftStr + "|";
            InfoString += ToAddressHouseNumberMajorLeftStr + "|";
            InfoString += FromAddressHouseNumberMajorRightStr + "|";
            InfoString += ToAddressHouseNumberMajorRightStr + "|";
            InfoString += IsReversed.ToString();

            for (int i = 0; i < Parcels.Length; i++)
            {
                Parcel p = Parcels[i];
                ParcelsString += p.NumberStr + ",";
                ParcelsString += p.Width + ",";
                ParcelsString += p.Depth + ",";
                ParcelsString += p.WidthBearing + ",";
                ParcelsString += p.DepthBearing;
                ParcelsString += "|";
            }
            ParcelsString = StringUtils.TrimBarList(ParcelsString);
        }

        public void buildParcels(string parcelsString)
        {
            string[] sets = parcelsString.Split('|');
            for (int i = 0; i < sets.Length; i++)
            {
                string ParcelString = sets[i].Trim();
                string[] parts = ParcelString.Split(',');

                string numberStr = parts[0].Trim();
                double width = StringUtils.ToDouble(parts[1]);
                double depth = StringUtils.ToDouble(parts[2]);
                double widthBearing = StringUtils.ToDouble(parts[3]);
                double depthBearing = StringUtils.ToDouble(parts[4]);

                Parcel p = new Parcel();
                p.NumberStr = numberStr;
                p.Width = width;
                p.Depth = depth;
                p.WidthBearing = widthBearing;
                p.DepthBearing = depthBearing;

                addParcel(p);
            }
            sortParcels();
            NumberOfLots = Parcels.Length;
        }

        public void sortParcels()
        {
            int fromLeftInt = StringUtils.ToInt(FromAddressHouseNumberMajorLeftStr);
            int toLeftInt = StringUtils.ToInt(ToAddressHouseNumberMajorLeftStr);
            int fromRightInt = StringUtils.ToInt(FromAddressHouseNumberMajorRightStr);
            int toRightInt = StringUtils.ToInt(ToAddressHouseNumberMajorRightStr);

            int fromInt;
            int toInt;

            if (IsReversed)
            {
                fromInt = toLeftInt;
                toInt = fromLeftInt;
            }
            else
            {
                fromInt = fromRightInt;
                toInt = toRightInt;
            }

            if (fromInt < toInt)
            {
                Array.Sort(Parcels, new ParcelComparer(Line.sortOrder.sortAsc));
            }
            else
            {
                Array.Sort(Parcels, new ParcelComparer(Line.sortOrder.sortDesc));
            }
        }

        public void addParcel(Parcel p)
        {
            if (Parcels == null || Parcels.Length == 0)
            {
                Parcels = new Parcel[1];
                Parcels[0] = p;
            }
            else
            {
                Parcel[] newParcels = new Parcel[Parcels.Length + 1];
                for (int i = 0; i < Parcels.Length; i++)
                {
                    newParcels[i] = Parcels[i];
                }
                newParcels[newParcels.Length - 1] = p;
                Parcels = newParcels;
            }
            NumberOfLots = Parcels.Length;
        }

        public AddressRange CreateAddressRange()
        {
            AddressRange addressRange = new AddressRange();
            int from;
            int to;
            if (IsReversed)
            {
                from = StringUtils.ToInt(FromAddressHouseNumberMajorLeftStr);
                to = StringUtils.ToInt(ToAddressHouseNumberMajorLeftStr);
            }
            else
            {
                from = StringUtils.ToInt(FromAddressHouseNumberMajorRightStr);
                to = StringUtils.ToInt(ToAddressHouseNumberMajorRightStr);
            }

            if (from < to)
            {
                addressRange.FromAddress = from;
                addressRange.ToAddress = to;
            }
            else
            {
                addressRange.FromAddress = to;
                addressRange.ToAddress = from;
            }

            return addressRange;
        }

        public ValidateableStreetAddress CreateAddress()
        {
            ValidateableStreetAddress address = new ValidateableStreetAddress();
            address.PreDirectional = PreDirectional;
            address.StreetName = Name;
            address.Suffix = Suffix;
            address.PostDirectional = PostDirectional;
            address.State = State;
            if (IsReversed)
            {
                address.ZIP = ZIPLeft;
                address.Number = FromAddressHouseNumberMajorLeftStr;
            }
            else
            {
                address.ZIP = ZIPRight;
                address.Number = FromAddressHouseNumberMajorRightStr;
            }
            return address;
        }

        public AddressRange GetAddressRangeForAddress(ValidateableStreetAddress address)
        {
            AddressRange ret = new AddressRange();
            ret.Id = Id;

            int fromLeft = 0;
            int toLeft = 0;
            int fromRight = 0;
            int toRight = 0;

            if (NumberUtils.IsInt(FromAddressHouseNumberMajorLeftStr))
            {
                fromLeft = StringUtils.ToInt(FromAddressHouseNumberMajorLeftStr);
            }

            if (NumberUtils.IsInt(ToAddressHouseNumberMajorLeftStr))
            {
                toLeft = StringUtils.ToInt(ToAddressHouseNumberMajorLeftStr);
            }

            if (NumberUtils.IsInt(FromAddressHouseNumberMajorRightStr))
            {
                fromRight = StringUtils.ToInt(FromAddressHouseNumberMajorRightStr);
            }

            if (NumberUtils.IsInt(ToAddressHouseNumberMajorRightStr))
            {
                toRight = StringUtils.ToInt(ToAddressHouseNumberMajorRightStr);
            }

            if ((fromLeft >= 0) && (NumberUtils.evenOdd(fromLeft) == address.EvenOdd))
            {
                ret.FromAddress = fromLeft;
                ret.ToAddress = toLeft;
                ret.IsLeft = true;
                ret.generateAddresses(true);
            }
            else if ((fromRight >= 0) && (NumberUtils.evenOdd(fromRight) == address.EvenOdd))
            {
                ret.FromAddress = fromRight;
                ret.ToAddress = toRight;
                ret.IsRight = true;
                ret.generateAddresses(true);
            }
            else
            {
                throw new AddressException("The address does not fall on either the even or odd side of the street");
            }
            return ret;
        }

        public AddressRangeDoubleSided GetAddressRangeDoubleSided()
        {
            AddressRangeDoubleSided ret = new AddressRangeDoubleSided();
            ret.Id = Id;
            ret.Source = Source;

            int fromLeft = StringUtils.ToInt(FromAddressHouseNumberMajorLeftStr);
            int toLeft = StringUtils.ToInt(ToAddressHouseNumberMajorLeftStr);
            int fromRight = StringUtils.ToInt(FromAddressHouseNumberMajorRightStr);
            int toRight = StringUtils.ToInt(ToAddressHouseNumberMajorRightStr);

            if ((fromLeft >= 0))
            {
                AddressRange addressRange = new AddressRange();
                addressRange.Id = Id;
                addressRange.FromAddress = fromLeft;
                addressRange.ToAddress = toLeft;
                addressRange.IsLeft = true;
                addressRange.generateAddresses(true);
                if ((NumberUtils.evenOdd(fromLeft) == 0))
                {
                    addressRange.IsEven = true;
                }
                else
                {
                    addressRange.IsOdd = true;
                }
                ret.Left = addressRange;
            }
            if ((fromRight >= 0))
            {
                AddressRange addressRange = new AddressRange();
                addressRange.Id = Id;
                addressRange.FromAddress = fromRight;
                addressRange.ToAddress = toRight;
                addressRange.IsRight = true;
                addressRange.generateAddresses(true);
                if ((NumberUtils.evenOdd(fromRight) == 0))
                {
                    addressRange.IsEven = true;
                }
                else
                {
                    addressRange.IsOdd = true;
                }
                ret.Right = addressRange;
            }
            return ret;
        }

        public static Street FromString(string s)
        {
            string[] parts = s.Split('|');
            string[] startParts = parts[0].Trim().Split(' ');
            string[] endParts = parts[1].Trim().Split(' ');

            Point Start = new Point(StringUtils.ToDouble(startParts[0]), StringUtils.ToDouble(startParts[1]));
            Point End = new Point(StringUtils.ToDouble(endParts[0]), StringUtils.ToDouble(endParts[1]));

            Street ret = new Street(Start, End);
            ret.Source = parts[2].Trim();
            ret.Id = parts[3].Trim();
            ret.FromAddressHouseNumberMajorLeftStr = parts[4].Trim();
            ret.ToAddressHouseNumberMajorLeftStr = parts[5].Trim();
            ret.FromAddressHouseNumberMajorRightStr = parts[6].Trim();
            ret.ToAddressHouseNumberMajorRightStr = parts[7].Trim();
            ret.IsReversed = StringUtils.ToBool(parts[8]);

            return ret;
        }

        public Point InterpolateUniform(double lotNumber)
        {
            return Interpolate(lotNumber, NumberOfLots);
        }

        //public Point InterpolateUniform(double lotNumber, double numberOfLots)
        //{
        //    Point ret = new Point();

            
        //    double lotRatio = ((lotNumber + .5) / numberOfLots);
        //    double lotCenterLat = (Start.Y + (lotRatio * (End.Y - Start.Y)));
        //    double lotCenterLon = (Start.X + (lotRatio * (End.X - Start.X)));

        //    ret.Y = lotCenterLat;
        //    ret.X = lotCenterLon;
            
        //    return ret;
        //}

        public Point InterpolateActual(string address)
        {
            Point ret = new Point();

            double lengthFromStart = 0.0;
            double widthOfLot = 0.0;


            bool found = false;
            Parcel[] addressParcels = Parcels;
            for (int i = 0; i < addressParcels.Length; i++)
            {
                if (!found)
                {
                    Parcel parcel = addressParcels[i];

                    if (!parcel.NumberStr.Equals(address))
                    {
                        lengthFromStart += parcel.Width;
                    }
                    else
                    {
                        widthOfLot = parcel.Width;
                        found = true;
                    }
                }
            }

            if (found)
            {
                double lotRatio = ((lengthFromStart + (widthOfLot / 2)) / Length);
                double lotCenterLat = (Start.Y + (lotRatio * (End.Y - Start.Y)));
                double lotCenterLon = (Start.X + (lotRatio * (End.X - Start.X)));

                ret.Y = lotCenterLat;
                ret.X = lotCenterLon;
                //ret.GeocodedError.ErrorBounds = widthOfLot;
            }

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
            x.Parcels = (Parcel[]) Parcels.Clone();
            return x;
        }

        #endregion
    }
}