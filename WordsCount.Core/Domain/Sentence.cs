namespace WordsCount.Core.Domain
{
    public class Sentence
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int NumberOfWords { get; set; }
    }
}
