using USC.GISResearchLab.Common.GeographicFeatures.Streets;

namespace USC.GISResearchLab.Common.Core.Geographics.Features.Streets
{

    public enum AddressRangeRelationship { Equal, EqualReversed, DisjointFrom, Overlaps, Contains, ContainedBy, Intersects, NextTo, FirstNull, SecondNull, BothNull, Unknown }

    public class AddressRangeComparator
    {

        public static AddressRangeRelationship GetRelationship(AddressRange a, AddressRange b)
        {
            AddressRangeRelationship ret = AddressRangeRelationship.BothNull;

            if (a != null && b != null)
            {
                if (!a.IsValidRange && !b.IsValidRange)
                {
                    ret = AddressRangeRelationship.BothNull;
                }
                else if (a == null)
                {
                    ret = AddressRangeRelationship.FirstNull;
                }
                else if (!a.IsValidRange)
                {
                    ret = AddressRangeRelationship.FirstNull;
                }
                else if (b == null)
                {
                    ret = AddressRangeRelationship.SecondNull;
                }
                else if (!b.IsValidRange)
                {
                    ret = AddressRangeRelationship.SecondNull;
                }
                else
                {
                    if (a.IsEquivalentTo(b))
                    {
                        ret = AddressRangeRelationship.Equal;
                    }
                    if (a.IsEquivalentToReversed(b))
                    {
                        ret = AddressRangeRelationship.EqualReversed;
                    }
                    else if (a.Overlaps(b))
                    {
                        ret = AddressRangeRelationship.Overlaps;
                    }
                    else if (a.Contains(b))
                    {
                        ret = AddressRangeRelationship.Contains;
                    }
                    else if (a.IsContainedBy(b))
                    {
                        ret = AddressRangeRelationship.ContainedBy;
                    }
                    else if (a.Intersects(b))
                    {
                        ret = AddressRangeRelationship.Intersects;
                    }
                    else if (a.IsNextTo(b))
                    {
                        ret = AddressRangeRelationship.NextTo;
                    }
                    else if (a.IsDisjointFrom(b))
                    {
                        ret = AddressRangeRelationship.DisjointFrom;
                    }
                    else
                    {
                        ret = AddressRangeRelationship.Unknown;
                    }
                }
            }

            return ret;
        }

        public static int DistanceBetween(AddressRange a, AddressRange b)
        {
            return a.DistanceFrom(b);
        }

    }
}
