using DataStructures.Tree.BSTree;
using ElectronicHealthCard.Models;
using System.Text;
using System;

namespace ElectronicHealthCard.Controllers
{
    public class GeneratorController
    {
        private readonly Random random = new Random();
        private string RandomString(int size)
        {
            var builder = new StringBuilder(size);

            char offset = 'a';
            const int lettersOffset = 26;

            for (var i = 0; i < size; i++)
            {
                var randomChar = (char)random.Next(offset, offset + lettersOffset);
                builder.Append(randomChar);
            }

            return builder.ToString();
        }
        public BSTree<Hospital> GenerateHospitals(int number)
        {
            var hospitals = new BSTree<Hospital>();
            for (var i = 0; i < number; i++)
            {
                var nameSize = random.Next(3, 20);
                var hospital = new Hospital(RandomString(nameSize));
                hospitals.Add(hospital);
            }
            return hospitals;
        }
    }
}
