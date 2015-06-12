using System;
using USC.GISResearchLab.Common.Utils.Strings;

namespace USC.GISResearchLab.Common.GeographicFeatures.Streets
{
    public class Lanes
    {

        public const double DEFAULT_ROAD_LANES = 1.0;
        public const double AVERAGE_LANE_WIDTH_METERS = 3.5;
        public const double ROAD_SINGLE_LANE = 1.0;
        public const double ROAD_DOUBLE_OR_TRIPLE_LANE = 2.5;
        public const double ROAD_QUADRUPLE_OR_MORE_LANE = 4.0;

        public static double ToMeters(double numberOfLanes)
        {
            return numberOfLanes * AVERAGE_LANE_WIDTH_METERS;
        }

        public static double FromTIGERRoadClass(string tigerRoadClass)
        {
            double ret = -1.0;
            if (!String.IsNullOrEmpty(tigerRoadClass))
            {
                if (tigerRoadClass.StartsWith("A"))
                {
                    char type = tigerRoadClass[1];
                    if (type == '1' || type == '2')
                    {
                        ret = ROAD_QUADRUPLE_OR_MORE_LANE;
                    }
                    else if (type == '3' || type == '4')
                    {
                        ret = ROAD_SINGLE_LANE;
                    }
                }
            }
            return ret;
        }

        public static double FromNAVTECHRoadClass(string navtechRoadClass)
        {
            double ret = -1.0;
            if (!String.IsNullOrEmpty(navtechRoadClass))
            {
                if (StringUtils.AreEqualIgnoreCase(navtechRoadClass, "1"))
                {
                    ret = ROAD_SINGLE_LANE;
                }
                else if (StringUtils.AreEqualIgnoreCase(navtechRoadClass, "2"))
                {
                    ret = ROAD_DOUBLE_OR_TRIPLE_LANE;
                }
                else if (StringUtils.AreEqualIgnoreCase(navtechRoadClass, "3"))
                {
                    ret = ROAD_QUADRUPLE_OR_MORE_LANE;
                }
            }
            return ret;
        }
    }
}
