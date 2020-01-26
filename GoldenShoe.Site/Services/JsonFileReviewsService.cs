using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using GoldenShoe.Site.Models;
using Microsoft.AspNetCore.Hosting;

namespace GoldenShoe.Site.Services
{
    public class JsonFileReviewsService
    {
        public JsonFileReviewsService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "reviews.json"); }
        }
        public IEnumerable<Reviews> GetReviews()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Reviews[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        //public void AddBlock()
        //{
        //    IEnumerable<Reviews> reviews = GetReviews();
        //    List<Reviews> reviewsList = reviews.ToList();
        //    int[] x = new int[1];
        //    string[] xtext = new string[1];
        //    for (int i = 22; i < 25; i++)
        //    {
        //        reviewsList.Add(new Reviews(
        //      "", x, xtext, i
        //      ));

        //        using (var outputStream = File.OpenWrite(JsonFileName))
        //        {
        //            JsonSerializer.Serialize<IEnumerable<Reviews>>(
        //                new Utf8JsonWriter(outputStream, new JsonWriterOptions
        //                {
        //                    SkipValidation = true,
        //                    Indented = true,
        //                }),
        //            reviews
        //            );
        //        }
        //    }

        //}

        public void AddRating(string shoeId, int rating)
        {
            IEnumerable<Reviews> reviews = GetReviews();


            var query = reviews.First(x => x.Id == shoeId);
            if (query.Ratings == null)
            {
                query.Ratings = new int[] { rating };
            }
            else
            {
                var ratings = query.Ratings.ToList();
                ratings.Add(rating);
                query.Ratings = ratings.ToArray();
            }
            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Reviews>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true,
                    }),
                reviews
                );
            }
        }

        public void ClearAllRatings()
        {
            IEnumerable<Reviews> reviews = GetReviews();

            foreach (var review in reviews)
            {
                //review.Ratings = null;

                if (review.Ratings == null)
                {
                    continue;
                    
                }
                else
                {
                    review.Id = review.Id;
                    review.Ratings = null;
                    review.ReviewsText = null;
                    review.Position = review.Position;
                }

                using (var outputStream = File.OpenWrite(JsonFileName))
                {
                    JsonSerializer.Serialize<IEnumerable<Reviews>>(
                        new Utf8JsonWriter(outputStream, new JsonWriterOptions
                        {
                            
                            SkipValidation = true,
                            Indented = true,
                        }),
                    reviews
                    );
                }
            }

        }

        // ******** shoes only write ********  for index addId

        //private string JsonShoesFileName
        //{
        //    get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "shoesOnly.json"); }
        //}
        //public IEnumerable<ShoesOnly> GetShoesOnly()
        //{
        //    using (var jsonFileReader = File.OpenText(JsonShoesFileName))
        //    {
        //        return JsonSerializer.Deserialize<ShoesOnly[]>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions
        //        {
        //            PropertyNameCaseInsensitive = true
        //        });
        //    }
        //}
        // ******** end shoes only ******** 

        // ******** Id injector for Json File. ******** 
        //public void AddId()
        //{
        //    IEnumerable<ShoesOnly> shoes = GetShoesOnly();

        //    IEnumerable<Reviews> reviews = GetReviews();

        //    foreach (var shoe in shoes)
        //    {
        //        foreach (var review in reviews)
        //        {
        //            if (shoe.Position == review.Position)
        //            {
        //                review.Id = shoe.Id;
        //                using (var outputStream = File.OpenWrite(JsonFileName))
        //                {
        //                    JsonSerializer.Serialize<IEnumerable<Reviews>>(
        //                        new Utf8JsonWriter(outputStream, new JsonWriterOptions
        //                        {
        //                            SkipValidation = true,
        //                            Indented = true,

        //                        }),
        //                        reviews
        //                    );
        //                }
        //                break;
        //            }
        //        }
        //    }
        //}
        // ******** End injector for Json File. ******** 
    }
}

