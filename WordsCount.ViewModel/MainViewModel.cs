using ExtensionMethods;
using System;
using System.Windows.Input;
using WordsCount.Core.Domain;
using WordsCount.FileFramework;
using WordsCount.ViewModel.Base;

namespace WordsCount.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Fields

        private Sentence _sentence;

        #endregion

        #region Properties

        public Sentence Sentence
        {
            get => _sentence;
            set => SetValue(ref _sentence, value);
        }

        public ICommand LoadFromConsoleCommand { get; set; }

        public ICommand LoadFromFileCommand { get; set; }

        public ICommand LoadFromDatabaseCommand { get; set; }

        public ICommand SetDefaultNumberOfWordsValueCommand { get; set; }

        public ICommand SetNumberOfWordsValueCommand { get; set; }

        public ICommand SaveToConsoleCommand { get; set; }

        public ICommand SaveToFileCommand { get; set; }

        public ICommand SaveToDatabaseCommand { get; set; }

        #endregion

        #region Constructors

        public MainViewModel()
        {
            LoadFromConsoleCommand = new RelayCommand(LoadFromConsole);
            LoadFromFileCommand = new RelayCommand(LoadFromFile);
            LoadFromDatabaseCommand = new RelayCommand(LoadFromDatabase);

            SetDefaultNumberOfWordsValueCommand = new RelayCommand(SetDefaultNumberOfWordsValue);
            SetNumberOfWordsValueCommand = new RelayCommand<int>(SetNumberOfWordsValue);

            SaveToConsoleCommand = new RelayCommand(SaveToConsole);
            SaveToFileCommand = new RelayCommand(SaveToFile);
            SaveToDatabaseCommand = new RelayCommand(SaveToDatabase);
        }

        #endregion

        #region Methods

        private void LoadFromConsole()
        {
            Sentence = new Sentence()
            {
                Text = Console.ReadLine()
            };
        }

        private void LoadFromFile()
        {
            using (var unit = new FilePersistance.UnitOfWork(new FileLoader<Sentence>()))
            {
                Sentence = unit.Sentences.Get();
            }
        }

        private void LoadFromDatabase()
        {
            using (var unit = new DatabasePersistance.UnitOfWork(new DatabasePersistance.WordsCountDbContext()))
            {
                Sentence = unit.Sentences.Get();
            }
        }

        private void SetDefaultNumberOfWordsValue()
        {
            Sentence.NumberOfWords = Sentence.Text.NumberOfWords();
        }

        private void SetNumberOfWordsValue(int numberOfWords)
        {
            Sentence.NumberOfWords = numberOfWords;
        }

        private void SaveToConsole()
        {
            Console.WriteLine(Sentence.NumberOfWords);
        }

        private void SaveToFile()
        {
            using (var unit = new FilePersistance.UnitOfWork(new FileLoader<Sentence>()))
            {
                var sentence = unit.Sentences.Get();

                sentence.Text = Sentence.Text;
                sentence.NumberOfWords = Sentence.NumberOfWords;

                unit.Complete();
            }
        }

        private void SaveToDatabase()
        {
            using (var unit = new DatabasePersistance.UnitOfWork(new DatabasePersistance.WordsCountDbContext()))
            {
                var sentence = unit.Sentences.Get();

                sentence.Text = Sentence.Text;
                sentence.NumberOfWords = Sentence.NumberOfWords;

                unit.Complete();
            }
        }

        #endregion
    }
}
