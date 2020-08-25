using System;
using System.Collections.Generic;
using System.Text;

namespace MIAAppCrossPlatform.Models
{
	class PartnerData
	{
		private string partnerId;
		private string partnerName;
		private string partnerImageUrl;

		public PartnerData(string _partnerId, string _partnerName, string _partnerImageUrl)
		{
			partnerId = _partnerId;
			partnerName = _partnerName;
			partnerImageUrl = _partnerImageUrl;
		}

		public string getPartnerId()
		{
			return partnerId;
		}

		public string getPartnerName()
		{
			return partnerName;
		}

		public string getPartnerImageUrl()
		{
			return partnerImageUrl;
		}
	}
}
