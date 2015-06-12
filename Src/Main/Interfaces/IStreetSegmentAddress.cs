using System;
using USC.GISResearchLab.Common.Addresses;
using USC.GISResearchLab.Common.GeographicFeatures.Streets;

namespace USC.GISResearchLab.Common.Core.Addresses.Interfaces
{
    public interface IStreetSegmentAddress : IStreetAddressBase
    {
        #region Properties

        string StreetId { get; set; }
        String AddressRangeFromRaw { get; set; }
        String AddressRangeToRaw { get; set; }
        AddressRange AddressRangeMajor { get; set; }
        AddressRange AddressRangeMinor { get; set; }
        AddressRange AddressRangeHouseNumberRangeMajor { get; set; }
        AddressRange AddressRangeHouseNumberRangeMinor { get; set; }

        

        StreetNumberRangeType StreetNumberRangeType { get; set; }
        StreetNumberRangeNumericSubType StreetNumberRangeNumericSubType { get; set; }

        double NumberOfLots { get; set; }
        double NumberOfLanes { get; set; }
        string LaneCategoryStr { get; set; }

        #endregion
    }
}
