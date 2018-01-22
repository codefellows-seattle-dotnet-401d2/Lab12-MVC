using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DontWine.Models
{
    public class Wine
    {

        public string ID { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string Designation { get; set; }
        public string Points { get; set; }
        public string Price { get; set; }
        public string Region_1 { get; set; }
        public string Region_2 { get; set; }
        public string Variety { get; set; }
        public string Winery { get; set; }
        public string Province { get; private set; }

        //4213,
        //US,
        //"Focused scents of white peach, salumi...",
        //Crop,
        //86,
        //26,
        //Arizona,
        //Arizona,
        //,
        //White Blend,
        //Sultry Cellars

        public static List<Wine> GetWineList()
        {
            // Instantiate Winelist
            List<Wine> myWine = new List<Wine>();
            // Get path from Environment
            string path = Environment.CurrentDirectory;
            //For testing, make sure the path is pointing to the root.
            string newPath = Path.GetFullPath(Path.Combine(path, @"wine.csv"));
            // Run the following codeblock using a newly instantiated SteamReader
            using (StreamReader reader = new StreamReader(newPath))
            {
                //Keep track of line number
                int counter = 0;
                //New empty string
                string line;

                //only grab the top 1000 wines.
                while (((line = reader.ReadLine()) != null) && counter <= 1000)
                {
                    //I have no idea
                    Regex parser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

                    //Separating columns to array
                    string[] wineList = parser.Split(line);

                    //Add new wine object to the list.
                    //Replaced with my constructor method
                    myWine.Add(new Wine
                    {
                        ID = wineList[0],
                        Country = wineList[1],
                        Description = wineList[2],
                        Designation = wineList[3],
                        Points = wineList[4],
                        Price = wineList[5],
                        Province = wineList[6],
                        Region_1 = wineList[7],
                        Region_2 = wineList[8],
                        Variety = wineList[9],
                        Winery = wineList[10]

                    });

                    //Increment line tracker
                    counter++;

                }
            }

            // Remove Table Header Wine
            myWine.Remove(myWine[0]);

            // Return WineList
            return myWine;
        }
    }
}
