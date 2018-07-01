using System;
using Xunit;
using CognologyApp;

namespace CognologyAppTest
{
    public class ValidatorTest
    {
        [Theory]
        [InlineData ("2018-08-01,2018-08-02,3")]
        public void StartDateLessThanEndDate(string data)
        {
            //Arrange
            Validator validator = new Validator();
            string[] arrayData = data.Split(',');

            //Act
            var retValue = validator.CheckAvailability(Convert.ToDateTime(arrayData[0]),
                Convert.ToDateTime(arrayData[1]),
                Convert.ToInt16(arrayData[2]));

            //Assert
            Assert.True(retValue);
        }

        [Theory]
        [InlineData("2018-07-01,2018-08-02,3")]
        public void StartDateIsNotPastDate(string data)
        {
            //Arrange
            Validator validator = new Validator();
            string[] arrayData = data.Split(',');

            //Act
            var retValue = validator.CheckAvailability(Convert.ToDateTime(arrayData[0]),
                Convert.ToDateTime(arrayData[1]),
                Convert.ToInt16(arrayData[2]));
            
            //Assert
            Assert.False(retValue);
            Assert.Contains("Start Date should not be past date", validator.ErrorResponse);
        }

        [Theory]
        [InlineData("2018-08-01,2018-06-02,3")]
        public void EndDateIsNotPastDate(string data)
        {
            //Arrange
            Validator validator = new Validator();
            string[] arrayData = data.Split(',');

            //Act
            var retValue = validator.CheckAvailability(Convert.ToDateTime(arrayData[0]),
                Convert.ToDateTime(arrayData[1]),
                Convert.ToInt16(arrayData[2]));

            //Assert
            Assert.False(retValue);
            Assert.Contains("End Date should not be past date", validator.ErrorResponse);
        }

        [Theory]
        [InlineData("2018-08-01,2018-08-02,3")]
        public void PaxIsGreaterThenZero(string data)
        {
            //Arrange
            Validator validator = new Validator();
            string[] arrayData = data.Split(',');

            //Act
            var retValue = validator.CheckAvailability(Convert.ToDateTime(arrayData[0]),
                Convert.ToDateTime(arrayData[1]),
                Convert.ToInt16(arrayData[2]));

            //Assert
            Assert.True(retValue);
        }
        [Theory]
        [InlineData("2018-11-01,2018-11-02,3")]
        public void StartDateIsNotGreaterThan60Days(string data)
        {
            //Arrange
            Validator validator = new Validator();
            string[] arrayData = data.Split(',');

            //Act
            var retValue = validator.CheckAvailability(Convert.ToDateTime(arrayData[0]),
                Convert.ToDateTime(arrayData[1]),
                Convert.ToInt16(arrayData[2]));

            //Assert
            Assert.False(retValue);
            Assert.Contains("The Start date Thursday, 1 November 2018 is too far to check the availability", validator.ErrorResponse);
        }
        [Theory]
        [InlineData("2018-08-01,2018-11-02,3")]
        public void EndDateIsNotGreaterThan60Days(string data)
        {
            //Arrange
            Validator validator = new Validator();
            string[] arrayData = data.Split(',');

            //Act
            var retValue = validator.CheckAvailability(Convert.ToDateTime(arrayData[0]),
                Convert.ToDateTime(arrayData[1]),
                Convert.ToInt16(arrayData[2]));

            //Assert
            Assert.False(retValue);
            Assert.Contains("The End date Friday, 2 November 2018 is too far to check the availability", validator.ErrorResponse);
        }

        [Theory]
        [InlineData("2018-08-02,2018-08-03,3")]
        public void IsFlightOperatesOnStartDate(string data)
        {
            //Arrange
            Validator validator = new Validator();
            string[] arrayData = data.Split(',');

            //Act
            var retValue = validator.CheckAvailability(Convert.ToDateTime(arrayData[0]),
                Convert.ToDateTime(arrayData[1]),
                Convert.ToInt16(arrayData[2]));

            //Assert
            Assert.True(retValue);
            
        }

        [Theory]
        [InlineData("2018-08-02,2018-08-03,3")]
        public void IsFlightOperatesOnEndDate(string data)
        {
            //Arrange
            Validator validator = new Validator();
            string[] arrayData = data.Split(',');

            //Act
            var retValue = validator.CheckAvailability(Convert.ToDateTime(arrayData[0]),
                Convert.ToDateTime(arrayData[1]),
                Convert.ToInt16(arrayData[2]));

            //Assert
            Assert.True(retValue);
        }
        [Theory]
        [InlineData("2018-08-02,2018-08-03,3")]
        public void IsAvailableSeatsOnStartDate(string data)
        {
            //Arrange
            Validator validator = new Validator();
            string[] arrayData = data.Split(',');

            //Act
            var retValue = validator.CheckAvailability(Convert.ToDateTime(arrayData[0]),
                Convert.ToDateTime(arrayData[1]),
                Convert.ToInt16(arrayData[2]));

            //Assert
            Assert.True(retValue);
        }
        [Theory]
        [InlineData("2018-08-02,2018-08-03,3")]
        public void IsAvailableSeatsOnEndDate(string data)
        {
            //Arrange
            Validator validator = new Validator();
            string[] arrayData = data.Split(',');

            //Act
            var retValue = validator.CheckAvailability(Convert.ToDateTime(arrayData[0]),
                Convert.ToDateTime(arrayData[1]),
                Convert.ToInt16(arrayData[2]));

            //Assert
            Assert.True(retValue);
        }

        [Theory]
        [InlineData("2018-08-02,2018-08-03,3")]
        public void IsAvailableSeats(string data)
        {
            //Arrange
            Validator validator = new Validator();
            string[] arrayData = data.Split(',');

            //Act
            var retValue = validator.CheckAvailability(Convert.ToDateTime(arrayData[0]),
                Convert.ToDateTime(arrayData[1]),
                Convert.ToInt16(arrayData[2]));

            //Assert
            Assert.True(retValue);
        }        
    }
}
