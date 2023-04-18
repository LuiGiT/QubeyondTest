namespace QubeyondTest
{
    public class WordFinder
    {
        private readonly char[,] matrix;
        private readonly int rows;
        private readonly int cols;

        public WordFinder(IEnumerable<string> matrix)
        {
            this.matrix = BuildCharMatrix(matrix);
            this.rows = matrix.Count();
            this.cols = matrix.First().Length;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var wordCount = new Dictionary<string, int>();

            foreach (var word in wordstream)
            {
                if (!wordCount.ContainsKey(word))
                {
                    var count = CountOccurrences(word);
                    if (count > 0)
                    {
                        wordCount.Add(word, count);
                    }
                }
            }

            return wordCount.OrderByDescending(w => w.Value)
                           .ThenBy(w => w.Key)
                           .Take(10)
                           .Select(w => w.Key);
        }

        private char[,] BuildCharMatrix(IEnumerable<string> matrix)
        {
            var rowCount = matrix.Count();
            var colCount = matrix.First().Length;

            var charMatrix = new char[rowCount, colCount];
            for (var i = 0; i < rowCount; i++)
            {
                var rowChars = matrix.ElementAt(i).ToCharArray();
                for (var j = 0; j < colCount; j++)
                {
                    charMatrix[i, j] = rowChars[j];
                }
            }

            return charMatrix;
        }

        private int CountOccurrences(string word)
        {
            var count = 0;

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == word[0])
                    {
                        if (CheckRight(i, j, word) || CheckDown(i, j, word))
                        {
                            count++;
                            break;
                        }
                    }
                }
            }

            return count;
        }

        private bool CheckRight(int row, int col, string word)
        {
            if (word.Length > cols - col) return false;

            for (var i = 1; i < word.Length; i++)
            {
                if (matrix[row, col + i] != word[i])
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckDown(int row, int col, string word)
        {
            if (word.Length > rows - row) return false;

            for (var i = 1; i < word.Length; i++)
            {
                if (matrix[row + i, col] != word[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
