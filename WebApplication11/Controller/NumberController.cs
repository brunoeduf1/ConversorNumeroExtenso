using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication11.Models;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Runtime.InteropServices.WindowsRuntime;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication8.Controller
{
    [Route("[controller]")]
    [ApiController]
    [FormatFilter]
    public class NumberController : ControllerBase
    {
        [HttpGet("/{id}.{format?}")]
        public Numero Get(string id)
        {
            Numero n = new Numero(id);
            n.ConverteNumero(id);

            return n;
        }



    }
}
