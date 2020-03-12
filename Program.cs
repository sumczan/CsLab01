using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// wszystkie pliki wynikowe i przykladowy .csv znajduja sie w folderze bin 


namespace CSLab01
{
    class Program
    {
        static void Main(string[] args)
        {
            HTMLGenerator h1 = new HTMLGenerator(2, 2, "dziala", "heder", "futer", "pierwszy");
            HTMLGenerator h2 = new HTMLGenerator(2, 5, "99", "naglowek", "stopka", "drugi");
            HTMLGenerator h3 = new HTMLGenerator(2, 3, "dlugi tekst dkfjkdjfkjdkj kdjfkj kdjkf jkdjfjdkfjkdjfkdjkfjkdjfkdjkfjkdjfkdjkfj kjkjkdf jkdjfk jk jkdjf", "naglowek", "futer", "trzeci");
            HTMLGenerator h4 = new HTMLGenerator(0, 0, null, null, null, "czwarty");

            h1.Generate();
            h2.Generate();
            h3.Generate();
            h4.GenerateFromCSV();
        }
    }
}
