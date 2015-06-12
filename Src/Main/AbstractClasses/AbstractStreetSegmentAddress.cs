using System;
using USC.GISResearchLab.Common.Core.Addresses.Interfaces;
using USC.GISResearchLab.Common.GeographicFeatures.Streets;
using USC.GISResearchLab.Common.Utils.Strings;

namespace USC.GISResearchLab.Common.Addresses.AbstractClasses
{


    public abstract class AbstractStreetSegmentAddress : AbstractStreetAddressBase, IStreetSegmentAddress, ICloneable
    {

        #region Properties

        public string StreetId { get; set; }
        public String AddressRangeFromRaw { get; set; }
        public String AddressRangeToRaw { get; set; }
        public AddressRange AddressRangeMajor { get; set; }
        public AddressRange AddressRangeMinor { get; set; }
        public AddressRange AddressRangeHouseNumberRangeMajor { get; set; }
        public AddressRange AddressRangeHouseNumberRangeMinor { get; set; }

        //public StreetNumberRangeParity StreetNumberRangeParity { get; set; }
        public StreetNumberRangeType StreetNumberRangeType { get; set; }
        public StreetNumberRangeNumericSubType StreetNumberRangeNumericSubType { get; set; }
        //public StreetSide StreetSide { get; set; }

        public double NumberOfLots { get; set; }
        public double NumberOfLanes { get; set; }
        public string LaneCategoryStr { get; set; }
       

        #endregion

        #region Constructors
        public AbstractStreetSegmentAddress()
        { }

        public AbstractStreetSegmentAddress(string number, string pre, string name, string post, string suffix)
            : this(number, pre, name, post, suffix, null, null, null, null, null, null)
        { }
        

        public AbstractStreetSegmentAddress(string number, string pre, string name, string post, string suffix, string suite, string suitenumber)
            : this(number, pre, name, post, suffix, suite, suitenumber, null, null, null, null)
        { }

        public AbstractStreetSegmentAddress(string number, string pre, string name, string suffix, string post, string city, string state, string zip)
            : this(number, pre, name, post, suffix, null, null, city, null, null, null)
        { }

        public AbstractStreetSegmentAddress(string number, string pre, string name, string suffix, string post, string city, string state, string zip, string country)
            : this(number, pre, name, post, suffix, null, null, city, state, zip, country)
        { }

        public AbstractStreetSegmentAddress(string number, string pre, string name, string suffix, string post, string suite, string suiteNumber, string city, string state, string zip)
            : this(number, pre, name, post, suffix, suite, suiteNumber, city, state, zip, null)
        { }

        public AbstractStreetSegmentAddress(string number, string pre, string name, string suffix, string post, string suite, string suiteNumber, string city, string state, string zip, string country)
            : base(pre, name, post, suffix, suite, suiteNumber, city, state, zip, country)
        {

            StreetNumberRangeParity = StreetNumberRangeParity.Unknown;
            StreetNumberRangeType = StreetNumberRangeType.Unknown;
            StreetNumberRangeNumericSubType = StreetNumberRangeNumericSubType.Unknown;
            StreetSide = StreetSide.Unknown;

        }

        #endregion

        public override string ToString()
        {
            string ret = "";
            //ret += StringUtils.ValueAndBlankOrNoBlank(AddressId);
            ret += StringUtils.ValueAndBlankOrNoBlank(PreDirectional);
            ret += StringUtils.ValueAndBlankOrNoBlank(StreetName);
            ret += StringUtils.ValueAndBlankOrNoBlank(Suffix);
            ret += StringUtils.ValueAndBlankOrNoBlank(PostDirectional);
            ret += StringUtils.ValueAndBlankOrNoBlank(City);

            if (!String.IsNullOrEmpty(ConsolidatedCity))
            {
                ret += StringUtils.ValueAndBlankOrNoBlank(ConsolidatedCity);
            }

            if (!String.IsNullOrEmpty(CountySubregion))
            {
                ret += StringUtils.ValueAndBlankOrNoBlank(CountySubregion);
            }

            if (!String.IsNullOrEmpty(County))
            {
                ret += StringUtils.ValueAndBlankOrNoBlank(County);
            }

            ret += StringUtils.ValueAndBlankOrNoBlank(State);
            ret += StringUtils.ValueOrNoBlank(ZIP);

            if (!String.IsNullOrEmpty(ZIPPlus4))
            {
                ret += "-" + StringUtils.ValueAndBlankOrNoBlank(ZIPPlus4);
            }
            else if (!String.IsNullOrEmpty(ZIPPlus3))
            {
                ret += "-" + StringUtils.ValueAndBlankOrNoBlank(ZIPPlus3);
            }
            else if (!String.IsNullOrEmpty(ZIPPlus2))
            {
                ret += "-" + StringUtils.ValueAndBlankOrNoBlank(ZIPPlus2);
            }
            else if (!String.IsNullOrEmpty(ZIPPlus1))
            {
                ret += "-" + StringUtils.ValueAndBlankOrNoBlank(ZIPPlus1);
            }

            ret += StringUtils.ValueOrNoBlank(Country);
            return ret;
        }

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return Clone();
        }

        public virtual StreetAddress Clone()
        {
            return (StreetAddress)MemberwiseClone();
        }

        #endregion

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(Object obj)
        {
            //check if obj isn't null, if it is return false 
            if (obj == null)
            {
                return false;
            }

            StreetAddress s = obj as StreetAddress;

            //if obj can't be casted as StreetAddress, return false 
            if (s == null)
            {
                return false;
            }

            //compare the values 
            if (String.Compare(this.PreDirectional, s.PreDirectional, true) == 0 &&
                String.Compare(this.PreQualifier, s.PreQualifier, true) == 0 &&
                String.Compare(this.StreetName, s.StreetName, true) == 0 &&
                String.Compare(this.Suffix, s.Suffix, true) == 0 &&
                String.Compare(this.PostDirectional, s.PostDirectional, true) == 0 &&
                String.Compare(this.PostQualifier, s.PostQualifier, true) == 0 &&
                String.Compare(this.SuiteType, s.SuiteType, true) == 0 &&
                String.Compare(this.SuiteNumber, s.SuiteNumber, true) == 0 &&
                String.Compare(this.City, s.City, true) == 0 &&
                String.Compare(this.ConsolidatedCity, s.ConsolidatedCity, true) == 0 &&
                String.Compare(this.MinorCivilDivision, s.MinorCivilDivision, true) == 0 &&
                String.Compare(this.CountySubregion, s.CountySubregion, true) == 0 &&
                String.Compare(this.County, s.County, true) == 0 &&
                String.Compare(this.Country, s.Country, true) == 0 &&
                String.Compare(this.State, s.State, true) == 0 &&
                String.Compare(this.ZIP, s.ZIP, true) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}