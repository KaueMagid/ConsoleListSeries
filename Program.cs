using ConsoleListSeries.Entities;
using ConsoleListSeries.Enums;
using System;

namespace ConsoleListSeries
{
    class Program
    {
        static RepositorySeries repository = new RepositorySeries();
        static void Main(string[] args)
        {
            string option = Menu();
            while ( option.ToUpper() != "X")
            {
                try
                {
                    switch (option)
                    {
                        case "1":
                            //ListSeries
                            ListSeries();
                            break;

                        case "2":
                            //Add Serie
                            AddSeries();
                            break;

                        case "3":
                            //Updade
                            UpdateSarie();
                            break;

                        case "4":
                            //Delete
                            DeleteSeries();
                            break;

                        case "5":
                            ShowSeries();
                            break;

                        default:
                            throw new ArgumentOutOfRangeException("Opition Exception","Please choose one of the menu options");
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {

                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                }
                option = Menu();
            }


        }

        private static string Menu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Kaue Magid Series");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("choose the desired option:");
            Console.ResetColor();
            
            Console.WriteLine("1 - List series.");
            Console.WriteLine("2 - Add a new serie");
            Console.WriteLine("3 - Update serie");
            Console.WriteLine("4 - Delete serie");
            Console.WriteLine("5 - Show serie");
            Console.WriteLine("X - Exit");
            Console.WriteLine();

            string aws = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return aws;
        }
        
        private static void ListSeries()
        {
            Console.Clear();
            if (repository.NextId()==0)
            {
                Console.WriteLine();
                Console.WriteLine("There are no series to show!");
                Console.WriteLine("press enter to return menu");
                Console.ReadLine();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ID -   TITLE ");
            Console.ResetColor();
            foreach (var serie in repository.List())
            {
                Console.WriteLine("{0:D2} - {1}",serie.Id, serie.GetTitle());
            }

            Console.WriteLine("press enter to return menu");
            Console.ReadLine();
        }

        private static void AddSeries()
        {
            int genre, year;
            string title, description;
            Console.Clear();
            
            Console.WriteLine("choose the Genre:");
            int last = -1;
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                if (i>last)
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
                    last = i;
                }
                
            }
            if(!int.TryParse(Console.ReadLine(),out genre)||genre<(int)Genre.Min||genre>(int)Genre.Max)
            {
                throw new ArgumentOutOfRangeException("Genre Exception", "Please choose one valid genre"); 
            }
            
            Console.WriteLine();
            Console.WriteLine("What's the title of the series:");
            title = Console.ReadLine();
            
            Console.WriteLine();
            Console.WriteLine("The description:");
            description = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("The year: ");
            if (!int.TryParse(Console.ReadLine(),out year))
            {
                throw new ArgumentOutOfRangeException("Range Exception", "Please insert a valid year");
            }

            Series serie = new Series(repository.NextId(),
                                    (Genre)genre,
                                    title,
                                    description,
                                    year);
            repository.Insert(serie);

        }

        private static void UpdateSarie()
        {
            Console.Clear();
            Console.WriteLine();
            if (repository.NextId() == 0)
            {
                Console.WriteLine("There are no series to update!");
                Console.WriteLine("press enter to return menu");
                Console.ReadLine();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("please, enter the series ID for update:");
            Console.WriteLine("  ID   -   TITLE ");
            Console.ResetColor();
            foreach (var serie in repository.List())
            {
                Console.WriteLine("{0:D2} - {1}", serie.Id, serie.GetTitle());
            }
            Console.WriteLine();
            if (!int.TryParse(Console.ReadLine(),out int id)||id<0||id>repository.NextId()-1)
            {
                throw new ArgumentOutOfRangeException(null, message: "Invalid id");
            }

            Series series = repository.SearchById(id);
            Console.WriteLine(series.ToString());
            Console.WriteLine();
            Console.WriteLine("Enter the new title series or press enter to ignore");
            string title = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Enter the new description series or press enter to ignore");
            string description = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Enter the genre series");

            int last = 0;
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                if (i > last)
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
                    last = i;
                }

            }
            if (!int.TryParse(Console.ReadLine(), out int genre) || genre < (int)Genre.Min || genre > (int)Genre.Max)
            {
                throw new ArgumentOutOfRangeException("Genre Exception", "Please choose one valid genre");
            }
            Console.WriteLine();
            Console.WriteLine("Enter the year series");
            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                throw new ArgumentOutOfRangeException("Year Exception", "Please choose one valid year");
            }
            if (String.IsNullOrEmpty(title))
            {
                title = series.GetTitle();
            }
            if (String.IsNullOrEmpty(description))
            {
                description = series.GetDescription();
            }
            repository.UpdateEntity(id, new Series(id, (Genre)genre, title, description, year));
            Console.WriteLine("Series updated successfully");
            Console.WriteLine("to return press enter");
            Console.ReadLine();
        }

        private static void DeleteSeries()
        {
            Console.Clear();
            if (repository.NextId() == 0)
            {
                Console.WriteLine();
                Console.WriteLine("There are no series to show!");
                Console.WriteLine("press enter to return menu");
                Console.ReadLine();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("List Series");
            Console.WriteLine("ID -   TITLE ");
            Console.ResetColor();
            foreach (var serie in repository.List())
            {
                Console.WriteLine("{0:D2} - {1}", serie.Id, serie.GetTitle());
            }
            Console.WriteLine("Enter the Id to delete or press enter to return:");

            string aws = Console.ReadLine();
            if (String.IsNullOrEmpty(aws))
            {
                return;
            }
            if (!int.TryParse(aws,out int id)||id<0||id>=repository.NextId())
            {
                throw new ArgumentOutOfRangeException("Id Error", "Please enter a valid id");
            }
            repository.Remove(id);
            Console.WriteLine("Series deleted successfully");
            Console.WriteLine("press enter to return");
            Console.ReadLine();
        }

        private static void ShowSeries()
        {
            Console.Clear();
            if (repository.NextId() == 0)
            {
                Console.WriteLine();
                Console.WriteLine("There are no series to show!");
                Console.WriteLine("press enter to return menu");
                Console.ReadLine();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please enter id to show more info from Series");
            Console.WriteLine("ID -   TITLE ");
            Console.ResetColor();
            foreach (var serie in repository.List())
            {
                Console.WriteLine("{0:D2} - {1}", serie.Id, serie.GetTitle());
            }

            if (!int.TryParse(Console.ReadLine(),out int id) || id < 0 || id >= repository.NextId())
            {
                throw new ArgumentOutOfRangeException("Error Id", "Please enter a valid id");
            }
            Console.Clear();
            repository.SearchById(id).ToString();
            Console.WriteLine();
            Console.WriteLine("Press enter to retur menu");
            Console.ReadLine();
        }
    }
}
