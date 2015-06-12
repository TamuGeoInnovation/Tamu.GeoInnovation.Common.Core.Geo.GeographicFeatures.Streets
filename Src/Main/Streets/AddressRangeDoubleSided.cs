namespace USC.GISResearchLab.Common.GeographicFeatures.Streets
{
	/// <summary>
	/// Summary description for AddressSegmentDoubleSided.
	/// </summary>
	public class AddressRangeDoubleSided
    {
        #region Properties
        private string _Id;
        private string _Source;
        private AddressRange _Left;
        private AddressRange _Right;

        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string Source
        {
            get { return _Source; }
            set { _Source = value; }
        }
        public AddressRange Left
        {
            get { return _Left; }
            set { _Left = value; }
        }
        public AddressRange Right
        {
            get { return _Right; }
            set { _Right = value; }
        }
        #endregion

        public AddressRangeDoubleSided()
		{
		}

		public AddressRange getEvenSide()
		{
			AddressRange ret;
			if (Left.IsEven)
			{
				ret = Left;
			}
			else
			{
				ret = Right;
			}
			return ret;
			
		}

		public AddressRange getOddSide()
		{
			AddressRange ret;
			if (Left.IsOdd)
			{
				ret = Left;
			}
			else
			{
				ret = Right;
			}
			return ret;
		}
	}
}
