using JuniorTask3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JuniorTask3.Data.Services
{
    public interface ICountResultsService
    {
        public void SetList(int[] arr);
        public int[] GetList();

        public IntList BubbleSort();
    }
}
