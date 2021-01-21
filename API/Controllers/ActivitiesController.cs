using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //  Utilizo el route como en ValuesController
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> List(){
            List.Query request = new List.Query();
            return await _mediator.Send(request);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> Details(Guid id){
            return await _mediator.Send(new Details.Query{Id = id});

        } 

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command){
            return await _mediator.Send(command);
        } 

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id, Edit.ECommand ecommand){
            ecommand.Id = id;
            return await _mediator.Send(ecommand);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id){
            return await _mediator.Send(new Delete.DCommand{Id = id});
        }
       

    }
}