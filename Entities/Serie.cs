
using ConsoleListSeries.Enums;
using System;

namespace ConsoleListSeries.Entities
{
    public class Serie: BaseEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }

        public Serie(int id, Genre genre,string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
        }

        public override string ToString()
        {
            string aws = "Genre: " + this.Genre + Environment.NewLine;
            aws += "Title: " + this.Title + Environment.NewLine;
            aws += "Description: " + this.Description + Environment.NewLine;
            aws += "Year: " + this.Year + Environment.NewLine;
            
            return aws;
        }
        
        public string GetTitle()
        {
            return this.Title;
        }

        public int GetId()
        {
            return this.Id;
        }

    }
}
