using Microsoft.AspNetCore.Mvc;
using NaveDaCrociera.DB;
using NaveDaCrociera.DB.Entities;
using NaveDaCrociera.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NaveDaCrociera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly Repository repository;
        public APIController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpPost("PrenotaPosti")]
        public async Task<IActionResult> PrenotaPosti([FromBody] SpettacoliModel model)
        {
            int n1 = 0;
            int n2 = 0;
            n1 = Int32.Parse(model.Posti);
            n2 = Int32.Parse(model.PostiPre);
            if (model.Annullato == "0")
            {
                if ( n1>=n2 )
                {
                Spettacoli spettacoli = new Spettacoli();
                spettacoli.Id = model.Id;
                spettacoli.Locale = model.Locale;
                spettacoli.NomeEvento = model.NomeEvento;
                spettacoli.Posti = (n1-n2).ToString();
                spettacoli.Annullato = model.Annullato;
                this.repository.UpdateSpettacoli(spettacoli);
                return Ok(200);
                }
                else
                {
                    return Ok(200);
                }
            }
            else
            {
                return Ok(100);
            }
            
            return Ok(200);
        }

        // POST api/<PersonController>
        [HttpPost("InsertPrenotazioniSpettacoli")]
        public async Task<IActionResult> InsertPrenotazioniSpettacoli([FromBody] PrenotazioniSpettacoliModel model)
        {
            PrenotazioniSpettacoli prenotazioniSpettacoli = new PrenotazioniSpettacoli();
            prenotazioniSpettacoli.Id = model.Id;
            prenotazioniSpettacoli.NomeEvento = model.NomeEvento;
            prenotazioniSpettacoli.Locale = model.Locale;
            prenotazioniSpettacoli.PostiPre = model.PostiPre;
            this.repository.InsertPrenotazioniSpettacoli(prenotazioniSpettacoli);
            return Ok();
        }

        //// GET: api/<APIController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<APIController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<APIController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<APIController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<APIController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
