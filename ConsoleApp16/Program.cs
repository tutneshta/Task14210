using System;
using System.Collections.Generic;
using System.Linq;

namespace Task14210
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            while (true)
            {
                var input = Console.ReadKey().KeyChar;

                Console.Clear();

                var parsed = int.TryParse(input.ToString(), out var pageNumber);

                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.Clear();
                    Console.WriteLine($"Страницы {input} не существует");
                }

                else
                {
                    // Сортировка всего списка по имени и фамилии
                    var sortContact = phoneBook.OrderBy(s => s.Name).ThenBy(s => s.LastName);

                    //постраничный вывод отсортированного списка
                    var pageContent = sortContact.Skip((pageNumber - 1) * 2).Take(2);

                    Console.WriteLine($"Страница {input}");

                    foreach (var entry in pageContent)
                        Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);
                }
            }
        }
    }
}