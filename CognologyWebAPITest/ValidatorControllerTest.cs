using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CognologyWebAPITest
{
    public class ValidatorControllerTest
    {
        [Theory]
        [InlineData("{\"StartDate\":\"2018-08-01\",\"EndDate\":\"2018-08-02\",\"Pax\":3}")]
        public async Task StartDateLessThanEndDate(string data)
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync($"/api/Validator/{data}");
                //Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                var responseString = await response.Content.ReadAsStringAsync();
                // Assert
                Assert.Equal("true", responseString);
            }

        }

        [Theory]
        [InlineData("{\"StartDate\":\"2018-07-01\",\"EndDate\":\"2018-08-02\",\"Pax\":3}")]
        public async Task StartDateIsNotPastDate(string data)
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync($"/api/Validator/{data}");               

                var responseString = await response.Content.ReadAsStringAsync();
                // Assert
                Assert.Equal("false", responseString);
            }

        }

        [Theory]
        [InlineData("{\"StartDate\":\"2018-08-01\",\"EndDate\":\"2018-06-02\",\"Pax\":3}")]
        public async Task EndDateIsNotPastDate(string data)
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync($"/api/Validator/{data}");               

                var responseString = await response.Content.ReadAsStringAsync();
                // Assert
                Assert.Equal("false", responseString);
            }

        }

        [Theory]
        [InlineData("{\"StartDate\":\"2018-08-01\",\"EndDate\":\"2018-08-02\",\"Pax\":3}")]
        public async Task PaxIsGreaterThenZero(string data)
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync($"/api/Validator/{data}");

                var responseString = await response.Content.ReadAsStringAsync();
                // Assert
                Assert.Equal("true", responseString);
            }

        }

        [Theory]
        [InlineData("{\"StartDate\":\"2018-11-01\",\"EndDate\":\"2018-11-02\",\"Pax\":3}")]
        public async Task StartDateIsNotGreaterThan60Days(string data)
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync($"/api/Validator/{data}");

                var responseString = await response.Content.ReadAsStringAsync();
                // Assert
                Assert.Equal("false", responseString);
            }

        }

        [Theory]
        [InlineData("{\"StartDate\":\"2018-08-01\",\"EndDate\":\"2018-11-02\",\"Pax\":3}")]
        public async Task EndDateIsNotGreaterThan60Days(string data)
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync($"/api/Validator/{data}");

                var responseString = await response.Content.ReadAsStringAsync();
                // Assert
                Assert.Equal("false", responseString);
            }

        }

        [Theory]
        [InlineData("{\"StartDate\":\"2018-08-02\",\"EndDate\":\"2018-08-03\",\"Pax\":3}")]
        public async Task IsFlightOperatesOnStartDate(string data)
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync($"/api/Validator/{data}");

                var responseString = await response.Content.ReadAsStringAsync();
                // Assert
                Assert.Equal("true", responseString);
            }

        }

        [Theory]
        [InlineData("{\"StartDate\":\"2018-08-02\",\"EndDate\":\"2018-08-03\",\"Pax\":3}")]
        public async Task IsFlightOperatesOnEndDate(string data)
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync($"/api/Validator/{data}");

                var responseString = await response.Content.ReadAsStringAsync();
                // Assert
                Assert.Equal("true", responseString);
            }

        }

        [Theory]
        [InlineData("{\"StartDate\":\"2018-08-02\",\"EndDate\":\"2018-08-03\",\"Pax\":3}")]
        public async Task IsAvailableSeatsOnStartDate(string data)
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync($"/api/Validator/{data}");

                var responseString = await response.Content.ReadAsStringAsync();
                // Assert
                Assert.Equal("true", responseString);
            }

        }

        [Theory]
        [InlineData("{\"StartDate\":\"2018-08-02\",\"EndDate\":\"2018-08-03\",\"Pax\":3}")]
        public async Task IsAvailableSeatsOnEndDate(string data)
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync($"/api/Validator/{data}");

                var responseString = await response.Content.ReadAsStringAsync();
                // Assert
                Assert.Equal("true", responseString);
            }

        }

        [Theory]
        [InlineData("{\"StartDate\":\"2018-08-02\",\"EndDate\":\"2018-08-03\",\"Pax\":3}")]
        public async Task IsAvailableSeats(string data)
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync($"/api/Validator/{data}");

                var responseString = await response.Content.ReadAsStringAsync();
                // Assert
                Assert.Equal("true", responseString);
            }

        }
    }
}
