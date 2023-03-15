using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;

namespace JuniorTask3.Data.Services
{
    public interface IDisplayService
    {
        public void SetNums(IFormCollection fc);
        public IEnumerable<int> GetNums();
    }
}
