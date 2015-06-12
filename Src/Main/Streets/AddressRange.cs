using System;
using USC.GISResearchLab.Common.Addresses;
using USC.GISResearchLab.Common.Utils.Numbers;
using USC.GISResearchLab.Common.Utils.Strings;

namespace USC.GISResearchLab.Common.GeographicFeatures.Streets
{
	/// <summary>
	/// Summary description for AddressSegment.
	/// </summary>
	public class AddressRange
    {
        #region Properties

        public string Error { get; set; }
        public bool ExceptionOccurred { get; set; }
        public Exception Exception { get; set; }

        public string Id { get; set; }
        public int FromAddress { get; set; }
        public int ToAddress { get; set; }
        public bool IsLeft { get; set; }
        public bool IsRight { get; set; }
        public bool IsEven { get; set; }
        public bool IsOdd { get; set; }
        public int[] Addresses { get; set; }

        public int Size
        {
            get
            {
                int ret = 1;
                if (FromAddress >= 0 && ToAddress >= 0)
                {
                    ret = Math.Abs(FromAddress - ToAddress) + 1;
                }
                return ret;
            }
        }

        public bool IsValidRange
        {
            get
            {
                return FromAddress > 0 && ToAddress > 0;
            }
        }

        public StreetNumberRangeParity StreetNumberRangeParity { get; set; }
        public StreetSide StreetSide { get; set; }
        public StreetNumberRangeOrderType StreetNumberRangeOrderType { get; set; }
        public StreetNumberRangeType StreetNumberRangeType { get; set; }
        public StreetNumberRangeNumericSubType StreetNumberRangeNumericSubType { get; set; }

        #endregion

        public AddressRange()
        {
            Addresses = new int[0];
            FromAddress = -1;
            ToAddress = -1;
        }

        public AddressRange(int from, int to)
        {
            try
            {
                FromAddress = from;
                ToAddress = to;

                StreetNumberRangeType = StreetNumberRangeType.Numeric;
                StreetNumberRangeNumericSubType = StreetNumberRangeNumericSubType.Normal;

                int fromParity = FromAddress % 2;
                int toParity = ToAddress % 2;

                if (fromParity == toParity)
                {
                    if (fromParity == 0)
                    {
                        StreetNumberRangeParity = StreetNumberRangeParity.Even;
                    }
                    else
                    {
                        StreetNumberRangeParity = StreetNumberRangeParity.Odd;
                    }
                }
                else
                {
                    StreetNumberRangeParity = StreetNumberRangeParity.Both;
                }


                if (FromAddress < ToAddress)
                {
                    StreetNumberRangeOrderType = StreetNumberRangeOrderType.LowHi;
                }
                else
                {
                    StreetNumberRangeOrderType = StreetNumberRangeOrderType.HiLow;
                }
            }
            catch (Exception ex)
            {
                Exception = ex;
                ExceptionOccurred = true;
                Error = ex.Message;
            }

        }

        public AddressRange(string from, string to)
        {
            try
            {
                if (!String.IsNullOrEmpty(from) && !String.IsNullOrEmpty(to))
                {


                    if ((NumberUtils.IsInt(from)) && (NumberUtils.IsInt(to)))
                    {
                        StreetNumberRangeType = StreetNumberRangeType.Numeric;
                        StreetNumberRangeNumericSubType = StreetNumberRangeNumericSubType.Normal;

                        FromAddress = Convert.ToInt32(from);
                        ToAddress = Convert.ToInt32(to);
                    }
                    else if ((NumberUtils.isAnyTypeOfNumber(from)) && (NumberUtils.isAnyTypeOfNumber(to)))
                    {
                        StreetNumberRangeType = StreetNumberRangeType.Numeric;

                        if ((NumberUtils.isDashedNumber(from)) && (NumberUtils.isDashedNumber(to)))
                        {
                            StreetNumberRangeNumericSubType = StreetNumberRangeNumericSubType.Dashed;

                            FromAddress = NumberUtils.GetLeadingNumerals(from);
                            ToAddress = NumberUtils.GetLeadingNumerals(from);

                        }
                        else
                        {
                            throw new NotImplementedException("Address range is some type of number");
                        }
                    }
                    else if ((NumberUtils.ContainsNumeral(from)) && (NumberUtils.ContainsNumeral(to)))
                    {
                        StreetNumberRangeType = StreetNumberRangeType.AlphaNumeric;
                        throw new NotImplementedException("Alpha numeric address ranges are not implemented");
                    }
                    else
                    {
                        StreetNumberRangeType = StreetNumberRangeType.Alpha;
                        StreetNumberRangeNumericSubType = StreetNumberRangeNumericSubType.None;
                        throw new NotImplementedException("Alphabetic address ranges are not implemented");
                    }


                    if (StreetNumberRangeType == StreetNumberRangeType.Numeric)
                    {
                        int fromParity = FromAddress % 2;
                        int toParity = ToAddress % 2;

                        if (fromParity == toParity)
                        {
                            if (fromParity == 0)
                            {
                                StreetNumberRangeParity = StreetNumberRangeParity.Even;
                            }
                            else
                            {
                                StreetNumberRangeParity = StreetNumberRangeParity.Odd;
                            }
                        }
                        else
                        {
                            StreetNumberRangeParity = StreetNumberRangeParity.Both;
                        }

                        if (FromAddress == ToAddress)
                        {
                            StreetNumberRangeOrderType = StreetNumberRangeOrderType.SingleNumber;
                        }
                        else
                        {
                            if (FromAddress < ToAddress)
                            {
                                StreetNumberRangeOrderType = StreetNumberRangeOrderType.LowHi;
                            }
                            else
                            {
                                StreetNumberRangeOrderType = StreetNumberRangeOrderType.HiLow;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Exception = ex;
                ExceptionOccurred = true;
                Error = ex.Message;
            }
        }

        public void generateAddresses(bool onlyOddOrEven)
        {
            if (FromAddress > ToAddress)
            {
                int temp = FromAddress;
                FromAddress = ToAddress;
                ToAddress = temp;
            }

            int size = ToAddress - FromAddress;
            if (onlyOddOrEven)
            {
                size = size / 2;
            }

            // include the Geometry.Ends
            size++;

            int[] addressArray = new int[size];
            int current = FromAddress;
            for (int index = 0; index < size; index++)
            {
                addressArray[index] = current;
                if (onlyOddOrEven)
                {
                    current++;
                }
                current++;
            }
            Addresses = addressArray;
        }


        public int getNumberOfLots()
        {
            return getNumberOfAddresses();
        }


        public int getLotNumber(int number)
        {
            return getClosestIndexTo(number);
        }

        public int getNumberAbove(int number)
        {
            int count = 0;
            int index = getIndexOf(number);
            for (int i = index + 1; i < getNumberOfAddresses(); i++)
            {
                count++;
            }
            return count;
        }

        public int getNumberBelow(int number)
        {
            int count = 0;
            int index = getIndexOf(number);
            for (int i = 0; i < index; i++)
            {
                count++;
            }
            return count;
        }

		public void addAddress(int number)
		{
			if (Addresses == null)
			{
				Addresses = new int[1];
				Addresses[0] = number;
			}
			else
			{
				int [] old = Addresses;
				Addresses = new int[old.Length + 1];
				for (int i=0; i<old.Length; i++)
				{
					Addresses[i] = old[i];
				}
				Addresses[Addresses.Length-1] = number;
			}
		}

		public int getAddressAt(int index)
		{
			return Addresses[index];
		}

		public int[] getAddresses()
		{
			return Addresses;
		}

		public int getNumberOfAddresses()
		{
			int ret = 0;
			if (Addresses != null)
			{
				ret = Addresses.Length;
			}
			return ret;
		}

        public bool Contains(int number)
        {
            return Contains(number, false);
        }

		public bool Contains(int number, bool useActualValues)
		{
			bool ret = false;
            if (IsValidRange)
            {
                if (number > 0)
                {
                    if (useActualValues)
                    {
                        ret = ContainsActualValue(number);
                    }
                    else
                    {
                        if (StreetNumberRangeOrderType == StreetNumberRangeOrderType.LowHi)
                        {
                            ret = number >= FromAddress && number <= ToAddress;
                        }
                        else if (StreetNumberRangeOrderType == StreetNumberRangeOrderType.HiLow)
                        {
                            ret = number >= ToAddress && number <= FromAddress;
                        }
                        else if (StreetNumberRangeOrderType == StreetNumberRangeOrderType.SingleNumber)
                        {
                            ret = number == ToAddress;
                        }
                    }
                }
            }
            return ret;
		}

        public bool ContainsActualValue(int number)
        {
            bool ret = false;
            if (number > 0)
            {
                for (int i = 0; i < getNumberOfAddresses(); i++)
                {
                    if (getAddressAt(i) == number)
                    {
                        ret = true;
                    }
                }
            }
            return ret;
        }

        public bool Contains(AddressRange addressRange)
        {
            bool ret = false;
            if (IsValidRange)
            {
                if (addressRange != null)
                {
                    if (addressRange.IsValidRange)
                    {
                        if (this.Contains(addressRange.FromAddress) && this.Contains(addressRange.ToAddress))
                        {
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        public bool IsContainedBy(AddressRange addressRange)
        {
            bool ret = false;
            if (IsValidRange)
            {
                if (addressRange != null)
                {
                    if (addressRange.IsValidRange)
                    {
                        if (addressRange.Contains(this))
                        {
                            ret = true;
                        }
                    }
                }
            }

            return ret;
        }

        public bool IsDisjointFrom(AddressRange addressRange)
        {
            bool ret = false;
            if (IsValidRange)
            {
                if (addressRange != null)
                {
                    if (addressRange.IsValidRange)
                    {
                        if (!this.Contains(addressRange.FromAddress) && !this.Contains(addressRange.ToAddress))
                        {
                            if (!this.IsContainedBy(addressRange))
                            {
                                ret = true;
                            }
                        }
                    }
                }
            }

            return ret;
        }

        public bool IsEquivalentTo(AddressRange addressRange)
        {
            bool ret = false;
            if (IsValidRange)
            {
                if (addressRange != null)
                {
                    if (addressRange.IsValidRange)
                    {
                        if (FromAddress == addressRange.FromAddress && ToAddress == addressRange.ToAddress)
                        {
                            ret = true;
                        }
                    }
                }
            }

            return ret;
        }

        public bool IsEquivalentToReversed(AddressRange addressRange)
        {
            bool ret = false;
            if (IsValidRange)
            {
                if (addressRange != null)
                {
                    if (addressRange.IsValidRange)
                    {
                        if (FromAddress == addressRange.ToAddress && ToAddress == addressRange.FromAddress)
                        {
                            ret = true;
                        }
                    }
                }
            }

            return ret;
        }

        public bool Intersects(AddressRange addressRange)
        {
            bool ret = false;
            if (IsValidRange)
            {
                if (addressRange != null)
                {
                    if (addressRange.IsValidRange)
                    {
                        int minFrom = Math.Min(Math.Abs(addressRange.FromAddress - FromAddress), Math.Abs(addressRange.FromAddress - ToAddress));
                        int minTo = Math.Min(Math.Abs(addressRange.ToAddress - FromAddress), Math.Abs(addressRange.ToAddress - ToAddress));

                        if (minFrom == 0 || minTo == 0)
                        {
                            ret = true;
                        }
                    }

                }
            }
            return ret;
        }

        public bool IsNextTo(AddressRange addressRange)
        {
            bool ret = false;
            if (IsValidRange)
            {
                if (addressRange != null)
                {
                    if (addressRange.IsValidRange)
                    {
                        int minFrom = Math.Min(Math.Abs(addressRange.FromAddress - FromAddress), Math.Abs(addressRange.FromAddress - ToAddress));
                        int minTo = Math.Min(Math.Abs(addressRange.ToAddress - FromAddress), Math.Abs(addressRange.ToAddress - ToAddress));

                        if (minFrom <= 6 || minTo <= 6)
                        {
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        public bool Overlaps(AddressRange addressRange)
        {
            bool ret = false;
            if (IsValidRange)
            {
                if (addressRange != null)
                {
                    if (addressRange.IsValidRange)
                    {
                        if (!this.Contains(addressRange) && !this.IsContainedBy(addressRange))
                        {
                            if (this.Contains(addressRange.FromAddress) || this.Contains(addressRange.ToAddress))
                            {
                                ret = true;
                            }
                        }
                    }
                }
            }

            return ret;
        }

        public int DistanceFrom(string numberString)
        {
            int ret = Int32.MaxValue;

            if (IsValidRange)
            {
                if (StringUtils.IsInt(numberString))
                {
                    int number = Convert.ToInt32(numberString);
                    if (number != 0)
                    {

                        if (!this.Contains(number))
                        {
                            ret = Math.Min(Math.Abs(number - FromAddress), Math.Abs(number - ToAddress));
                        }
                        else
                        {
                            ret = 0;
                        }

                    }
                }
            }

            return ret;
        }

        public int DistanceFrom(int number)
        {
            int ret = Int32.MaxValue;

            if (IsValidRange)
            {
                if (number != 0)
                {
                    if (!this.Contains(number))
                    {
                        ret = Math.Min(Math.Abs(number - FromAddress), Math.Abs(number - ToAddress));
                    }
                    else
                    {
                        ret = 0;
                    }
                }
            }

            return ret;
        }

        public int DistanceFrom(AddressRange addressRange)
        {
            int ret = Int32.MaxValue;

            if (IsValidRange)
            {
                if (addressRange != null)
                {
                    if (addressRange.IsValidRange)
                    {
                        int minFrom = Math.Min(Math.Abs(addressRange.FromAddress - FromAddress), Math.Abs(addressRange.FromAddress - ToAddress));
                        int minTo = Math.Min(Math.Abs(addressRange.ToAddress - FromAddress), Math.Abs(addressRange.ToAddress - ToAddress));
                        ret = Math.Min(minFrom, minTo);
                    }
                }
            }
            return ret;
        }

		public int getIndexOf(int number)
		{
			int ret = -1;
			for (int i=0; i<getNumberOfAddresses(); i++)
			{
				if (getAddressAt(i) == number)
				{
					ret = i;
				}
			}
			return ret;
		}


		public int getClosestNumberTo(int number)
		{
			int ret = -1;
			int closestIndex = getClosestIndexTo(number);
			if (closestIndex >= 0)
			{
				ret = getAddressAt(closestIndex);
			}
			return ret;
		}

		public int getClosestIndexTo(int number)
		{
			int closest = -1;
			for (int i=0; i<getNumberOfAddresses(); i++)
			{
				if (closest < 0)
				{
					closest = 0;
				}
				int current = getAddressAt(i);
				
				if ((Math.Abs(current - number)) < (Math.Abs(getAddressAt(closest) - number)))
				{
					closest = i;
					if ((Math.Abs(getAddressAt(closest) - number) == 0))
					{
						i = getNumberOfAddresses();
					}
				}
				
			}
			return closest;
		}

		public int jumpIterator(int index, int position, bool oddOrEvenOnly)
		{
			int ret;

			// if we found less than 500 addresses by passing no address, then we should exit the range loop
			if (position == 0)
			{
				ret = getNumberOfAddresses() + 1;
			}
				// else we should jump to the next number in the current position of the addressRange
			else
			{
				int newAddress = jumpAddress(index, position, oddOrEvenOnly);
				if (Contains(newAddress))
				{
					ret = getIndexOf(newAddress);
				}
				else
				{
					ret = getNumberOfAddresses() + 1;
				}
			}
			return ret;
		}

		public int jumpAddress(int index, int position, bool oddOrEvenOnly)
		{
			int ret = -1;
			if (position > 0)
			{
				int oldValue = getAddressAt(index);
				int exp = (oldValue.ToString().Length) - position;
				int add = (int) Math.Pow(10.0, exp);
				ret = oldValue + add;
				if (oddOrEvenOnly)
				{
					ret++;
				}
			}
			return ret;
		}

        public override string ToString()
        {
            return FromAddress + "-" + ToAddress;
        }
	}
}
