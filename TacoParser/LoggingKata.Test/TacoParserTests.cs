using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            var testParse = new TacoParser();
            var str = "32.92496,-85.961342,Taco Bell Alexander Cit...";
            var Tacobell = new TacoBell();
            var expected = "Taco Bell Alexander Cit...";
            var actual = testParse.Parse(str);

            Assert.Equal(actual.Name, expected);
        }

        [Theory]
        [InlineData("32.571331,-85.499655,Taco Bell Auburn...", "Taco Bell Auburn...")]
        public void ShouldParse(string str, string expected)
        {
            TacoParser shouldParse = new TacoParser();
            var actual = shouldParse.Parse(str);

            Assert.Equal(expected, actual.Name);

        }

        [Theory]
        [InlineData("34.8831,-84.293899Taco Bell Blue Ridg...", "Taco Bell Blue Ridg...")]
        [InlineData("34201107, -86.151229, Taco Bell Boa...", "Taco Bell Boa...")]
        public void ShouldFailParse(string str, string expected)
        {
            TacoParser parser = new TacoParser();
            var actual = parser.Parse(str);

            Assert.Equal(expected, actual.Name);
            
        }
    }
}
