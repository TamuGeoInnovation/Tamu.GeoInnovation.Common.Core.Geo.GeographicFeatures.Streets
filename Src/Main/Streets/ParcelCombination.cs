namespace USC.GISResearchLab.Common.GeographicFeatures.Streets
{
    /// <summary>
    /// Summary description for CombinationDimension.
    /// </summary>
    public class ParcelCombination
    {
        private int _Id;
        private double _Error;
        private Street _Street;
        private double _NumberOfLots;

        public ParcelCombination()
        {
            _Id = -1;
            _Error = -1;
            _NumberOfLots = 0;
        }

        public double NumberOfLots
        {
            get { return _NumberOfLots; }
            set { _NumberOfLots = value; }
        }

        public double Error
        {
            get { return _Error; }
            set { _Error = value; }
        }

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public Street Street
        {
            get { return _Street; }
            set { _Street = value; }
        }
    }
}
