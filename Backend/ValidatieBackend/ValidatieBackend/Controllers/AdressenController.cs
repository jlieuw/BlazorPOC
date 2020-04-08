using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using System.Threading.Tasks;
using ValidatieBackend.services;

// https://johnthiriet.com/efficient-api-calls/
namespace ValidatieBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdressenController : ControllerBase
    {
        private IAdresService Service { get; set; }


        public AdressenController(IAdresService adresService)
        {
            Service = adresService;
        }

        [HttpGet]
        public async Task<ActionResult<AdresModel>> Get()
        {
            var result = await Service.AdressenLijst();
            return Ok(result);
        }
    }
}