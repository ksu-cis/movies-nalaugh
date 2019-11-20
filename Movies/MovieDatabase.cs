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
        private static List<Movie> movies = new List<Movie>();

        /// <summary>
        /// Loads the movie database from the JSON file
        /// </summary>
        public  MovieDatabase()
        {

            using (StreamReader file = System.IO.File.OpenText("movies.json"))
            {
                string json = file.ReadToEnd();
                movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            }
        }


        public static List<Movie> All { get { return movies; } }
        public static List<Movie> Search(List<Movie> movies, string search)
        {
            List<Movie> results = new List<Movie>();
            foreach (Movie m in movies)
            {
                {
                    if (m.Title.Contains(search, StringComparison.InvariantCultureIgnoreCase))
                    {
                        results.Add(m);
                    }

                }
            }
            return results;
        }
        public static List<Movie> Rating(List<Movie> movies, List<string> rating)
        {
            List<Movie> results = new List<Movie>();
            foreach(Movie m in movies)
            {
                if (rating.Contains(m.MPAA_Rating))
                {
                    results.Add(m);
                }
            }
            return results;
        }
        public static List<Movie> MinSearch(List<Movie> movies, float minRating)
        {
            List<Movie> results = new List<Movie>();
            foreach (Movie m in movies)
            {
                if (m.IMDB_Rating!=null&&m.IMDB_Rating>= minRating)
                {
                    results.Add(m);
                }
            }
            return results;
        }
        public static List<Movie> MaxSearch(List<Movie> movies, float maxRating)
        {
            List<Movie> results = new List<Movie>();
            foreach (Movie m in movies)
            {
                if (m.IMDB_Rating != null && m.IMDB_Rating <= maxRating)
                {
                    results.Add(m);
                }
            }
            return results;
        }

    }

}
