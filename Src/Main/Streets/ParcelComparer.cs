using System.Collections;
using USC.GISResearchLab.Common.GeographicFeatures.Parcels;
using USC.GISResearchLab.Common.Geometries.Lines;
using USC.GISResearchLab.Common.Utils.Strings;

namespace USC.GISResearchLab.Common.GeographicFeatures.Streets
{
	/// <summary>
	/// Summary description for DimensionComparer.
	/// </summary>
	public class ParcelComparer : IComparer
	{
		private Line.sortOrder compType;

        public ParcelComparer(Line.sortOrder sortOrder)
		{
			compType = sortOrder;
		}

		public int Compare(object x, object y)
		{
			Parcel xDim = (Parcel) x;
			double xNumber = StringUtils.ToDouble(xDim.NumberStr);
			Parcel yDim = (Parcel) y;
			double yNumber = StringUtils.ToDouble(yDim.NumberStr);

			switch(compType)
			{
                case Line.sortOrder.sortAsc:
					return (xNumber.CompareTo(yNumber));
                case Line.sortOrder.sortDesc:
					return (yNumber.CompareTo(xNumber));
				default:
					return (xNumber.CompareTo(yNumber));
			}
		}

	}
}
