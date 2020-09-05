using System;
using System.Linq;

namespace ToDoPhoneBook.Infrastructure.Tools
{
    /// <summary>
    /// Вспомогательный класс для заполнения БД тестовыми данными.
    /// </summary>
    public static class DbSeeder
    {
        public static void Seed(AppDbContext dbContext)
        {
            if (dbContext.ToDoItems.Count() > 0)
                return;
            
            dbContext.ToDoItems.Add(new Domain.Entites.ToDoItem 
            {
                ItemType = Contracts.Enums.ToDoTypeEnum.Meeting,
                Title = "Встреча с друзьями",
                StartDate = new DateTime(2020, 09, 10, 18, 00, 00),
                EndDate = new DateTime(2020, 09, 10, 22, 00, 00),
                Place = "Кафе"            
            });            
            dbContext.ToDoItems.Add(new Domain.Entites.ToDoItem
            {
                ItemType = Contracts.Enums.ToDoTypeEnum.Meeting,
                Title = "Встреча с курьером",
                StartDate = new DateTime(2020, 09, 11, 15, 00, 00),
                EndDate = new DateTime(2020, 09, 11, 15, 20, 00),
                Place = "Возле дома"
            });
                dbContext.ToDoItems.Add(new Domain.Entites.ToDoItem
                {
                    ItemType = Contracts.Enums.ToDoTypeEnum.Meeting,
                    Title = "День Рождения у друга",
                    StartDate = new DateTime(2020, 10, 10, 18, 00, 00),
                    EndDate = new DateTime(2020, 10, 10, 23, 30, 00),
                    Place = "Ресторан"
                });
                dbContext.ToDoItems.Add(new Domain.Entites.ToDoItem
                {
                    ItemType = Contracts.Enums.ToDoTypeEnum.Business,
                    Title = "Починить замок",
                    StartDate = new DateTime(2020, 09, 06, 12, 15, 00),
                    EndDate = new DateTime(2020, 09, 06, 12, 30, 00)
                });
                dbContext.ToDoItems.Add(new Domain.Entites.ToDoItem
                {
                    ItemType = Contracts.Enums.ToDoTypeEnum.Business,
                    Title = "Поломать розетку",
                    StartDate = new DateTime(2020, 09, 06, 12, 31, 00),
                    EndDate = new DateTime(2020, 09, 06, 12, 32, 00)
                });
                dbContext.ToDoItems.Add(new Domain.Entites.ToDoItem
                {
                    ItemType = Contracts.Enums.ToDoTypeEnum.Business,
                    Title = "Починить розетку",
                    StartDate = new DateTime(2020, 09, 06, 12, 33, 00),
                    EndDate = new DateTime(2020, 09, 06, 18, 30, 00)
                });
                dbContext.ToDoItems.Add(new Domain.Entites.ToDoItem
                {
                    ItemType = Contracts.Enums.ToDoTypeEnum.Memo,
                    Title = "На заметку: в Лондон ни ногой",
                    StartDate = new DateTime(2020, 09, 06, 12, 30, 00)
                });
                dbContext.ToDoItems.Add(new Domain.Entites.ToDoItem
                {
                    ItemType = Contracts.Enums.ToDoTypeEnum.Memo,
                    Title = "На заметку: мыть руки чаще",
                    StartDate = new DateTime(2020, 09, 07, 12, 30, 00)
                });
                dbContext.ToDoItems.Add(new Domain.Entites.ToDoItem
                {
                    ItemType = Contracts.Enums.ToDoTypeEnum.Memo,
                    Title = "Носить маску в помещении",
                    StartDate = new DateTime(2020, 09, 08, 12, 30, 00)
                });


                dbContext.SaveChanges();

        }
    }
}
