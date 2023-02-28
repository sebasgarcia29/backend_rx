using System;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Rxlightning.Entities;

namespace Rxlightning.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/patients")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PatientsController : ControllerBase
    {
        private readonly ILogger<PatientsController> logger;

        public PatientsController(ILogger<PatientsController> logger)
        {
            this.logger = logger;
        }

        [HttpGet] // https://localhost:7126/api/patients
        public ActionResult<List<Patients>> Get()
        {
            return new List<Patients>()
            {
                new Patients()
                {
                    patientId = "62421a54-0e45-4030-932c-0eeed3e08a2e",
                    firstName = "Sebas",
                    lastName= "Garcia",
                    gender= "Male",
                    dateOfBirth= new DateTime(2008, 6, 1, 7, 47, 0),
                    addressLine1 = "123 Fake Street",
                    addressLine2= "Suite 300",
                    city= "Baltimore",
                    state= "MD",
                    postalCode= "50109"

                },
                new Patients()
                {
                    patientId = "64198a44-ab4d-4c51-897f-fc70a6a5011f",
                    firstName = "Amos",
                    lastName= "Burton",
                    gender= "Male",
                    dateOfBirth= new DateTime(2008, 6, 1, 7, 47, 0),
                    addressLine1 = "456 North Avenue",
                    addressLine2= null,
                    city= "New York",
                    state= "NY",
                    postalCode= "00152"

                },
                new Patients()
                {
                    patientId = "59cd3910-8224-46c5-aab7-6fd2ef2fea79",
                    firstName = "Naomi",
                    lastName= "Nagata",
                    gender= "Female",
                    dateOfBirth= new DateTime(2008, 6, 1, 7, 47, 0),
                    addressLine1 = "789 South Circle",
                    addressLine2= "Apt 3B",
                    city= "Louisville",
                    state= "KY",
                    postalCode= "30158"

                },
                new Patients()
                {
                    patientId = "f5319eef-c9a9-4c18-a3be-3b6b82539e27",
                    firstName = "Chrisjen",
                    lastName= "Avasarala",
                    gender= "Female",
                    dateOfBirth= new DateTime(2008, 6, 1, 7, 47, 0),
                    addressLine1 = "8956 Oak Street",
                    addressLine2= null,
                    city= "San Diego",
                    state= "CA",
                    postalCode= "90210"

                },
                new Patients()
                {
                    patientId = "8f7b51a8-8082-4864-87e5-923c80e91840",
                    firstName = "Clarissa",
                    lastName= "Mao",
                    gender= "Female",
                    dateOfBirth= new DateTime(2008, 6, 1, 7, 47, 0),
                    addressLine1 = "3845 Lakeview Drive",
                    addressLine2= "Unit 37 Left",
                    city= "Chicago",
                    state= "IL",
                    postalCode= "40589"

                }
            };
        }

        [HttpGet("{id:int}")]
        public Task<ActionResult<Patients>> Get(int Id)
        {

            throw new NotImplementedException();

        }

        [HttpPost]
        public ActionResult Post([FromBody] Patients gender)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Patients gender)
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }

    }
}

