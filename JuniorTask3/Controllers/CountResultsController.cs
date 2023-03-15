using JuniorTask3.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace JuniorTask3.Controllers
{
    public class CountResultsController : Controller // Контроллер обработки информации
    {
        private readonly ICountResultsService _countResultsService; // Сервис сортировки массива

        public CountResultsController(ICountResultsService countResultsService)
        {
            _countResultsService = countResultsService;
        }

        public IActionResult CountResults(string json) // получает JSON с массивом внутри. Обрабатывает его и отсылает обратно.
        {
            IEnumerable<int> data = JsonConvert.DeserializeObject<IEnumerable<int>>(json);
            _countResultsService.SetList(data.ToArray<int>());
            _countResultsService.BubbleSort(); // сортировка 
            int[] result = _countResultsService.GetList();
            return RedirectToAction("ShowResults", "Display", new { json = GetArrayInJson(result).Value.ToString() }); // редирект на дисплей-контроллер
        }
        public JsonResult GetArrayInJson(int[] data)
        {
            var json = JsonConvert.SerializeObject(data);
            return Json(json);
        }
    }
}
