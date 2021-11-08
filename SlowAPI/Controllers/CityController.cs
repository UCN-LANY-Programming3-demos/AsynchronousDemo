using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SlowAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private static readonly Dictionary<string, string> _cities = new();

        static CitiesController()
        {
            _cities.Add("9000", "Aalborg");
            _cities.Add("9200", "Aalborg SV");
            _cities.Add("9210", "Aalborg SØ");
            _cities.Add("9220", "Aalborg Øst");
            _cities.Add("9230", "Svenstrup J");
            _cities.Add("9240", "Nibe");
            _cities.Add("9260", "Gistrup");
            _cities.Add("9270", "Klarup");
            _cities.Add("9280", "Storvorde");
            _cities.Add("9293", "Kongerslev");
            _cities.Add("9300", "Sæby");
            _cities.Add("9310", "Vodskov");
            _cities.Add("9320", "Hjallerup");
            _cities.Add("9330", "Dronninglund");
            _cities.Add("9340", "Asaa");
            _cities.Add("9352", "Dybvad");
            _cities.Add("9362", "Gandrup");
            _cities.Add("9370", "Hals");
            _cities.Add("9380", "Vestbjerg");
            _cities.Add("9381", "Sulsted");
            _cities.Add("9382", "Tylstrup");
            _cities.Add("9400", "Nørresundby");
            _cities.Add("9430", "Vadum");
            _cities.Add("9440", "Aabybro");
            _cities.Add("9460", "Brovst");
            _cities.Add("9480", "Løkken");
            _cities.Add("9490", "Pandrup");
            _cities.Add("9492", "Blokhus");
            _cities.Add("9493", "Saltum"); 
            _cities.Add("9500", "Hobro");
            _cities.Add("9510", "Arden");
            _cities.Add("9520", "Skørping");
            _cities.Add("9530", "Støvring");
            _cities.Add("9541", "Suldrup");
            _cities.Add("9550", "Mariager");
            _cities.Add("9560", "Hadsund");
            _cities.Add("9574", "Bælum");
            _cities.Add("9575", "Terndrup");
            _cities.Add("9600", "Aars");
            _cities.Add("9610", "Nørager");
            _cities.Add("9620", "Aalestrup");
            _cities.Add("9631", "Gedsted");
            _cities.Add("9632", "Møldrup");
            _cities.Add("9640", "Farsø");
            _cities.Add("9670", "Løgstør");
            _cities.Add("9681", "Ranum");
            _cities.Add("9690", "Fjerritslev");
            _cities.Add("9700", "Brønderslev");
            _cities.Add("9740", "Jerslev J");
            _cities.Add("9750", "Østervrå");
            _cities.Add("9760", "Vrå");
            _cities.Add("9800", "Hjørring");
            _cities.Add("9830", "Tårs");
            _cities.Add("9850", "Hirtshals");
            _cities.Add("9870", "Sindal");
            _cities.Add("9881", "Bindslev");
            _cities.Add("9900", "Frederikshavn");
            _cities.Add("9940", "Læsø");
            _cities.Add("9970", "Strandby");
            _cities.Add("9981", "Jerup");
            _cities.Add("9982", "Ålbæk");
            _cities.Add("9990", "Skagen");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cities);
        }

        [HttpGet("{postalCode}")]
        public IActionResult Get(string postalCode)
        {
            try
            {
                string city = _cities[postalCode];
                Thread.Sleep(5000);
                return Ok(city);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (ArgumentNullException)
            {
                return BadRequest(postalCode);
            }
        }
    }
}
