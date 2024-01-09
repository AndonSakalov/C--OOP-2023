using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FoodShortage.Models.Interfaces
{
    public interface ICitizen : IPerson
    {
        string Id { get;}
        string BirthDate { get;}
    }
}
