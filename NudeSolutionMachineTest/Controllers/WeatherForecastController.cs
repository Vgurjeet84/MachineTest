using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NudeSolutionMachineTest.Data;
using NudeSolutionMachineTest.Models;

namespace NudeSolutionMachineTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly MachineTestDbContext _dbContext;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, MachineTestDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Getdata")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var categories = await _dbContext.Categories.ToListAsync();
            return Ok(categories);
        }

        

        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] Category categoryReq)
        {
            categoryReq.Id = Guid.NewGuid();
            await _dbContext.Categories.AddAsync(categoryReq);
            await _dbContext.SaveChangesAsync();
            return Ok(categoryReq);
        }

        [HttpPost]
        [Route("AddSubCategory")]
        public async Task<IActionResult> AddSubCategory([FromBody] SubCategory SubcategoryReq)
        {
            await _dbContext.SubCategories.AddAsync(SubcategoryReq);
            await _dbContext.SaveChangesAsync();
            return Ok(SubcategoryReq);
        }
    }
}