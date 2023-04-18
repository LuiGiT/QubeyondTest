using QubeyondTest;

namespace QubeyondUnitTest
{
    public class WorFinderTest
    {
        [Fact]
        public void TestFind()
        {
            var matrix = new List<string>
            {
                 "chill",
                 "cold ",
                 "wind "
            };

            var wordstream = new List<string>
            {
                 "chilly",
                 "chill",
                 "cold",
                 "wind",
                 "cloudy",
                 "sunny",
                 "rain",
                 "fog",
                 "windy",
                 "stormy",
                 "hot",
                 "cold",
                 "wind"
             };

            var wordFinder = new WordFinder(matrix);
            var foundWords = wordFinder.Find(wordstream);

            var expectedWords = new List<string>
            {
                 "chill",
                 "cold",
                 "wind"
            };

            Assert.Equal(expectedWords, foundWords);
        }

        [Fact]
        public void TestFindNoMatches()
        {
            var matrix = new List<string>
            {
                 "chill",
                 "cold ",
                 "wind "
             };

            var wordstream = new List<string>
            {
                 "cloudy",
                 "sunny",
                 "rain",
                 "fog",
                 "windy",
                 "stormy",
                 "hot"
             };

            var wordFinder = new WordFinder(matrix);
            var foundWords = wordFinder.Find(wordstream);

            var expectedWords = new List<string>();

            Assert.Equal(expectedWords, foundWords);
        }

        [Fact]
        public void TestFindDuplicateMatches()
        {
            var matrix = new List<string>
            {
                "chill",
                "cold ",
                "wind "
            };

            var wordstream = new List<string>
            {
                 "chill",
                 "chill",
                 "cold",
                 "cold",
                 "wind",
                 "wind"
            };

            var wordFinder = new WordFinder(matrix);
            var foundWords = wordFinder.Find(wordstream);

            var expectedWords = new List<string>
            {
                 "chill",
                 "cold",
                 "wind"
            };

            Assert.Equal(expectedWords, foundWords);
        }
    }
}