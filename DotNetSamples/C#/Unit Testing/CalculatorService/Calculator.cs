using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
    public class Calculator
    {
        private readonly CalculatorExtensions _extensions;

        public Calculator(CalculatorExtensions extensions)
        {
            _extensions = extensions;
        }

        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (!input.Contains(','))
            {
                throw new ArgumentException("Does not contain ','. wrong input format");
            }

            string[] splittedInput = input.Split(',');

            if (splittedInput.Count() > 2)
            {
                throw new ArgumentException("Does not meet format requirements");
            }

            int value1 = default!;
            int value2 = default!;

            if (!int.TryParse(splittedInput[0], out value1))
            {
                throw new FormatException("part one cannot be converted");
            }

            if (!int.TryParse(splittedInput[1], out value2))
            {
                throw new FormatException("part one cannot be converted");
            }
                        
            return value1 + value2 + _extensions.ExtraAdd;
        }
    }
}
