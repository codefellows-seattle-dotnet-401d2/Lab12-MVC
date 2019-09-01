using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace MVC.Models
{
    public class Wine
    {
        public string ID { get;  set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string Designation { get; set; }
        public string Points { get; set; }
        public string Price { get; set; }
        public string Region_1 { get; set; }
        public string Region_2 { get; set; }
        public string Variety { get; set; }
        public string Winery { get; set; }


        public static List<Wine> GetWineList()
        {
            List<Wine> myWine = new List<Wine>();
            string path = Environment.CurrentDirectory;
            //For testing, make sure the path is pointing to the root.
            string newPath = Path.GetFullPath(Path.Combine(path, @"..\..\wine.csv"));
            using (StreamReader reader = new StreamReader(newPath))
            {
                int counter = 0;
                string line;

                //only grab the top 1000 wines. 
                while (((line = reader.ReadLine()) != null) && counter < 1001)
                {
                    Regex parser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

                    //Separating columns to array
                    string[] wineList = parser.Split(line);

                    //Add new wine object to the list. 
                    myWine.Add(new Wine
                    {
                        ID = wineList[0],
                        Country = wineList[1],
                        Description = wineList[2],
                        Designation = wineList[3],
                        Points = wineList[4],
                        Price = wineList[5],
                        Region_1 = wineList[6],
                        Region_2 = wineList[7],
                        Variety = wineList[8],
                        Winery = wineList[9]

                    });

                    counter++;

                }
            }

            return myWine;
        }

        public static string Test()
        {
            return "1";
        }
    }
}
