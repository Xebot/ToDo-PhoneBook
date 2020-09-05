using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoPhoneBook.Core.Services.ToDoService;
using ToDoPhoneBook.Models;

namespace ToDoPhoneBook.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoItemsController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpPost]
        public IActionResult List([FromForm]SearchFilter filter)
        {
            //if (count <= 0 || pageNumber < 0)
            //    return BadRequest();

            var items = _toDoService.GetToDoItems(filter.RowCount, filter.Current);

            return Ok(items);
        }
    }
}
