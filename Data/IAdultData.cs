using System.Collections.Generic;
using Assignment1.Models;

namespace Assignment1.Data
{
    public interface IAdultData
    {
        void AddAdults(Adult adult);
        IList<Adult> GetAdults();
        void RemoveAdult(int AdultId);
    }
}