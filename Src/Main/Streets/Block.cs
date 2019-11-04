using USC.GISResearchLab.Common.Geometries.Polygons;
using USC.GISResearchLab.Common.Utils.Strings;

namespace USC.GISResearchLab.Common.GeographicFeatures.Streets
{
    /// <summary>
    /// Summary description for SimpleSegmentBlockGroup.
    /// </summary>
    public class Block : Polygon
    {

        #region Properties
        private int _NumberOfSegments;
        private string _InfoString;
        private Street[] _Streets;
        private string _BlockGroupError;


        public int NumberOfSegments
        {
            get { return _NumberOfSegments; }
            set { _NumberOfSegments = value; }
        }
        public string InfoString
        {
            get { return _InfoString; }
            set { _InfoString = value; }
        }
        public Street[] Streets
        {
            get { return _Streets; }
            set { _Streets = value; }
        }
        public string BlockGroupError
        {
            get { return _BlockGroupError; }
            set { _BlockGroupError = value; }
        }
        #endregion

        public Block()
        {
            NumberOfSegments = 0;
            Valid = false;
            BlockGroupError = "";
            InfoString = "";
        }

        public void validate()
        {
            // make sure that there are 4 segments and it is a closed loop
            if (NumberOfSegments == 4)
            {
                if (Streets[0].Start.Y == Streets[3].End.Y && Streets[0].Start.X == Streets[3].End.X)
                {
                    Valid = true;
                }
                else
                {
                    BlockGroupError = "the segments comprising do not form a closed loop";
                }
            }
            else
            {
                BlockGroupError = "There are not 4 segments in the block";
            }
        }

        public void setInfoStrings()
        {
            for (int i = 0; i < Streets.Length; i++)
            {
                InfoString += Streets[i].InfoString;
                InfoString += ":";
                InfoString += Streets[i].ParcelsString;
                InfoString += ";";
            }
            InfoString = StringUtils.TrimEnd(InfoString, ";");
        }

        public void AddStreet(Street street)
        {
            if (Streets == null)
            {
                Streets = new Street[1];
                Streets[0] = street;
            }
            else
            {
                Street[] newStreets = new Street[Streets.Length + 1];
                for (int i = 0; i < Streets.Length; i++)
                {
                    newStreets[i] = Streets[i];
                }
                newStreets[newStreets.Length - 1] = street;
                Streets = newStreets;
            }
            NumberOfSegments++;
        }
    }
}

