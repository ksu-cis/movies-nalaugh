using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Movies
{
    /// <summary>
    /// A class representing a database of movies
    /// </summary>
    public class MovieDatabase
    {
        private List<Movie> movies = new List<Movie>();

        /// <summary>
        /// Loads the movie database from the JSON file
        /// </summary>
        public MovieDatabase()
        {

            using (StreamReader file = System.IO.File.OpenText("movies.json"))
            {
                string json = file.ReadToEnd();
                movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            }
        }

        public List<Movie> All { get { return movies; } }

        public List<Movie> SearchAndFilter(string search, List<string> rating)
        {
            //Case0: do nothing
            if (search == null && rating.Count == 0) return All;

            List<Movie> result = new List<Movie>();

            foreach (Movie m in movies)
            {
                //Case1: Search string and rating
                if (search != null && rating.Count > 0)
                {
                    if (m.Title != null && rating.Contains(m.MPAA_Rating) && m.Title.Contains(search, StringComparison.InvariantCultureIgnoreCase))
                    {
                        result.Add(m);
                    }

                }
                //Case2: Search sting only
                else if (search != null)
                {
                    if (m.Title != null && m.Title.Contains(search, StringComparison.InvariantCultureIgnoreCase))
                    {
                        result.Add(m);
                    }
                }
                //Case3: search rating only
                else if (rating.Count > 0)
                {
                    if (rating.Contains(m.MPAA_Rating))
                    {
                        result.Add(m);
                    }
                }
            }
            return result;
        }
        public List<Movie> orderdate(string date)
        {
            string release ="";
            return movies;
        }
    }

}
