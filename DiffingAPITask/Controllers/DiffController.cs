using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Caching;
using System.IO;
using DiffingAPITask.Models;
using System.Runtime.Caching;

namespace DiffingAPITask.Controllers
{
    public class DiffController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            // this will return the diff (third endpoint)
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            //return diff result type

            //first we check if th

            Diff myDiff = new Diff();

            string result = myDiff.getdiffResultType();

            if (result == "Equals")
            {
                return Ok(result);
            }
            else if (result == "SizeDoNotMatch")
            {
                return Ok(result);
            }
            else if (result == "ContentDoNotMatch")
            {

                // return the information 
                string returnvalue = myDiff.rtnVal();

                return Ok(returnvalue);
            }
            else
            {
                return NotFound();   
            }


        }



        // PUT api/<controller>/5/{left or right}/
        public IHttpActionResult Put(int id,string position, [FromBody] string value)
        {
            // this will put the data based on left or right

            //the object will be in json so we need to deserialize and place into cache memory

            // if data is null return 400 bad request
            // else return 201 created

            // if the data is null return bad request
            if (value == null)
            {
                return BadRequest();

            }

            //add value to model
            Diff newDiff = new Diff();
            newDiff.add(value,position);



            //return ok
            return Ok();







        }



    }
}