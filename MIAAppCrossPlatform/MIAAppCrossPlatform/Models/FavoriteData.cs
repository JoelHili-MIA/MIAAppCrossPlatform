using System;
using System.Collections.Generic;
using System.Text;

namespace MIAAppCrossPlatform.Models
{
	class FavoriteData
	{
		private string categoryId;
		private string partnerId;
		private string categoryName;
		private string partnerName;
		private string partnerImageURL;

		public FavoriteData(string _categoryId, string _partnerId, string _categoryName, string _partnerName, string _partnerImageURL)
		{
			categoryId = _categoryId;
			partnerId = _partnerId;
			categoryName = _categoryName;
			partnerName = _partnerName;
			partnerImageURL = _partnerImageURL;
		}

		public string getFavCategoryId()
		{
			return categoryId;
		}

		public string getFavPartnerId()
		{
			return categoryId;
		}

		public string getFavCategoryName()
		{
			return categoryName;
		}

		public string getFavPartnerName()
		{
			return categoryId;
		}

		public string getFavPartnerImageUrl()
		{
			return partnerImageURL;
		}
	}
}
