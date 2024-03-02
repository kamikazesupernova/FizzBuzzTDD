using FizzBuzzTDD.Interfaces;
using FizzBuzzTDD.Services;

namespace FizzBuzzTDD.Tests.Services
{
    public class FizzBuzzServiceTests
    {
        private IFizzBuzzService _fizzBuzzService;

 
        public FizzBuzzServiceTests()
        {
            _fizzBuzzService = new FizzBuzzService();
        }

        [Fact]
        public void GenerateFizzBuzz_Returns_Correctly()
        {
            // Arrange
            int start = 1;
            int end = 15;
            List<string> expected = new List<string>
            {
                "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz",
                "11", "Fizz", "13", "14", "FizzBuzz"
            };

            // Act
            List<string> result = _fizzBuzzService.GenerateFizzBuzz(start, end);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GenerateFizzBuzz_ThrowsArgumentException()
        {
            // Arrange
            int start = 10;
            int end = 5;

            // Act and Assert
            Assert.Throws<System.ArgumentException>(() => _fizzBuzzService.GenerateFizzBuzz(start, end));
        }
    }
}