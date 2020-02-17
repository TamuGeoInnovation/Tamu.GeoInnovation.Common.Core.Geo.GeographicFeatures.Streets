namespace USC.GISResearchLab.Common.GeographicFeatures.Streets
{
    /// <summary>
    /// Summary description for CombinationDimension.
    /// </summary>
    public class ParcelCombination
    {

        public ParcelCombination()
        {
            Id = -1;
            Error = -1;
            NumberOfLots = 0;
        }

        public double NumberOfLots { get; set; }

        public double Error { get; set; }

        public int Id { get; set; }

        public Street Street { get; set; }
    }
}
