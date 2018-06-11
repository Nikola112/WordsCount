using System;
using WordsCount.Application.Views.Base;
using WordsCount.ViewModel;

namespace WordsCount.Application.Views
{
    class MainView : View
    {
        #region Properties

        public MainViewModel MainViewModelContext
        {
            get => Context as MainViewModel;
        }

        #endregion

        #region Constructors

        public MainView(MainViewModel context) : base(context)
        {
        }

        #endregion

        #region Methods

        public void Run()
        {
            Load();
            SetValue();
            Save();
        }

        private void Load()
        {
            Console.WriteLine("Select one option(default is 1):");
            Console.WriteLine("\t1. Read from console");
            Console.WriteLine("\t2. Read from file");
            Console.WriteLine("\t3. Read from database");

            int.TryParse(Console.ReadLine(), out int selection);

            switch(selection)
            {
                case 1:
                    LoadFromConsole();
                    break;

                case 2:
                    LoadFromFile();
                    break;

                case 3:
                    LoadFromDatabase();
                    break;

                default:
                    LoadFromConsole();
                    break;
            }
        }

        private void SetValue()
        {
            ExecuteCommand(MainViewModelContext.SetDefaultNumberOfWordsValueCommand);
        }

        private void Save()
        {
            Console.WriteLine("\nSelect one option(default is 1):");
            Console.WriteLine("\t1. Write to console");
            Console.WriteLine("\t2. Write to file");
            Console.WriteLine("\t3. Write to database");

            int.TryParse(Console.ReadLine(), out int selection);

            Console.WriteLine();

            switch (selection)
            {
                case 1:
                    SaveToConsole();
                    break;

                case 2:
                    SaveToFile();
                    break;

                case 3:
                    SaveToDatabase();
                    break;

                default:
                    SaveToConsole();
                    break;
            }

            Console.WriteLine("\nPress 'Enter' to exit...");
            Console.ReadLine();
        }

        private void LoadFromConsole()
        {
            Console.WriteLine("\nWrite text here:");

            ExecuteCommand(MainViewModelContext.LoadFromConsoleCommand);
        }

        private void LoadFromFile()
        {
            ExecuteCommand(MainViewModelContext.LoadFromFileCommand);
        }

        private void LoadFromDatabase()
        {
            ExecuteCommand(MainViewModelContext.LoadFromDatabaseCommand);
        }

        private void SaveToConsole()
        {
            ExecuteCommand(MainViewModelContext.SaveToConsoleCommand);
        }

        private void SaveToFile()
        {
            ExecuteCommand(MainViewModelContext.SaveToFileCommand);
        }

        private void SaveToDatabase()
        {
            ExecuteCommand(MainViewModelContext.SaveToDatabaseCommand);
        }

        #endregion
    }
}
