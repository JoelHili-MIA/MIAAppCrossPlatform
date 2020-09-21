using FireSharp;
using FireSharp.Config;
using System.Threading.Tasks;
using Xunit;

namespace MIAAppCrossPlatform.Tests
{
	public class AuthenticationTests
	{
		[Fact]
		public async Task AuthenticationTest_Success()
		{
			var config = new FirebaseConfig
			{
				AuthSecret = "Wszbmo22cRpHCY8mhZVyN5kAmaGdJK6qhLYvjWPa",//Password of Firebase to get data: use this(Wszbmo22cRpHCY8mhZVyN5kAmaGdJK6qhLYvjWPa)
				BasePath = "https://mia-database-45d86.firebaseio.com/"//Address of Firebase
			};

			var client = new FirebaseClient(config);
			var response = await client.GetAsync("credentials/123");
		}
	}
}
