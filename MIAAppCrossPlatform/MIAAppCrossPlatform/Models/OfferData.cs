using System;
using System.Collections.Generic;
using System.Text;

namespace MIAAppCrossPlatform.Models
{
	class OfferData
	{
		private string offerId;
		private string offerName;

		public OfferData(string _offerId, string _offerName)
		{
			offerId = _offerId;
			offerName = _offerName;
		}

		public string getOfferId()
		{
			return offerId;
		}

		public string getOfferName()
		{
			return offerName;
		}
	}
}
