

using ConsoleApp2.DTO;
using System.Collections;
using System.Net.Http.Json;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp2
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            client.BaseAddress = new Uri("http://localhost:5257/api/");
            try
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("1 - Получить список студентов из группы по указанному индексу группы");
                    Console.WriteLine("2 - Получить информацию о кол-ве мальчиков и девочек в группе по указанному индексу группы");
                    Console.WriteLine("3 - Получить список студентов, которые не привязаны ни к одной группе");
                    Console.WriteLine("4 - Получить список групп, в которых нет студентов");
                    Console.WriteLine("5 - Получить общую статистику по отделению");
                    Console.WriteLine("6 - Получить общую статистику по отделению, но с указанием индекса конкретной специальности");
                    Console.WriteLine("7 - Добавление новой группы для указанной специальности");
                    Console.WriteLine("8 - Перевод указанного студента в указанную группу");
                    Console.WriteLine("9 - Добавить метод, который возвратит дублирующегося студента (один и тот же человек в двух разных группах)");
                    Console.WriteLine("10 - Выход");
                    Console.Write("Ваш выбор: ");

                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            await One();
                            break;
                        case "2":
                            await Two();
                            break;
                        case "3":
                            await Three();
                            break;
                        case "4":
                            await Four();
                            break;
                        case "5":
                            await Five();
                            break;
                        case "6":
                            await Six();
                            break;
                        case "7":
                            await Seven();
                            break;
                        //case "8":
                        //    await Eight();
                        //    break;
                        //case "9":
                        //    await Nine();
                        //    break;
                        case "10":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Неверный выбор!");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static async Task One()
        {
            try
            {
                Console.Write("Введите id группы: ");
                var id = Console.ReadLine();
                var data = await client.GetFromJsonAsync<IEnumerable<StudentDTO>>($"Students/ListStudentsByGroup?groupIndex={id}");
                foreach(var data1 in data)
                {
                    Console.WriteLine($"{data1.LastName} {data1.FirstName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static async Task Two()
        {
            try
            {
                Console.Write("Введите id группы: ");
                var id = Console.ReadLine();
                var gender = await client.GetFromJsonAsync<GenderDTO>($"Students/ListStudentsMalOrDevByGroup?groupIndex={id}");
                Console.WriteLine($"Мальчиков: {gender.BoysCount}\nДевочек: {gender.GirlsCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static async Task Three()
        {
            try
            {
                var data = await client.GetFromJsonAsync<IEnumerable<StudentDTO>>($"Students/ListStudentsNotByGroup");
                foreach (var data1 in data)
                {
                    Console.WriteLine($"{data1.LastName} {data1.FirstName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        static async Task Four()
        {
            try
            {
                var data = await client.GetFromJsonAsync<IEnumerable<GroupDTO>>($"Students/ListGroupNotByStudents");
                foreach (var groupNotStudent in data)
                {
                    Console.WriteLine($"Id: {groupNotStudent.Id} Название: {groupNotStudent.Title}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        static async Task Five()
        {
            try
            {
                var data = await client.GetFromJsonAsync<IEnumerable<GroupAllDTO>>($"Students/ListAllGroup");
                foreach (var group in data)
                {
                    Console.WriteLine($"Id: {group.Id} Название: {group.Title} Кол-во студентов: {group.StudentCount}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        static async Task Six()
        {
            try
            {
                Console.Write("Введите id специальности: ");
                var id = Console.ReadLine();
                var data = await client.GetFromJsonAsync<IEnumerable<GroupAllDTO>>($"Students/ListAllGroup?specialIndex={id}");
                foreach (var group in data)
                {
                    Console.WriteLine($"Id: {group.Id} Название: {group.Title} Кол-во студентов: {group.StudentCount} Id спец: {group.IdSpecial} Название спец: {group.TitleSpecial}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        static async Task Seven()
        {
            try
            {
                Console.WriteLine("Id группы");
                int.TryParse(Console.ReadLine(), out int id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
