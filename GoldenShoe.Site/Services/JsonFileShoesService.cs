using GoldenShoe.Site.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GoldenShoe.Site.Services
{
    public class JsonFileShoesService
    {
        public JsonFileShoesService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }


        private string JsonShoesFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "shoesOnly.json"); }
        }



        public IEnumerable<ShoesOnly> GetShoesOnly()
        {
            using (var jsonFileReader = File.OpenText(JsonShoesFileName))
            {
                return JsonSerializer.Deserialize<ShoesOnly[]>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
        }

        // ----- Use for instantiating stock for each shoe ----- 
        private void LoadQuantity()
        {
            IEnumerable<ShoesOnly> shoeQQ = GetShoesOnly();
            foreach (var shoe in shoeQQ)
            {
                

                using (var outputStream = File.OpenWrite(JsonShoesFileName))
                {
                    JsonSerializer.Serialize<IEnumerable<ShoesOnly>>(
                        new Utf8JsonWriter(outputStream, new JsonWriterOptions
                        {
                            SkipValidation = true,
                            Indented = true,
                        }),
                    shoeQQ
                    );
                }
            }
        }

        public void ChangeQuantity(string shoeID)
        {
            // ----- BUG Error When losing 1 character in json file from 10 to 9 so starting with 9 ------

            //IEnumerable<ShoesOnly> shoeQQ = GetShoesOnly();
            //ShoesOnly selectedShoe = shoeQQ.FirstOrDefault(e => e.Id == shoeID);
            //selectedShoe.Stock--;
            //selectedShoe.OnSale="n";
            //using (var outputStream = File.OpenWrite(JsonShoesFileName))
            //{
            //    JsonSerializer.Serialize<IEnumerable<ShoesOnly>>(
            //        new Utf8JsonWriter(outputStream, new JsonWriterOptions
            //        {
            //            SkipValidation = true,
            //            Indented = true,
            //        }),
            //    shoeQQ
            //    );
            //}
                       
        }
    }
}
