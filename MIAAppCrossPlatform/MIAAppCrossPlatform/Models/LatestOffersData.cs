using System;
using System.Collections.Generic;
using System.Text;

namespace MIAAppCrossPlatform.Models
{
	class LatestOffersData:IComparable
	{
		private string categoryName;
		private string partnerName;
		private string offerName;
		private string partnerImageUrl;
		private DateTime dateOfOffer;

		public LatestOffersData(string _categoryName, string _partnerName, string _offerName, string _partnerImageUrl, DateTime _dateOfOffer)
		{
			categoryName = _categoryName;
			partnerName = _partnerName;
			offerName = _offerName;
			partnerImageUrl = _partnerImageUrl;
			dateOfOffer = _dateOfOffer;
		}

		public string getCategoryName()
		{
			return categoryName;
		}

		public string getPartnerName()
		{
			return partnerName;
		}

		public string getOfferName()
		{
			return offerName;
		}

		public string getPartnerImageUrl()
		{
			return partnerImageUrl;
		}

		public DateTime getDateTime()
		{
			return dateOfOffer;
		}

		public int CompareTo(object obj)
		{
			LatestOffersData latest = (LatestOffersData)obj;

			if (getDateTime() == null || latest.getDateTime() == null)
			{
				return 0;
			}
			return getDateTime().CompareTo(latest.getDateTime());
		}
	}
}
