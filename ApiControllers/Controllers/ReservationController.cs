﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using ApiControllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiControllers.Controllers
{
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private IRepository repository;
        public ReservationController(IRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public IEnumerable<Reservation> Get() => repository.Reservations;
        [HttpGet("{id}")]
        public Reservation Get(int id) => repository[id];
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    Reservation result = repository[id];
        //    if (result == null)
        //        return NotFound();
        //    else
        //        return Ok(result);
        //}
        [HttpPost]
        public Reservation Post([FromBody] Reservation res) =>
            repository.AddReservation(new Reservation
            {
                ClientName = res.ClientName,
                Location = res.Location
            });
        [HttpPut]
        public Reservation Put([FromBody] Reservation res) => repository.UpdateReservation(res);
        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id,[FromBody]JsonPatchDocument<Reservation> patch)
        {
            Reservation res = Get(id);
            if (res != null)
            {
                patch.ApplyTo(res);
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public void Delete(int id) => repository.DeleteReservation(id);
    }
}
