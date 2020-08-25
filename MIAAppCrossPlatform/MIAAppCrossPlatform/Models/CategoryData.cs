using System;
using System.Collections.Generic;
using System.Text;

namespace MIAAppCrossPlatform.Models
{
	class CategoryData
	{
		private string categoryId;
		private string categoryName;
		private string catPartnerId;
		private string catPartnerName;
		private string categoryImageURL;

		public CategoryData(string _categoryId, string _catPartnerId, string _categoryName, string _catPartnerName, string _categoryImageURL)
		{
			categoryId = _categoryId;
			catPartnerId = _catPartnerId;
			categoryName = _categoryName;
			catPartnerName = _catPartnerName;
			categoryImageURL = _categoryImageURL;
		}

		public string getCategoryID()
		{
			return categoryId;
		}

		public string getCatPartnerID()
		{
			return catPartnerId;
		}

		public string getCategoryName()
		{
			return categoryName;
		}

		public string getCatPartnerName()
		{
			return catPartnerName;
		}

		public string getCategoryImageURL()
		{
			return categoryImageURL;
		}
	}
}
