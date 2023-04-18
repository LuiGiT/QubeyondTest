namespace QubeyondTest
{
    public class Program
    {
        public static void Main()
        {
            var matrix = new List<string>
        {
            "chill",
            "windy",
            "cold ",
        };

            var wordstream = new List<string>
        {
            "chill",
            "cold",
            "wind",
            "snow",
            "rain",
            "hot",
            "breeze",
            "warm",
            "chill",
            "cloudy",
            "wind",
            "cold",
            "sunny",
            "chill",
            "wind",
            "cold",
        };

            var wordFinder = new WordFinder(matrix);
            var foundWords = wordFinder.Find(wordstream);

            Console.WriteLine("Found words:");
            foreach (var word in foundWords)
            {
                Console.WriteLine(word);
            }
        }
    }  

}