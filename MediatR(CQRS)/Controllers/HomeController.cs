using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Cars.Commands;
using Services.Cars.Queries;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatR_CQRS_.Controllers
{
    [ApiController]
    [Route("cars")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            this._mediator = mediator;
        }

        // first way
        //public Task<IEnumerable<Car>> Index([FromBody] GetAllCarsQuery query)
        //{
        //    return this._mediator.Send(query);
        //}

        // second way
        [HttpGet]
        public Task<IEnumerable<Car>> Index()
        {
            return this._mediator.Send(new GetAllCarsQuery());
        }

        [HttpPost]
        public Task<string> Index([FromBody] CreateCarCommand command)
        {
            return this._mediator.Send(command);
        }
    }
}
