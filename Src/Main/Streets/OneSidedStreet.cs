using System;
using USC.GISResearchLab.Common.Addresses;
using USC.GISResearchLab.Common.Geometries.Lines;
using USC.GISResearchLab.Common.Geometries.Points;
using USC.GISResearchLab.Common.Utils.Strings;

namespace USC.GISResearchLab.Common.GeographicFeatures.Streets
{
    public class OneSidedStreet : Line, ICloneable
    {
        #region Properties

        private string _Id;
        public new string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private bool _Valid;
        public bool Valid
        {
            get { return _Valid; }
            set { _Valid = value; }
        }

        private string _Source;
        public string Source
        {
            get { return _Source; }
            set { _Source = value; }
        }

        private string _FromAddress;
        public string FromAddress
        {
            get { return _FromAddress; }
            set { _FromAddress = value; }
        }

        private string _ToAddress;
        public string ToAddress
        {
            get { return _ToAddress; }
            set { _ToAddress = value; }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Suffix;
        public string Suffix
        {
            get { return _Suffix; }
            set { _Suffix = value; }
        }

        private string _PreDirectional;
        public string PreDirectional
        {
            get { return _PreDirectional; }
            set { _PreDirectional = value; }
        }

        private string _PostDirectional;
        public string PostDirectional
        {
            get { return _PostDirectional; }
            set { _PostDirectional = value; }
        }

        private string _Place;
        public string Place
        {
            get { return _Place; }
            set { _Place = value; }
        }

        private string _Zip;
        public string ZIP
        {
            get { return _Zip; }
            set { _Zip = value; }
        }

        private string _MinorCivilDivision;
        public string MinorCivilDivision
        {
            get { return _MinorCivilDivision; }
            set { _MinorCivilDivision = value; }
        }

        private string _CountySubregion;
        public string CountySubregion
        {
            get { return _CountySubregion; }
            set { _CountySubregion = value; }
        }

        private string _County;
        public string County
        {
            get { return _County; }
            set { _County = value; }
        }

        private string _State;
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        private string _Country;
        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        private double _NumberOfLots;
        public double NumberOfLots
        {
            get { return _NumberOfLots; }
            set { _NumberOfLots = value; }
        }

        private string _LaneCategoryStr;
        public string LaneCategoryStr
        {
            get { return _LaneCategoryStr; }
            set { _LaneCategoryStr = value; }
        }

        private double _NumberOfLanes;
        public double NumberOfLanes
        {
            get { return _NumberOfLanes; }
            set { _NumberOfLanes = value; }
        }

        private bool _IsLeftSide;
        public bool IsLeftSide
        {
            get { return _IsLeftSide; }
            set { _IsLeftSide = value; }
        }

        #endregion

        public OneSidedStreet()
        {
        }

        public OneSidedStreet(Point start, Point end)
            : base(start, end)
        {
            Start = start;
            End = end;
        }

        public OneSidedStreet(ValidateableStreetAddress address, string fromAddress, string toAddress)
        {
            Name = address.StreetName;
            Suffix = address.Suffix;
            PreDirectional = address.PreDirectional;
            PostDirectional = address.PostDirectional;
            State = address.State;
            FromAddress = fromAddress;
            ToAddress = toAddress;
        }

        public AddressRange CreateAddressRange()
        {
            AddressRange addressRange = new AddressRange();
            int from;
            int to;

            from = StringUtils.ToInt(FromAddress);
            to = StringUtils.ToInt(ToAddress);

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
            address.ZIP = ZIP;
            address.Number = FromAddress;

            return address;
        }

        public AddressRange GetAddressRangeForAddress(ValidateableStreetAddress address)
        {
            AddressRange ret = new AddressRange();
            ret.Id = Id;

            int from = StringUtils.ToInt(FromAddress);
            int to = StringUtils.ToInt(ToAddress);
            ret.FromAddress = from;
            ret.ToAddress = to;
            ret.generateAddresses(true);

            return ret;
        }



        public static OneSidedStreet FromString(string s)
        {
            string[] parts = s.Split('|');
            string[] startParts = parts[0].Trim().Split(' ');
            string[] endParts = parts[1].Trim().Split(' ');

            Point Start = new Point(StringUtils.ToDouble(startParts[0]), StringUtils.ToDouble(startParts[1]));
            Point End = new Point(StringUtils.ToDouble(endParts[0]), StringUtils.ToDouble(endParts[1]));

            OneSidedStreet ret = new OneSidedStreet(Start, End);
            ret.Source = parts[2].Trim();
            ret.Id = parts[3].Trim();
            ret.FromAddress = parts[4].Trim();
            ret.ToAddress = parts[5].Trim();
            ret.IsReversed = StringUtils.ToBool(parts[6]);

            return ret;
        }

        public Point InterpolateUniform(double lotNumber)
        {
            Point ret = new Point();

            double lotRatio = ((lotNumber + .5) / NumberOfLots);
            double lotCenterLat = (Start.Y + (lotRatio * (End.Y - Start.Y)));
            double lotCenterLon = (Start.X + (lotRatio * (End.X - Start.X)));

            ret.Y = lotCenterLat;
            ret.X = lotCenterLon;

            return ret;
        }


        #region Cloning Functions

        object ICloneable.Clone()
        {
            return Clone();
        }

        public new OneSidedStreet Clone()
        {
            OneSidedStreet x = (OneSidedStreet)MemberwiseClone();
            return x;
        }

        #endregion
    }
}