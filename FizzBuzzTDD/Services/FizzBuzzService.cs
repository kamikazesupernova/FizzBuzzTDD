using System;
using System.Collections.Generic;
using FizzBuzzTDD.Interfaces;

namespace FizzBuzzTDD.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        public List<string> GenerateFizzBuzz(int start, int end)
        {
            if (start > end)
                throw new ArgumentException("Start value cannot be greater than end value.");

            var result = new List<string>();

            for (int i = start; i <= end; i++)
            {
                string output = "";

                if (i % 3 == 0)
                    output += "Fizz";

                if (i % 5 == 0)
                    output += "Buzz";

                if (string.IsNullOrEmpty(output))
                    output = i.ToString();

                result.Add(output);
            }

            return result;
        }

    }

}
