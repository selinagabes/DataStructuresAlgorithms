using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InformationMask
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> inputList = new List<string>();
            string input;
            do
            {
                input = Console.ReadLine();
                if(input != string.Empty) inputList.Add(input);
            } while (input != string.Empty);
            List<string> outputList = new List<string>();
            foreach(string s in inputList)
            {
                switch (s.ElementAt(0))
                {
                    case 'E':
                        string[] splitEmail = s.Split(':');

                        StringBuilder outputEmail = new StringBuilder(splitEmail[0] + ": ");
                        if (IsValidEmail(splitEmail[1].Trim()))
                        {
                            outputEmail.Append(MaskEmail(splitEmail[1].Trim()));
                            outputList.Add(outputEmail.ToString());
                        }
                        break;
                    case 'P':
                        string[] splitPhone = s.Split(':');
                        StringBuilder outputPhone = new StringBuilder(splitPhone[0] + ": ");
                        if (IsValidPhone(splitPhone[1]))
                        {
                            outputPhone.Append((MaskPhone(splitPhone[1].Trim())).ToString());
                            outputList.Add(outputPhone.ToString());
                        }
                        break;
                    default:
                        Console.WriteLine("Invaid Input");
                        break;

                }
            }
           foreach(var s in outputList)
            {
                Console.WriteLine(s);
            }
          
        }



        private static bool IsValidEmail(string email)
        {
            Regex emailReg = new Regex("([\\w\\d\\u0021(\\u0023-\\u0027)\\u002A\\u002B\\u002D\\u002F\\u003D\\u003F\\u005E\\u005F(\\u007B-\\u007E)\\u0060]+(\\u002E){0,1}[\\w\\d\\u0021(\\u0023-\\u0027)\\u002A\\u002B\\u002D\\u002F\\u003D\\u003F\\u005E\\u005F(\\u007B-\\u007E)\\u0060]+)\\u0040[\\w\\d]+\\u002E[\\w\\d]+");

            return emailReg.IsMatch(email);
        }

        private static bool IsValidPhone(string phone)
        {
            Regex phoneReg = new Regex("(\\u002B\\d{1,3} *[-,]?)?\\(?\\d{3}\\)?[-,]? *\\d{3}[-,]? *[-,]?\\d{4}");

            return phoneReg.IsMatch(phone);
        }

        private static string MaskEmail(string email)
        {

            string[] splitEmail = email.Split('@');
            string userName = splitEmail[0];
            StringBuilder result = new StringBuilder(userName.ElementAt(0) + "*****" + userName.ElementAt(userName.Length - 1) + '@' + splitEmail[1]);
            // string result = ;
            return result.ToString();
        }

        private static string MaskPhone(string phone)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder temp = new StringBuilder();
            char[] delims = { ' ', '-', ',', ')', '(','+' };
            string[] splitPhone = phone.Split(delims);
            //removes all delimiters
            foreach(var s in splitPhone)
            {
                temp.Append(s);
            }
            char[] backwardsPhone = temp.ToString().Reverse().ToArray();
            int phoneIterator;
            for(phoneIterator = 0; phoneIterator < 4; phoneIterator++)
            {
                result.Append(backwardsPhone[phoneIterator].ToString());
            }
            result.Append('-');

            while (phoneIterator < backwardsPhone.Count())
            {
                result.Append("*");
                if (phoneIterator == 6 || (phoneIterator == 9 && backwardsPhone.Count()> 10)) result.Append("-");
                ++phoneIterator;
            }
            if (phoneIterator > 10)
                result.Append("+");
            var backMaskedPhone = result.ToString();
            var maskedPhone = backMaskedPhone.Reverse().ToArray();
            result = new StringBuilder();
            foreach (char c in maskedPhone)
                result.Append(c);

            return result.ToString();
        }
    }
}
