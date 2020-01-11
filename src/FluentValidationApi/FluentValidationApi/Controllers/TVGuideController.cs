using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationApi.Controllers
{
    /// <summary>
    /// Manages de TV Guide
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TVGuideController : ControllerBase
    {
        /// <summary>
        /// Gets you the shows from the tv guide
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IEnumerable<string>> Get()
        {
            return Task<IEnumerable<string>>.Factory
                .StartNew(() => new List<string>
                {
                    "sports", "news", "weatherforecast"
                });
        }
    }
}