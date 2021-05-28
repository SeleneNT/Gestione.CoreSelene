using Gestione.Core.BusinessLayer;
using Gestione.Core.Entities;
using Gestione.Core.Repository;
using Gestione.EF.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestione.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdineController : ControllerBase
    {
        //Servizio REST per la gtione di anagrafica Ordini
        private IGestioneBL layer;

        public OrdineController()
        {
            var clientRepo = new EFClienteRepository();
            var orderRepo = new EFOrdineRepository();
            this.layer = new MainBusinessLayer(clientRepo, orderRepo);
        }

        #region HTTP Methods
        //NON implemento i metodi, passo solo la chiamata al BusinessLayer
        //Che poi la passerà al DAL di competenza, EF in quanto abbiamo implementato
        //solo Entity Framewor e non ADO.NET


        // GET  ->recupero ordini
        [HttpGet]
        public ActionResult Get()
        {
            var result = this.layer.FetchOrders();
            return Ok(result);
        }

        // GET ->recupero ordine by ID
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Order ID.");

            var order = this.layer.FetchOrderById(id);

            if (order== null)
                return NotFound($"Order with ID = {id} is missing.");

            return Ok(order);
        }

        // POST ->Inserisco un nuovo ordine
        [HttpPost]
        public ActionResult Post([FromBody] Ordine newOrder)
        {
            if (newOrder == null)
                return BadRequest("Invalid Order data.");

            this.layer.RegisterOrder(newOrder);
            //aggiorno anche la location della mia risorsa nell'header
            return Created($"/order/{newOrder.Id}", newOrder);
        }

        // PUT  ->Modifica i un ordine già esistente
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ordine orderToEdit)
        {
            if (orderToEdit == null)
                return BadRequest("Invalid Order data.");

            if (id != orderToEdit.Id)
                return BadRequest("Order ID don't match.");

            this.layer.UpdateOrder(orderToEdit);

            return Ok();
        }

        // DELETE -> cancello un ordine recuperando per ID
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Order ID.");

            var orderToBeDeleted = this.layer.FetchOrderById(id);
            if (orderToBeDeleted != null)
                this.layer.DeleteOrder(orderToBeDeleted);

            return Ok();
        }
        #endregion
    }
}
