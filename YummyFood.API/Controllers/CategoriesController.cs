﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyFood.Application.UseCases.Categories.Commands;
using YummyFood.Application.UseCases.Categories.Queries;

namespace YummyFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCateogyByIdAsync(long id, CancellationToken cancellationToken)
        {
            var query = new GetCategoryByIdQuery() { Id = id };

            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCateogiesAsync([FromQuery] int pageIndex, [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            var query = new GetAllCategoriesQuery() { PageIndex = pageIndex, PageSize = pageSize };

            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryByIdAsync(long id, CancellationToken cancellationToken)
        {
            var command = new DeleteCategoryCommand() { Id = id };

            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}
