using System;
using System.Collections;
using USC.GISResearchLab.Common.Geometries.Bearings;
using USC.GISResearchLab.Common.Geometries.Directions;
using USC.GISResearchLab.Common.Geometries.Hands;
using USC.GISResearchLab.Common.Geometries.Lines;
using USC.GISResearchLab.Common.Geometries.Points;
using USC.GISResearchLab.Common.Geometries.Polygons;

namespace USC.GISResearchLab.Common.GeographicFeatures.Parcels
{
    /// <summary>
    /// Summary description for ParcelDimension.
    /// </summary>
    public class Parcel : Polygon, ICloneable
    {
        #region Properties

        private double _Depth;
        private double _DepthBearing;
        private string _DepthDirection;
        private string _DimensionError;
        private string _NumberStr;
        private double _Width;
        private double _WidthBearing;
        private string _WidthDirection;

        public string NumberStr
        {
            get { return _NumberStr; }
            set { _NumberStr = value; }
        }

        public double Width
        {
            get { return _Width; }
            set { _Width = value; }
        }

        public double Depth
        {
            get { return _Depth; }
            set { _Depth = value; }
        }

        public double WidthBearing
        {
            get { return _WidthBearing; }
            set { _WidthBearing = value; }
        }

        public double DepthBearing
        {
            get { return _DepthBearing; }
            set { _DepthBearing = value; }
        }

        public string WidthDirection
        {
            get { return _WidthDirection; }
            set { _WidthDirection = value; }
        }

        public string DepthDirection
        {
            get { return _DepthDirection; }
            set { _DepthDirection = value; }
        }

        public string DimensionError
        {
            get { return _DimensionError; }
            set { _DimensionError = value; }
        }

        #endregion

        public Parcel()
        {
            DimensionError = "";
            WidthDirection = "";
            DepthDirection = "";
            NumberStr = "";
        }

        public Parcel invert()
        {
            Parcel x = Clone();
            x.Width = Depth;
            x.Depth = Width;
            x.WidthBearing = DepthBearing;
            x.DepthBearing = WidthBearing;
            x.WidthDirection = DepthDirection;
            x.DepthDirection = WidthDirection;

            return x;
        }

        // this function builds a recatngular parcel from a set of coordinates
        public static Parcel RectangeFromRough(string parcelCoordinatesRough, double parcelBearing,
                                               double streetPrimaryBearing)
        {
            Parcel parcel = new Parcel();

            Polygon polygon = FromCoordinateString(parcelCoordinatesRough);

            Point[] points = polygon.Points;
            Line[] segments = polygon.Segments;

            if (segments != null && points != null)
            {
                Line last = segments[0].Clone();

                ArrayList corners = new ArrayList();

                int currentDirection = CardinalDirection.getDirection(last);
                int perpDirection = CardinalDirection.getPerpendicularDirection(currentDirection, Hand.HAND_RIGHT);

                // loop from the starting point to where it comes back to itself
                for (int i = 1; i < segments.Length; i++)
                {
                    Line next = segments[i].Clone();
                    int nextDirection = CardinalDirection.getDirection(next);
                    double angleFromLast = Line.AngleBetween(last, next);

                    // if the angle is less than 120 we have a corner of some sort
                    if (angleFromLast > 0 && angleFromLast < 120)
                    {
                        if (nextDirection == perpDirection)
                        {
                            corners.Add(next.Start);
                            last = next;
                            currentDirection =
                                CardinalDirection.getDirection(next.Start.X, next.Start.Y, next.End.X, next.End.Y);
                            perpDirection =
                                CardinalDirection.getPerpendicularDirection(currentDirection, Hand.HAND_RIGHT);
                        }
                        else
                        {
                            last.End = next.End;
                        }
                    }
                        // otherwise extend the current segment to the end of this one
                    else
                    {
                        last.End = next.End;
                    }
                }

                // now check if the starting point is a corner
                //Line startingSegment = 

                Line startingSegment = polygon.Segments[0].Clone();

                Point startingSegmentPoint = startingSegment.Start;
                Point endingSegmentPoint = startingSegment.End;

                int startingDirection =
                    CardinalDirection.getDirection(startingSegmentPoint.X, startingSegmentPoint.Y, endingSegmentPoint.X,
                                                   endingSegmentPoint.Y);

                double angleFromLastToStart = Line.AngleBetween(last, startingSegment);

                // if the angle is less than 120 we have a corner of some sort
                if (angleFromLastToStart < 120)
                {
                    if (startingDirection == perpDirection)
                    {
                        corners.Add(startingSegmentPoint);
                    }
                }


                if (corners.Count == 4)
                {

                    Point corner0 = (Point) corners[0];
                    Point corner1 = (Point) corners[1];
                    Point corner2 = (Point) corners[2];
                    Point corner3 = (Point) corners[3];

                    Line segment0 = new Line(corner0.Clone(), corner1.Clone());
                    Line segment1 = new Line(corner1.Clone(), corner2.Clone());
                    Line segment2 = new Line(corner2.Clone(), corner3.Clone());
                    Line segment3 = new Line(corner3.Clone(), corner0.Clone());

                    double segment0Distance = segment0.Length;
                    double segment1Distance = segment1.Length;
                    double segment2Distance = segment2.Length;
                    double segment3Distance = segment3.Length;


                    parcel.DepthBearing = parcelBearing;
                    parcel.WidthBearing = streetPrimaryBearing;


                    //dimension.depthDirection = CardinalDirection.getDirectionName(dropBackDirection);
                    //dimension.widthDirection = CardinalDirection.getDirectionName(getPerpendicularDirection(dropBackDirection, HAND_LEFT));
                    //int segment0Direction = CardinalDirection.getDirection(segment0);
                    //string segment0DirectionString = CardinalDirection.getDirectionName(segment0Direction);

                    //					if (dropBackDirection == segment0Direction)
                    //					{
                    //						dimension.depth = (segment0Distance + segment2Distance) / 2;
                    //						dimension.width = (segment1Distance + segment3Distance) / 2;
                    //					}
                    //					else
                    //					{
                    //						dimension.width = (segment0Distance + segment2Distance) / 2;
                    //						dimension.depth = (segment1Distance + segment3Distance) / 2;
                    //					}

                    if (Bearing.isWithinBearingThreshold(parcelBearing, segment0.Bearing, 15.0))
                    {
                        parcel.Depth = (segment0Distance + segment2Distance)/2;
                        parcel.Width = (segment1Distance + segment3Distance)/2;
                    }
                    else
                    {
                        parcel.Width = (segment0Distance + segment2Distance)/2;
                        parcel.Depth = (segment1Distance + segment3Distance)/2;
                    }
                }
                else
                {
                    parcel.DimensionError = "Lot is not rectangular";
                }
            }

            return parcel;
        }

        #region Cloning Functions

        object ICloneable.Clone()
        {
            return Clone();
        }

        public virtual Parcel Clone()
        {
            Parcel x = (Parcel) MemberwiseClone();

            x.NumberStr = NumberStr;
            x.Width = Width;
            x.Depth = Depth;
            x.WidthBearing = WidthBearing;
            x.DepthBearing = DepthBearing;
            x.WidthDirection = WidthDirection;
            x.DepthDirection = DepthDirection;
            x.DimensionError = DimensionError;

            return x;
        }

        #endregion
    }
}