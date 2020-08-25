using System;
using System.Collections.Generic;
using System.Text;

namespace MIAAppCrossPlatform.Models
{
	class SavingsSectionData
	{
		private string partnerName;
		private string dateTime;
		private string savings;
		private string offer;
		private string categoryName;
		private string reference;

		public SavingsSectionData(string _partnerName, string _dateTime, string _savings, string _offer, string _categoryName, string _reference)
		{
			partnerName = _partnerName;
			dateTime = _dateTime;
			savings = _savings;
			offer = _offer;
			categoryName = _categoryName;
			reference = _reference;
		}

		public string getPartnerName()
		{
			return partnerName;
		}

		public string getDateTime()
		{
			return dateTime;
		}

		public string getSavings()
		{
			return savings;
		}

		public string getOffer()
		{
			return offer;
		}

		public string getCategoryName()
		{
			return categoryName;
		}

		public string getReference()
		{
			return reference;
		}
	}
}
