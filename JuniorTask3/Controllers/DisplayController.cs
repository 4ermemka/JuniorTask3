using JuniorTask3.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JuniorTask3.Controllers
{
    public class DisplayController : Controller // Контроллер отображения информации
    {
        private readonly IDisplayService _displayService; // Сервис обработки информации (списка)
        public DisplayController(IDisplayService displayService)
        {
            _displayService = displayService;
        }

        public IActionResult InputValues() // Отобразить форму для ввода массива
        {
            return View();
        }

        [HttpPost]
        public IActionResult InputValues(IFormCollection fc) // Обработать данные из формы
        {
            _displayService.SetNums(fc); // Задать сервису информацию
            return RedirectToAction("CountResults", "CountResults", 
                new { json = GetArrayInJson(_displayService.GetNums()).Value.ToString()}); // Обращение к другому контроллеру с информацией
            //Информация кодируется в JSON формат и отправляется строкой
        }

        [HttpGet]
        public IActionResult ShowResults(string json) // получает JSON c отсортированным массивом из контроллера-сортировщика
        {
            int[] data = JsonConvert.DeserializeObject<int[]>(json);
            return View(data);
        }

        public JsonResult GetArrayInJson(IEnumerable<int> data) // конвертация массива в JSON
        {
            var json = JsonConvert.SerializeObject(data);
            return Json(json);
        }
    }
}
