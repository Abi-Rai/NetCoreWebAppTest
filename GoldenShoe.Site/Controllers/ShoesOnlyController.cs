using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoldenShoe.Site.Models;
using GoldenShoe.Site.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoldenShoe.Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoesOnlyController : ControllerBase
    {
        public ShoesOnlyController(JsonFileShoesService shoesService, JsonFileReviewsService reviewsService)
        {
            this.ShoesService = shoesService;
        }

        public JsonFileShoesService ShoesService { get; }

        [HttpGet]
        public IEnumerable<ShoesOnly> Get()
        {
            return ShoesService.GetShoesOnly();
        }
    }
}