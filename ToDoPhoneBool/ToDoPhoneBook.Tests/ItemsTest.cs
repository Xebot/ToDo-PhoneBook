using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoPhoneBook.Contracts.Models;
using ToDoPhoneBook.Core.Services.ToDoService;
using ToDoPhoneBook.Domain.Entites;
using ToDoPhoneBook.Infrastructure.Repositories;

namespace ToDoPhoneBook.Tests
{
    [TestFixture]
    public class ItemsTest
    {
        private Mock<IMapper> _mapperMock;
        private Mock<IToDoItemsRepository> _repositoryMock;
        private Mock<ILogger<ToDoService>> _loggerMock;
        private ToDoService _service;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _repositoryMock = new Mock<IToDoItemsRepository>();
            _loggerMock = new Mock<ILogger<ToDoService>>();
            _service = new ToDoService(_repositoryMock.Object, _mapperMock.Object, _loggerMock.Object);
        }

        [Test]
        public void GetItemWithTextSearch()
        {
            //Arrange
            var filter = new SearchItemFilter
            {
                PageNumber = 0,
                TakeCount = 10,
                SearchPhrase = "meet",
                ItemType = Contracts.Enums.ToDoTypeEnum.Meeting,
                PeriodType = Contracts.Enums.TimePeriodEnum.AllTime
            };
            var item = new ToDoItem
            {
                ItemType = Contracts.Enums.ToDoTypeEnum.Meeting,
                Title = "meet in cafe",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Place = "cafe",
                IsDone = false
            };
            var resultItem = new ToDoItemDto
            {
                Title = "meet in cafe"
            };
            _mapperMock.Setup(x => x.Map<ToDoItemDto>(item)).Returns(resultItem);
            _repositoryMock.Setup(r => r.GetAll()).Returns(new List<ToDoItem> { item }.AsQueryable<ToDoItem>());

            //Act
            var todoItemDto = _service.GetToDoItems(filter);

            //Assets
            Assert.AreEqual(item.Title, todoItemDto.rows.FirstOrDefault().Title);
        }

        [Test]
        public void GetItemWithDateSearch()
        {
            //Arrange
            var filter = new SearchItemFilter
            {
                PageNumber = 0,
                TakeCount = 10,
                SearchPhrase = "meet",
                ItemType = Contracts.Enums.ToDoTypeEnum.Meeting,
                PeriodType = Contracts.Enums.TimePeriodEnum.AllTime,
                SearchStartDate = new DateTime(2020, 10, 10)
            };
            var item = new ToDoItem
            {
                ItemType = Contracts.Enums.ToDoTypeEnum.Meeting,
                Title = "meet in cafe",
                StartDate = new DateTime(2020, 10, 10),
                EndDate = DateTime.Now,
                Place = "cafe",
                IsDone = false,
            };
            var resultItem = new ToDoItemDto
            {
                Title = "meet in cafe",
                StartDate = new DateTime(2020, 10, 10)
            };
            _mapperMock.Setup(x => x.Map<ToDoItemDto>(item)).Returns(resultItem);
            _repositoryMock.Setup(r => r.GetAll()).Returns(new List<ToDoItem> { item }.AsQueryable<ToDoItem>());

            //Act
            var todoItemDto = _service.GetToDoItems(filter);

            //Assets
            Assert.AreEqual(item.StartDate, todoItemDto.rows.FirstOrDefault().StartDate);
        }

        [Test]
        public void GetItemButNothingFind()
        {
            //Arrange
            var filter = new SearchItemFilter
            {
                PageNumber = 0,
                TakeCount = 10,
                SearchPhrase = "meet",
                ItemType = Contracts.Enums.ToDoTypeEnum.Meeting,
                PeriodType = Contracts.Enums.TimePeriodEnum.AllTime,
                SearchStartDate = new DateTime(2021, 10, 10)
            };
            var item = new ToDoItem
            {
                ItemType = Contracts.Enums.ToDoTypeEnum.Meeting,
                Title = "meet in cafe",
                StartDate = new DateTime(2020, 10, 10),
                EndDate = DateTime.Now,
                Place = "cafe",
                IsDone = false,
            };
            var resultItem = new ToDoItemDto
            {
                Title = "meet in cafe",
                StartDate = new DateTime(2020, 10, 10)
            };
            _mapperMock.Setup(x => x.Map<ToDoItemDto>(item)).Returns(resultItem);
            _repositoryMock.Setup(r => r.GetAll()).Returns(new List<ToDoItem> { item }.AsQueryable<ToDoItem>());

            //Act
            var todoItemDto = _service.GetToDoItems(filter);

            //Assets
            Assert.IsEmpty(todoItemDto.rows);
        }
    }
}
