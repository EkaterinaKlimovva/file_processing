using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.DataVisualization.Charting;

namespace Практика_4
{

    //interface IFileAnalyzer
    //{
    //    IEnumerable<(string, int)> GetMostFrequentWordPairs(string path);
    //    IEnumerable<(string, int)> GetMostFrequentWords(string path, int count);
    //    string GetFileWithMostSpecificWords(string path);
    //    Dictionary<int, int> GetDistributionOfLongWords(string path, int length);
    //}

    //class LinqFileAnalyzer : IFileAnalyzer
    //{
    //    public IEnumerable<(string, int)> GetMostFrequentWordPairs(string path)
    //    {
    //        var stopwatch = Stopwatch.StartNew();

    //        var wordPairs = Directory
    //                        .GetFiles(path, "*", SearchOption.AllDirectories)
    //                        .SelectMany(file => File.ReadLines(file))
    //                        .SelectMany(line => line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
    //                        .Buffer(2, 1)
    //                        .Where(words => words.Length == 2);

    //        var mostFrequentPair = wordPairs
    //                                .GroupBy(pair => pair)
    //                                .OrderByDescending(group => group.Count())
    //                                .Select(group => group.Key)
    //                                .FirstOrDefault();

    //        stopwatch.Stop();
    //        Console.WriteLine($"Task 1 execution time: {stopwatch.ElapsedMilliseconds} ms");

    //        return mostFrequentPair != null ? string.Join(" ", mostFrequentPair) : "No word pairs found";
    //    }

    //    public IEnumerable<(string, int)> GetMostFrequentWords(string path, int count)
    //    {
    //        var stopwatch = Stopwatch.StartNew();

    //        var fileNames = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
    //        var pairCounts = new Dictionary<string, int>();

    //        foreach (var fileName in fileNames)
    //        {
    //            using (var reader = new StreamReader(fileName))
    //            {
    //                string line;
    //                string previousWord = null;

    //                while ((line = reader.ReadLine()) != null)
    //                {
    //                    var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    //                    if (previousWord != null)
    //                    {
    //                        var wordPair = previousWord + " " + words[0];
    //                        if (!pairCounts.ContainsKey(wordPair))
    //                        {
    //                            pairCounts[wordPair] = 1;
    //                        }
    //                        else
    //                        {
    //                            ++pairCounts[wordPair];
    //                        }
    //                    }

    //                    for (int i = 1; i < words.Length; i++)
    //                    {
    //                        var wordPair = words[i - 1] + " " + words[i];
    //                        if (!pairCounts.ContainsKey(wordPair))
    //                        {
    //                            pairCounts[wordPair] = 1;
    //                        }
    //                        else
    //                        {
    //                            ++pairCounts[wordPair];
    //                        }
    //                    }

    //                    previousWord = words.LastOrDefault();
    //                }
    //            }
    //        }

    //        var mostFrequentPair = pairCounts.FirstOrDefault(x => x.Value == pairCounts.Values.Max());

    //        stopwatch.Stop();
    //        Console.WriteLine($"Task 1 execution time: {stopwatch.ElapsedMilliseconds} ms");

    //        return mostFrequentPair.Key ?? "No word pairs found";
    //    }

    //    public string GetFileWithMostSpecificWords(string path)
    //    {
    //        // LINQ решение
    //    }

    //    public Dictionary<int, int> GetDistributionOfLongWords(string path, int length)
    //    {
    //        // LINQ решение
    //    }
    //}

    //class NoLinqFileAnalyzer : IFileAnalyzer
    //{
    //    public IEnumerable<(string, int)> GetMostFrequentWordPairs(string path)
    //    {
    //        // Решение без LINQ
    //    }

    //    public IEnumerable<(string, int)> GetMostFrequentWords(string path, int count)
    //    {
    //        // Решение без LINQ
    //    }

    //    public string GetFileWithMostSpecificWords(string path)
    //    {
    //        // Решение без LINQ
    //    }

    //    public Dictionary<int, int> GetDistributionOfLongWords(string path, int length)
    //    {
    //        // Решение без LINQ
    //    }
    //}


    //class FileAnalyzer : IFileAnalyzer
    //{
    //    private readonly IFileAnalyzer _analyzer;

    //    public FileAnalyzer(IFileAnalyzer analyzer)
    //    {
    //        _analyzer = analyzer;
    //    }

    //    public IEnumerable<(string, int)> GetMostFrequentWordPairs(string path)
    //    {
    //        return _analyzer.GetMostFrequentWordPairs(path);
    //    }

    //    public IEnumerable<(string, int)> GetMostFrequentWords(string path, int count)
    //    {
    //        return _analyzer.GetMostFrequentWords(path, count);
    //    }

    //    public string GetFileWithMostSpecificWords(string path)
    //    {
    //        return _analyzer.GetFileWithMostSpecificWords(path);
    //    }

    //    public Dictionary<int, int> GetDistributionOfLongWords(string path, int length)
    //    {
    //        return _analyzer.GetDistributionOfLongWords(path, length);
    //    }
    //}

    //class FileHelper
    //{
    //    public static string[] GetFiles(string path)
    //    {
    //        // Получение списка файлов в директории
    //    }

    //    public static string ReadText(string filePath)
    //    {
    //        // Чтение текста из файла
    //    }
    //}

    //class WordInfo
    //{
    //    public string Word { get; set; }
    //    public int Count { get; set; }
    //}

    //class FileAnalyzerImpl : IFileAnalyzer
    //{
    //    public IEnumerable<(string, int)> GetMostFrequentWordPairs(string path)
    //    {
    //        var wordPairs = new Dictionary<string, int>();

    //        foreach (var file in FileHelper.GetFiles(path))
    //        {
    //            var text = FileHelper.ReadText(file);

    //            var words = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

    //            for (int i = 1; i < words.Length; i++)
    //            {
    //                var pair = $"{words[i - 1].ToLower()} {words[i].ToLower()}";

    //                if (wordPairs.ContainsKey(pair))
    //                {
    //                    wordPairs[pair]++;
    //                }
    //                else
    //                {
    //                    wordPairs[pair] = 1;
    //                }
    //            }
    //        }

    //        return wordPairs.OrderByDescending(x => x.Value)
    //            .Select(x => (x.Key, x.Value))
    //            .Take(10);
    //    }






    //public interface IFileAnalyzer
    //{
    //    IEnumerable<string> ReadWords(string filePath);
    //    IDictionary<string, int> CountWords(IEnumerable<string> words);
    //    IEnumerable<string> FilterWords(IEnumerable<string> words, int length);
    //    void SaveResult(IDictionary<string, int> result, string filePath);
    //}

    //public class LinqSolver : IFileAnalyzer
    //{
    //    public IEnumerable<string> ReadWords(string filePath)
    //    {
    //        return File.ReadAllText(filePath)
    //                   .ToLowerInvariant()
    //                   .Split(" ,.!?\t\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    //    }

    //    public IDictionary<string, int> CountWords(IEnumerable<string> words)
    //    {
    //        return words.GroupBy(w => w)
    //                    .ToDictionary(w => w.Key, w => w.Count());
    //    }

    //    public IEnumerable<string> FilterWords(IEnumerable<string> words, int length)
    //    {
    //        return words.Where(w => w.Length >= length);
    //    }

    //    public void SaveResult(IDictionary<string, int> result, string filePath)
    //    {
    //        using (var writer = new StreamWriter(filePath))
    //        {
    //            foreach (var pair in result.OrderByDescending(p => p.Value))
    //            {
    //                writer.WriteLine($"{pair.Key} {pair.Value}");
    //            }
    //        }
    //    }
    //}

    //public class NoLinqSolver : IFileAnalyzer
    //{
    //    public IEnumerable<string> ReadWords(string filePath)
    //    {
    //        var words = new List<string>();
    //        using (var reader = new StreamReader(filePath))
    //        {
    //            string line;
    //            while ((line = reader.ReadLine()) != null)
    //            {
    //                foreach (var word in line.ToLowerInvariant()
    //                                          .Split(" ,.!?\t\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
    //                {
    //                    words.Add(word);
    //                }
    //            }
    //        }
    //        return words;
    //    }

    //    public IDictionary<string, int> CountWords(IEnumerable<string> words)
    //    {
    //        var wordCount = new Dictionary<string, int>();
    //        foreach (var word in words)
    //        {
    //            if (!wordCount.ContainsKey(word))
    //            {
    //                wordCount[word] = 0;
    //            }
    //            wordCount[word]++;
    //        }
    //        return wordCount;
    //    }

    //    public IEnumerable<string> FilterWords(IEnumerable<string> words, int length)
    //    {
    //        var filteredWords = new List<string>();
    //        foreach (var word in words)
    //        {
    //            if (word.Length >= length)
    //            {
    //                filteredWords.Add(word);
    //            }
    //        }
    //        return filteredWords;
    //    }

    //    public void SaveResult(IDictionary<string, int> result, string filePath)
    //    {
    //        using (var writer = new StreamWriter(filePath))
    //        {
    //            var sortedKeys = result.Keys.OrderByDescending(k => result[k]);
    //            foreach (var key in sortedKeys)
    //            {
    //                writer.WriteLine($"{key} {result[key]}");
    //            }
    //        }
    //    }
    //}

    //interface ISolver
    //{
    //    List<string> GetTopNSimilarWords(string folderPath, int N, int K);
    //    (string, int) GetMostFrequentPair(string folderPath);
    //}

    //class LinqSolver : ISolver
    //{
    //    public List<string> GetTopNSimilarWords(string folderPath, int N, int K)
    //    {
    //        List<string> words = new List<string>();

    //        foreach (var file in Directory.GetFiles(folderPath))
    //        {
    //            words.AddRange(File.ReadAllText(file).Split(' '));
    //        }

    //        var groupedWords = words.GroupBy(w => w).OrderByDescending(g => g.Count());
    //        var distinctWords = groupedWords.Select(g => g.Key).Take(N).ToList();

    //        return distinctWords;
    //    }

    //    public (string, int) GetMostFrequentPair(string folderPath)
    //    {
    //        List<string> words = new List<string>();

    //        foreach (var file in Directory.GetFiles(folderPath))
    //        {
    //            words.AddRange(File.ReadAllText(file).Split(' '));
    //        }

    //        var pairs = words.Zip(words.Skip(1), (a, b) => (a, b));
    //        var groupedPairs = pairs.GroupBy(p => p).OrderByDescending(g => g.Count());

    //        var mostFrequentPair = groupedPairs.First().Key;
    //        var frequency = groupedPairs.First().Count();

    //        return (mostFrequentPair.Item1 + " " + mostFrequentPair.Item2, frequency);
    //    }
    //}

    //class NoLinqSolver : ISolver
    //{
    //    public List<string> GetTopNSimilarWords(string folderPath, int N, int K)
    //    {
    //        List<string> words = new List<string>();

    //        foreach (var file in Directory.GetFiles(folderPath))
    //        {
    //            string[] fileWords = File.ReadAllText(file).Split(' ');

    //            foreach (var word in fileWords)
    //            {
    //                int count = words.Count(w => w == word);
    //                if (count < K)
    //                {
    //                    words.Add(word);
    //                }
    //            }
    //        }

    //        Dictionary<string, int> wordCounts = words.GroupBy(w => w)
    //                                                   .ToDictionary(g => g.Key, g => g.Count());

    //        var sortedWords = wordCounts.OrderByDescending(w => w.Value)
    //                                   .Select(w => w.Key)
    //                                   .Take(N)
    //                                   .ToList();

    //        return sortedWords;
    //    }

    //    public (string, int) GetMostFrequentPair(string folderPath)
    //    {
    //        List<string> words = new List<string>();

    //        foreach (var file in Directory.GetFiles(folderPath))
    //        {
    //            words.AddRange(File.ReadAllText(file).Split(' '));
    //        }

    //        Dictionary<(string, string), int> pairCounts = new Dictionary<(string, string), int>();

    //        for (int i = 0; i < words.Count - 1; i++)
    //        {
    //            var pair = (words[i], words[i + 1]);

    //            if (!pairCounts.ContainsKey(pair))
    //            {
    //                pairCounts[pair] = 0;
    //            }

    //            pairCounts[pair]++;
    //        }

    //        var sortedPairs = pairCounts.OrderByDescending(p => p.Value).ToList();
    //        var mostFrequentPair = sortedPairs[0].Key;
    //        var frequency = sortedPairs[0].Value;

    //        return (mostFrequentPair.Item1 + " " + mostFrequentPair.Item2, frequency);
    //    }
    //}

    //class LinqSolver : ISolver
    //{
    //    public List<string> GetTopNSimilarWords(string folderPath, int N, int K)
    //    {
    //        List<string> words = new List<string>();

    //        foreach (var file in Directory.GetFiles(folderPath))
    //        {
    //            words.AddRange(File.ReadAllText(file).Split(' '));
    //        }

    //        var groupedWords = words.GroupBy(w => w).OrderByDescending(g => g.Count());
    //        var distinctWords = groupedWords.Select(g => g.Key).Take(N).ToList();

    //        return distinctWords;
    //    }

    //    public (string, int) GetMostFrequentPair(string folderPath)
    //    {
    //        List<string> words = new List<string>();

    //        foreach (var file in Directory.GetFiles(folderPath))
    //        {
    //            words.AddRange(File.ReadAllText(file).Split(' '));
    //        }

    //        var pairs = words.Zip(words.Skip(1), (a, b) => (a, b));
    //        var groupedPairs = pairs.GroupBy(p => p).OrderByDescending(g => g.Count());

    //        var mostFrequentPair = groupedPairs.First().Key;
    //        var frequency = groupedPairs.First



    //            public Form1()
    //        {
    //            InitializeComponent();
    //        }

    //        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    //        {

    //        }

    //        private void chart1_Click(object sender, EventArgs e)
    //        {

    //        }

    //        private void button1_Click(object sender, EventArgs e)
    //        {

    //        }

    //        private void button2_Click(object sender, EventArgs e)
    //        {

    //        }

    //        private void button3_Click(object sender, EventArgs e)
    //        {

    //        }

    //        private void button4_Click(object sender, EventArgs e)
    //        {

    //        }

    //        private void button5_Click(object sender, EventArgs e)
    //        {

    //        }

    //        private void button1_Click_1(object sender, EventArgs e)
    //        {
    //            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
    //            {
    //                if (folderDialog.ShowDialog() == DialogResult.OK)
    //                {
    //                    textBoxFolder.Text = folderDialog.SelectedPath;
    //                }
    //            }
    //        }
    //    }
    public interface ISolver
    {
        string GetMostFrequentPairOfWords(string folderPath);
        List<string> GetNFrequentWords(string folderPath, int n);
        string GetFileWithMostSpecificWords(string folderPath);
        Dictionary<int, int> GetDistributionOfLongWords(string folderPath, int m);
    }

    private void RunSolver_Click(object sender, EventArgs e)
    {
        var folderPath = FolderPathTextBox.Text;
        var n = int.Parse(NTextBox.Text);
        var k = int.Parse(KTextBox.Text);
        var m = int.Parse(MTextBox.Text);

        var linqSolver = new LinqSolver();
        var noLinqSolver = new NoLinqSolver();

        var stopwatch = new Stopwatch();

        stopwatch.Start();
        var mostFrequentPairLinq = linqSolver.GetMostFrequentPairOfWords(folderPath);
        stopwatch.Stop();
        var linqPairTime = stopwatch.ElapsedMilliseconds.ToString();
        stopwatch.Reset();

        stopwatch.Start();
        var mostFrequentPairNoLinq = noLinqSolver.GetMostFrequentPairOfWords(folderPath);
        stopwatch.Stop();
        var noLinqPairTime = stopwatch.ElapsedMilliseconds.ToString();
        stopwatch.Reset();

        stopwatch.Start();
        var nFrequentWordsLinq = string.Join(", ", linqSolver.GetNFrequentWords(folderPath, n));
        stopwatch.Stop();
        var linqNFrequentTime = stopwatch.ElapsedMilliseconds.ToString();
        stopwatch.Reset();

        stopwatch.Start();
        var nFrequentWordsNoLinq = string.Join(", ", noLinqSolver.GetNFrequentWords(folderPath, n));
        stopwatch.Stop();
        var noLinqNFrequentTime = stopwatch.ElapsedMilliseconds.ToString();
        stopwatch.Reset();

        stopwatch.Start();
        var fileWithSpecificWordsLinq = linqSolver.GetFileWithMostSpecificWords(folderPath);
        stopwatch.Stop();
        var linqSpecificTime = stopwatch.ElapsedMilliseconds.ToString();
        stopwatch.Reset();

        stopwatch.Start();
        var fileWithSpecificWordsNoLinq = noLinqSolver.GetFileWithMostSpecificWords(folderPath);
        stopwatch.Stop();
        var noLinqSpecificTime = stopwatch.ElapsedMilliseconds.ToString();
        stopwatch.Reset();

        stopwatch.Start();
        var distributionOfLongWordsLinq = linqSolver.GetDistributionOfLongWords(folderPath, m);
        stopwatch.Stop();
        var linqDistributionTime = stopwatch.ElapsedMilliseconds.ToString();
        stopwatch.Reset();

        stopwatch.Start();
        var distributionOfLongWordsNoLinq = noLinqSolver.GetDistributionOfLongWords(folderPath, m);
        stopwatch.Stop();
        var noLinqDistributionTime = stopwatch.ElapsedMilliseconds.ToString();
        stopwatch.Reset();

        dataGridView.Rows.Clear();
        dataGridView.Rows.Add("Most frequent pair (LINQ)", mostFrequentPairLinq, linqPairTime);
        dataGridView.Rows.Add("Most frequent pair (no LINQ)", mostFrequentPairNoLinq, noLinqPairTime);
        dataGridView.Rows.Add($"Top {n} frequent words (LINQ)", nFrequentWordsLinq, linqNFrequentTime);
        dataGridView.Rows.Add($"Top {n} frequent words (no LINQ)", nFrequentWordsNoLinq, noLinqNFrequentTime);
        dataGridView.Rows.Add("File with most specific words (LINQ)", fileWithSpecificWordsLinq, linqSpecificTime);
        dataGridView.Rows.Add("File with most specific words (no LINQ)", fileWithSpecificWordsNoLinq, noLinqSpecificTime);

        chart.Series.Clear();
        chart.Series.Add("Distribution of long words (LINQ)");
        foreach (var kv in distributionOfLongWordsLinq)
        {
            chart.Series["Distribution of long words (LINQ)"].Points.AddXY(kv.Key, kv.Value);
        }
        chart.Series.Add("Distribution of long words (no LINQ)");
        foreach (var kv in distributionOfLongWordsNoLinq)
        {
            chart.Series["Distribution of long words (no LINQ)"].Points.AddXY(kv.Key, kv.Value);
        }
    }

    public string GetMostFrequentPairOfWords(string folderPath)
    {
        string mostFrequentPair = null;
        int maxCount = 0;

        var files = Directory.EnumerateFiles(folderPath);
        foreach (var file in files)
        {
            var words = File.ReadAllText(file).Split();
            for (int i = 0; i < words.Length - 1; i++)
            {
                string pair = words[i] + " " + words[i + 1];
                int count = CountPair(folderPath, pair);
                if (count > maxCount)
                {
                    maxCount = count;
                    mostFrequentPair = pair;
                }
            }
        }

        return mostFrequentPair;
    }

    public List<string> GetNFrequentWords(string folderPath, int n)
    {
        var frequency = new Dictionary<string, int>();
        var files = Directory.EnumerateFiles(folderPath);
        foreach (var file in files)
        {
            var words = File.ReadAllText(file).Split();
            foreach (var word in words)
            {
                if (frequency.ContainsKey(word))
                {
                    frequency[word]++;
                }
                else
                {
                    frequency.Add(word, 1);
                }
            }
        }

        var mostFrequent = frequency.OrderByDescending(x => x.Value)
                                    .Select(x => x.Key)
                                    .Take(n)
                                    .ToList();
        return mostFrequent;
    }

    public string GetFileWithMostSpecificWords(string folderPath)
    {
        string fileWithMostSpecificWords = null;
        int maxSpecificWordsCount = 0;

        var allWords = new Dictionary<string, int>();
        var wordWithCountInFiles = new Dictionary<string, int>();
        var files = Directory.EnumerateFiles(folderPath);

        // Count all words and count unique words in each file
        foreach (var file in files)
        {
            var words = File.ReadAllText(file).Split();
            foreach (var word in words)
            {
                if (allWords.ContainsKey(word))
                {
                    allWords[word]++;
                }
                else
                {
                    allWords[word] = 1;
                }

                if (wordWithCountInFiles.ContainsKey(word))
                {
                    continue;
                }
                else
                {
                    int filesWithWordCount = CountFilesWithWord(folderPath, word);
                    wordWithCountInFiles[word] = filesWithWordCount;
                }
            }
        }

        // Find the file with the most specific words
        foreach (var file in Directory.EnumerateFiles(folderPath))
        {
            var words = File.ReadAllText(file).Split();
            int specificWordsCount = 0;

            foreach (var word in words)
            {
                if (wordWithCountInFiles[word] == 1)
                {
                    specificWordsCount++;
                }
            }

            if (specificWordsCount > maxSpecificWordsCount)
            {
                maxSpecificWordsCount = specificWordsCount;
                fileWithMostSpecificWords = file;
            }
        }

        return fileWithMostSpecificWords;
    }

    public Dictionary<int, int> GetDistributionOfLongWords(string folderPath, int m)
    {
        var counts = new Dictionary<int, int>();
        var files = Directory.EnumerateFiles(folderPath);
        foreach (var file in files)
        {
            var words = File.ReadAllText(file).Split();
            foreach (var word in words)
            {
                if (word.Length > m)
                {
                    int count;
                    if (counts.TryGetValue(word.Length, out count))
                    {
                        counts[word.Length] = count + 1;
                    }
                    else
                    {
                        counts[word.Length] = 1;
                    }
                }
            }
        }

        return counts;
    }

    private int CountPair(string folderPath, string pair)
    {
        int count = 0;
        var files = Directory.EnumerateFiles(folderPath);
        foreach (var file in files)
        {
            var words = File.ReadAllText(file).Split();
            for (int i = 0; i < words.Length - 1; i++)
            {
                if (pair == words[i] + " " + words[i + 1])
                {
                    count++;
                }
            }
        }

        return count;
    }

    private int CountFilesWithWord(string folderPath, string word)
    {
        int count = 0;
        var files = Directory.EnumerateFiles(folderPath);
        foreach (var file in files)
        {
            var words = File.ReadAllText(file).Split();
            if (words.Contains(word))
            {
                count++;
            }
        }

        return count;
    }


    public interface IFileProcessor
    {
        string GetMostFrequentWordPair(string targetFolder);
        IEnumerable<string> GetMostFrequentWords(string targetFolder, int n);
        string GetFileWithMostUniqueWords(string targetFolder);
        Dictionary<int, int> GetLongWordsDistribution(string targetFolder, int m);
    }

    private void DisplayResult(string result)
    {
        dataGridView1.Rows.Clear();
        var row = new DataGridViewRow();
        var cell = new DataGridViewTextBoxCell { Value = result };
        row.Cells.Add(cell);
        dataGridView1.Rows.Add(row);
    }

    private void DisplayResult(Dictionary<int, int> result)
    {
        chart1.Series.Clear();
        var series = new Series();
        series.ChartType = SeriesChartType.Column;
        foreach (var pair in result)
        {
            series.Points.AddXY(pair.Key, pair.Value);
        }
        chart1.Series.Add(series);
    }

    public string GetMostFrequentWordPair(string targetFolder)
    {
        var mostFrequentPair = "";
        var maxCount = 0;
        foreach (var file in Directory.GetFiles(targetFolder))
        {
            var words = File.ReadAllText(file).Split();
            var pairs = words.Zip(words.Skip(1), (x, y) => x + " " + y);
            var frequency = pairs.GroupBy(x => x)
                                  .ToDictionary(x => x.Key, x => x.Count());
            var pair = frequency.OrderByDescending(x => x.Value).FirstOrDefault().Key;
            var count = frequency[pair];
            if (count > maxCount)
            {
                mostFrequentPair = pair;
                maxCount = count;
            }
        }
        return mostFrequentPair;
    }

    public string GetMostFrequentWordPairNoLinq(string targetFolder)
    {
        var mostFrequentPair = "";
        var maxCount = 0;
        foreach (var file in Directory.GetFiles(targetFolder))
        {
            var words = File.ReadAllText(file).Split();
            var frequency = new Dictionary<string, int>();
            for (int i = 1; i < words.Length; i++)
            {
                var pair = words[i - 1] + " " + words[i];
                if (!frequency.ContainsKey(pair))
                {
                    frequency[pair] = 0;
                }
                frequency[pair]++;
            }
            var pair = "";
            var count = 0;
            foreach (var item in frequency)
            {
                if (item.Value > count)
                {
                    pair = item.Key;
                    count = item.Value;
                }
            }
            if (count > maxCount)
            {
                mostFrequentPair = pair;
                maxCount = count;
            }
        }
        return mostFrequentPair;
    }

    public IEnumerable<string> GetMostFrequentWords(string targetFolder, int n)
    {
        var frequency = new Dictionary<string, int>();
        foreach (var file in Directory.GetFiles(targetFolder))
        {
            var words = File.ReadAllText(file).Split();
            foreach (var word in words)
            {
                if (!frequency.ContainsKey(word))
                {
                    frequency[word] = 0;
                }
                frequency[word]++;
            }
        }
        return frequency.OrderByDescending(x => x.Value)
                        .Select(x => x.Key)
                        .Take(n);
    }

    public IEnumerable<string> GetMostFrequentWordsNoLinq(string targetFolder, int n)
    {
        var frequency = new Dictionary<string, int>();
        foreach (var file in Directory.GetFiles(targetFolder))
        {
            var words = File.ReadAllText(file).Split();
            foreach (var word in words)
            {
                if (!frequency.ContainsKey(word))
                {
                    frequency[word] = 0;
                }
                frequency[word]++;
            }
        }
        var result = new List<string>();
        while (result.Count < n && frequency.Count > 0)
        {
            var maxCount = frequency.Values.Max();
            var maxWords = frequency.Where(x => x.Value == maxCount).Select(x => x.Key);
            result.AddRange(maxWords);
            foreach (var word in maxWords)
            {
                frequency.Remove(word);
            }
        }
        return result;
    }

    public string GetFileWithMostUniqueWords(string targetFolder)
    {
        var maxUniqueCount = 0;
        var fileWithMostUniqueWords = "";
        var allWords = new HashSet<string>();
        foreach (var file in Directory.GetFiles(targetFolder))
        {
            var words = new HashSet<string>(File.ReadAllText(file).Split());
            var uniqueWordsCount = words.Except(allWords).Count();
            if (uniqueWordsCount > maxUniqueCount)
            {
                maxUniqueCount = uniqueWordsCount;
                fileWithMostUniqueWords = file;
            }
            allWords.UnionWith(words);
        }
        return fileWithMostUniqueWords;
    }

    public string GetFileWithMostUniqueWordsNoLinq(string targetFolder)
    {
        var maxUniqueCount = 0;
        var fileWithMostUniqueWords = "";
        var allWords = new HashSet<string>();
        foreach (var file in Directory.GetFiles(targetFolder))
        {
            var words = new HashSet<string>(File.ReadAllText(file).Split());
            var uniqueWordsCount = 0;
            foreach (var word in words)
            {
                if (!allWords.Contains(word))
                {
                    uniqueWordsCount++;
                }
            }
            if (uniqueWordsCount > maxUniqueCount)
            {
                maxUniqueCount = uniqueWordsCount;
                fileWithMostUniqueWords = file;
            }
            allWords.UnionWith(words);
        }
        return fileWithMostUniqueWords;
    }

    public Dictionary<int, int> GetLongWordsDistribution(string targetFolder, int m)
    {
        var result = new Dictionary<int, int>();
        foreach (var file in Directory.GetFiles(targetFolder))
        {
            var words = File.ReadAllText(file).Split();
            var longWords = words.Where(x => x.Length > m);
            foreach (var word in longWords)
            {
                var length = word.Length;
                if (!result.ContainsKey(length))
                {
                    result[length] = 0;
                }
                result[length]++;
            }
        }
        return result;
    }

    public Dictionary<int, int> GetLongWordsDistributionNoLinq(string targetFolder, int m)
    {
        var result = new Dictionary<int, int>();
        foreach (var file in Directory.GetFiles(targetFolder))
        {
            var words = File.ReadAllText(file).Split();
            foreach (var word in words)
            {
                if (word.Length > m)
                {
                    var length = word.Length;
                    if (!result.ContainsKey(length))
                    {
                        result[length] = 0;
                    }
                    result[length]++;
                }
            }
        }
        return result;
    }
    //interface IFileProcessor
    //{
    //    string GetMostFrequentConsequtiveWords(string targetDirectory);
    //    string GetNMostFrequentWords(string targetDirectory, int n);
    //    string GetFileWithSpecificWords(string targetDirectory);
    //    IDictionary<int, int> GetFrequencyOfLongWords(string targetDirectory, int m);
    //}


    //public string GetMostFrequentConsequtiveWords(string targetDirectory)
    //{
    //    var stopwatch = Stopwatch.StartNew();

    //    var wordPairs = Directory
    //                    .GetFiles(targetDirectory, "*", SearchOption.AllDirectories)
    //                    .SelectMany(file => File.ReadLines(file))
    //                    .SelectMany(line => line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
    //                    .Buffer(2, 1)
    //                    .Where(words => words.Length == 2);

    //    var mostFrequentPair = wordPairs
    //                            .GroupBy(pair => pair)
    //                            .OrderByDescending(group => group.Count())
    //                            .Select(group => group.Key)
    //                            .FirstOrDefault();

    //    stopwatch.Stop();
    //    Console.WriteLine($"Task 1 execution time: {stopwatch.ElapsedMilliseconds} ms");

    //    return mostFrequentPair != null ? string.Join(" ", mostFrequentPair) : "No word pairs found";
    //}

    //public string GetMostFrequentConsequtiveWords(string targetDirectory)
    //{
    //    var stopwatch = Stopwatch.StartNew();

    //    var fileNames = Directory.GetFiles(targetDirectory, "*", SearchOption.AllDirectories);
    //    var pairCounts = new Dictionary<string, int>();

    //    foreach (var fileName in fileNames)
    //    {
    //        using (var reader = new StreamReader(fileName))
    //        {
    //            string line;
    //            string previousWord = null;

    //            while ((line = reader.ReadLine()) != null)
    //            {
    //                var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    //                if (previousWord != null)
    //                {
    //                    var wordPair = previousWord + " " + words[0];
    //                    if (!pairCounts.ContainsKey(wordPair))
    //                    {
    //                        pairCounts[wordPair] = 1;
    //                    }
    //                    else
    //                    {
    //                        ++pairCounts[wordPair];
    //                    }
    //                }

    //                for (int i = 1; i < words.Length; i++)
    //                {
    //                    var wordPair = words[i - 1] + " " + words[i];
    //                    if (!pairCounts.ContainsKey(wordPair))
    //                    {
    //                        pairCounts[wordPair] = 1;
    //                    }
    //                    else
    //                    {
    //                        ++pairCounts[wordPair];
    //                    }
    //                }

    //                previousWord = words.LastOrDefault();
    //            }
    //        }
    //    }

    //    var mostFrequentPair = pairCounts.FirstOrDefault(x => x.Value == pairCounts.Values.Max());

    //    stopwatch.Stop();
    //    Console.WriteLine($"Task 1 execution time: {stopwatch.ElapsedMilliseconds} ms");

    //    return mostFrequentPair.Key ?? "No word pairs found";
    //}

    //public string GetNMostFrequentWords(string targetDirectory, int n)
    //{
    //    var stopwatch = Stopwatch.StartNew();

    //    var words = Directory
    //                .GetFiles(targetDirectory, "*", SearchOption.AllDirectories)
    //                .SelectMany(file => File.ReadLines(file))
    //                .SelectMany(line => line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
    //                .GroupBy(word => word)
    //                .OrderByDescending(group => group.Count())
    //                .Take(n)
    //                .Select(group => group.Key);

    //    stopwatch.Stop();
    //    Console.WriteLine($"Task 2 execution time: {stopwatch.ElapsedMilliseconds} ms");

    //    return words.Any() ? string.Join(", ", words) : "No words found";
    //}

    //public string GetNMostFrequentWords(string targetDirectory, int n)
    //{
    //    var stopwatch = Stopwatch.StartNew();

    //    var fileNames = Directory.GetFiles(targetDirectory, "*", SearchOption.AllDirectories);
    //    var wordCounts = new Dictionary<string, int>();

    //    foreach (var fileName in fileNames)
    //    {
    //        using (var reader = new StreamReader(fileName))
    //        {
    //            string line;
    //            while ((line = reader.ReadLine()) != null)
    //            {
    //                var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    //                foreach (var word in words)
    //                {
    //                    if (!wordCounts.ContainsKey(word))
    //                    {
    //                        wordCounts[word] = 1;
    //                    }
    //                    else
    //                    {
    //                        ++wordCounts[word];
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    var mostFrequentWords = wordCounts.OrderByDescending(x => x.Value).Take(n).Select(x => x.Key);

    //    stopwatch.Stop();
    //    Console.WriteLine($"Task 2 execution time: {stopwatch.ElapsedMilliseconds} ms");

    //    return mostFrequentWords.Any() ? string.Join(", ", mostFrequentWords) : "No words found";
    //}

    //public string GetFileWithSpecificWords(string targetDirectory)
    //{
    //    var stopwatch = Stopwatch.StartNew();

    //    var fileNames = Directory.GetFiles(targetDirectory, "*", SearchOption.AllDirectories);
    //    var fileContents = new Dictionary<string, string>();

    //    foreach (var fileName in fileNames)
    //    {
    //        using (var reader = new StreamReader(fileName))
    //        {
    //            fileContents[fileName] = reader.ReadToEnd();
    //        }
    //    }

    //    var wordCounts = new Dictionary<string, int>();
    //    foreach (var content in fileContents.Values)
    //    {
    //        var words = content.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    //        foreach (var word in words)
    //        {
    //            if (!wordCounts.ContainsKey(word))
    //            {
    //                wordCounts[word] = 1;
    //            }
    //            else
    //            {
    //                ++wordCounts[word];
    //            }
    //        }
    //    }

    //    var specificWords = wordCounts.Where(x => x.Value == 1).Select(x => x.Key).ToHashSet();

    //    var resultFileName = string.Empty;
    //    var maxSpecificWordCount = 0;

    //    foreach (var kvp in fileContents)
    //    {
    //        var specificWordCount = 0;

    //        var words = kvp.Value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    //        foreach (var word in words)
    //        {
    //            if (specificWords.Contains(word))
    //            {
    //                ++specificWordCount;
    //            }
    //        }

    //        if (specificWordCount > maxSpecificWordCount)
    //        {
    //            maxSpecificWordCount = specificWordCount;
    //            resultFileName = kvp.Key;
    //        }
    //    }

    //    stopwatch.Stop();
    //    Console.WriteLine($"Task 3 execution time: {stopwatch.ElapsedMilliseconds} ms");

    //    return resultFileName != string.Empty ? resultFileName : "No files found";
    //}

    //public IDictionary<int, int> GetFrequencyOfLongWords(string targetDirectory, int m)
    //{
    //    var stopwatch = Stopwatch.StartNew();
    //    var wordCounts = Directory
    //                        .GetFiles(targetDirectory, "*", SearchOption.AllDirectories)
    //                        .SelectMany(file => File.ReadLines(file))
    //                        .SelectMany(line => line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
    //                        .Where(word => word.Length > m)
    //                        .GroupBy(word => word.Length)
    //                        .ToDictionary(group => group.Key, group => group.Count());

    //    stopwatch.Stop();
    //    Console.WriteLine($"Task 4 execution time: {stopwatch.ElapsedMilliseconds} ms");

    //    return wordCounts;
    //}

    //public IDictionary<int, int> GetFrequencyOfLongWords(string targetDirectory, int m)
    //{
    //    var stopwatch = Stopwatch.StartNew();
    //    var fileNames = Directory.GetFiles(targetDirectory, "*", SearchOption.AllDirectories);

    //    var wordCounts = new Dictionary<int, int>();
    //    foreach (var fileName in fileNames)
    //    {
    //        using (var reader = new StreamReader(fileName))
    //        {
    //            string line;
    //            while ((line = reader.ReadLine()) != null)
    //            {
    //                var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    //                foreach (var word in words)
    //                {
    //                    if (word.Length > m)
    //                    {
    //                        if (!wordCounts.ContainsKey(word.Length))
    //                        {
    //                            wordCounts[word.Length] = 1;
    //                        }
    //                        else
    //                        {
    //                            ++wordCounts[word.Length];
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    stopwatch.Stop();
    //    Console.WriteLine($"Task 4 execution time: {stopwatch.ElapsedMilliseconds} ms");

    //    return wordCounts;
    //}

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
