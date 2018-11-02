using System;
using RndomTests.Models;

namespace RndomTests
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Person xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><FirstName>Adetoro</FirstName><LastName>Thompson</LastName><Age>24</Age><UniqueID>ef72918d-db65-4d01-936a-419be4148c17</UniqueID></Person>";

            string j = "{\"Age\":24,\"FirstName\":\"Adetoro\",\"LastName\":\"Thompson\",\"UniqueID\":\"ef72918d-db65-4d01-936a-419be4148c17\"}";

            Person per = new Person
            {
                Age = 24,
                FirstName = "Adetoro",
                LastName = "Thompson",
                UniqueID = Guid.NewGuid()
            };

            Utility.SerializeString(per);

            Person px = Utility.DeserializeXML(x);
            Console.WriteLine($"{px.Age}, {px.FirstName}, {px.LastName}, {px.UniqueID}");

            Person pj = Utility.DeserializeJSON(j);
            Console.WriteLine($"{pj.Age}, {pj.FirstName}, {pj.LastName}, {pj.UniqueID}");

            Console.WriteLine("Done!");
        }
    }
}
