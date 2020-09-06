using System;

namespace ToDoPhoneBook.Infrastructure.Tools
{
    /// <summary>
    /// Методы расширений для работы с датой.
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// Получает дату начала текущей недели.
        /// </summary>
        /// <param name="dt">Текущая дата.</param>
        /// <param name="startOfWeek">День с которого начинается неделя.</param>
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// Получает последний день недели.
        /// </summary>
        /// <param name="dt">Дата для которой рассчитывается.</param>
        /// <param name="startOfWeek">День с которого начинается неделя.</param>
        public static DateTime EndOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            return dt.StartOfWeek(startOfWeek).AddDays(7).EndOfDay();
        }

        /// <summary>
        /// Рассчитывает начало дня.
        /// </summary>
        /// <param name="dt">Дата.</param>
        public static DateTime StartOfDay(this DateTime dt)
        {
            var now = DateTime.Now;
            return new DateTime(now.Year, now.Month, now.Day, 00, 00, 00);
        }

        /// <summary>
        /// Рассчитывает конец дня.
        /// </summary>
        /// <param name="dt">Дата.</param>
        public static DateTime EndOfDay(this DateTime dt)
        {
            var now = DateTime.Now;
            return new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
        }

        /// <summary>
        /// Рассчитывает начало месяца.
        /// </summary>
        /// <param name="dt">Дата.</param>
        public static DateTime StartOfMonth(this DateTime dt)
        {
            var now = DateTime.Now;
            return new DateTime(now.Year, now.Month, 1, 00, 00, 00);
        }

        /// <summary>
        /// Рассчитывает конец месяца.
        /// </summary>
        /// <param name="dt">Дата.</param>
        public static DateTime EndOfMonth(this DateTime dt)
        {
            return dt.StartOfMonth().AddMonths(1).AddSeconds(-1);
        }
    }
}
