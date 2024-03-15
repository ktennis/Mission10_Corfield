using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlerController : ControllerBase
    {
        private IBowlerRepository _bowlerRepository;
        public BowlerController(IBowlerRepository temp) {
            _bowlerRepository = temp;
        }
        //[HttpGet]
        //public IEnumerable<Bowler> Get()
        //{
        //    var bowlerData = _bowlerRepository.Bowlers
        //                     .ToArray();

        //    return bowlerData;
        //}
        [HttpGet]
        public IEnumerable<Bowler> Get()
        {
            var bowlerData = _bowlerRepository.Bowlers
                .ToArray();

            return bowlerData;
        }

    }
}
