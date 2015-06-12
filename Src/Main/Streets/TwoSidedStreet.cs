using System;
using USC.GISResearchLab.Common.Geometries.Lines;
using USC.GISResearchLab.Common.Geometries.Points;

namespace USC.GISResearchLab.Common.GeographicFeatures.Streets
{
    public class TwoSidedStreet : Line, ICloneable
    {
        #region Properties

        private string _Id;
        public new string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Source;
        public string Source
        {
            get { return _Source; }
            set { _Source = value; }
        }

        private OneSidedStreet _LeftSide;
        public OneSidedStreet LeftSide
        {
            get { return _LeftSide; }
            set { _LeftSide = value; }
        }

        private OneSidedStreet _RightSide;
        public OneSidedStreet RightSide
        {
            get { return _RightSide; }
            set { _RightSide = value; }
        }

        #endregion

        public TwoSidedStreet()
        {
        }

        public TwoSidedStreet(Point start, Point end)
            :base(start, end)
        {
            Start = start;
            End = end;
        }

        #region Cloning Functions

        object ICloneable.Clone()
        {
            return Clone();
        }

        public new TwoSidedStreet Clone()
        {
            TwoSidedStreet x = (TwoSidedStreet)MemberwiseClone();
            return x;
        }

        #endregion
    }
}