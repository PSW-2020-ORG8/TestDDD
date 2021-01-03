using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Validation
{
    public class BasicValidation
    {
        public BasicValidation() { }

        public static bool CheckIfStringIsEmptyOrNull(string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidateString(string input, Regex reg)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    return false;
                }
                else if (!reg.Match(input).Success)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
