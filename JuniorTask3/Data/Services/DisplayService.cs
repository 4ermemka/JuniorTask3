using JuniorTask3.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace JuniorTask3.Data.Services
{
    public class DisplayService : IDisplayService // Сервис отображения информации
    {
        IEnumerable<int> _arr;

        public void SetNums(IFormCollection fc) // получение в массив информации из формы
        {
            _arr = Array.ConvertAll(fc["num"].ToString().Split(','), s => int.Parse(s));
        }

        public IEnumerable<int> GetNums() // вернуть массив
        {
            return _arr;
        }
    }
}
