using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDoPhoneBook.Contracts.Models;
using ToDoPhoneBook.Core.Services.ToDoService;
using ToDoPhoneBool.Controllers;

namespace ToDoPhoneBook.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoService _toDoService;
        private readonly ILogger<HomeController> _logger;

        public ToDoController(
            IToDoService toDoService,
            ILogger<HomeController> logger)
        {
            _toDoService = toDoService;
            _logger = logger;
        }
        // GET: ToDoController
        public ActionResult Index()
        {
            //var result = _toDoService.GetToDoItems(10,0);
            //return View(result);
            return View();
        }

        // GET: ToDoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ToDoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ToDoItemDto dto, IFormCollection collection)
        {
            try
            {
                var errors = ValidateInputParameters(dto);

                if (errors.Count() > 0)
                {
                    ViewBag.Errors = errors.ToArray();
                    return View();
                }

                _toDoService.CreateItem(dto);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Произошло исключение при попытке создать сущность.");
                return View();
            }
        }

        // GET: ToDoController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = _toDoService.GetItem(id);

            if (item == null)
            {
                ViewBag.Errors = new string[] { "Запись не найдена" };
                return View();
            }

            return View(item);
        }

        // POST: ToDoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm]ToDoItemDto dto, int id, IFormCollection collection)
        {
            try
            {
                var errors = ValidateInputParameters(dto);
                
                if (errors.Count() > 0)
                    return BadRequest(string.Join(Environment.NewLine, errors.ToArray()));

                _toDoService.UpdateItem(dto);
                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при попытке редактирования записи");
                return View();
            }
        }

        // GET: ToDoController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _toDoService.DeleteItem(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при попытке удалить сущность");
                return RedirectToAction("Edit", "ToDo", new { Id = id });
            }
        }

        private List<string> ValidateInputParameters(ToDoItemDto dto)
        {
            var errors = new List<string>();
            if (dto == null)
            {
                errors.Add("Модель не может быть пустой");
                return errors;
            }

            if (string.IsNullOrWhiteSpace(dto.Title))
                errors.Add("Тема должна быть заполнена");

            if (dto.StartDate.HasValue && dto.StartDate < DateTime.MinValue)
                errors.Add("Не заполнена или заполнена неправильно дата начала действия");

            if (dto.EndDate.HasValue && !dto.StartDate.HasValue)
                errors.Add("Если есть дата начала, то необходима и дата окончания");

            if (dto.EndDate.HasValue && (dto.EndDate > DateTime.MaxValue || dto.EndDate < DateTime.MinValue || dto.EndDate < dto.StartDate))
                errors.Add("Неправильно заполнена дата окончания действия");

            return errors;
        }
    }
}
