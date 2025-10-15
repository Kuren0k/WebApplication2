

using ConsoleApp2.DTO;
using System.Collections;
using System.Net.Http.Json;

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
                    Console.WriteLine("6 - Выход");
                    Console.Write("Ваш выбор: ");

                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            await One();
                            break;
                        //case "2":
                        //    await;
                        //    break;
                        //case "3":
                        //    await;
                        //    break;
                        //case "4":
                        //    await;
                        //    break;
                        //case "5":
                        //    await;
                        //    break;
                        case "6":
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
    }
}
