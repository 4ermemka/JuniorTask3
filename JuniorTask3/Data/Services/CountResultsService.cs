using JuniorTask3.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace JuniorTask3.Data.Services
{
    public class CountResultsService : ICountResultsService // Сервис обработки массива
    {
        public IntList listToSort; // Созданный вручную список

        public void SetList(int[] arr) // Заполнение списка из массива
        {
            listToSort = new IntList();
            listToSort.FromArr(arr);
        }

        public int[] GetList()// Вернуть массив из списка
        {
            return listToSort.ToArr();
        }

        public IntList BubbleSort() // Сортировка списка пузырьком (по возрастанию)
        {
            for (int i = 0; i < listToSort.Count(); i++)
            {
                for (int j = i + 1; j < listToSort.Count(); j++)
                {
                    if (listToSort.GetValueById(i) > listToSort.GetValueById(j))
                    {
                        listToSort.Swap(listToSort.GetNodeById(i), listToSort.GetNodeById(j));
                    }
                }
            }
            return listToSort;
        }
    }
}
