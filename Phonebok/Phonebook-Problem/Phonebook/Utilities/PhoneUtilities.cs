namespace Phonebook.Utilities
{
    using System.Text;

    public static class PhoneUtilities
    {
        public static string ConvertPhone(string num)
        {
            StringBuilder newPhoneNumber = new StringBuilder();

            newPhoneNumber.Clear();
            foreach (char ch in num)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    newPhoneNumber.Append(ch);
                }
            }

            if (newPhoneNumber.Length >= 2 && newPhoneNumber[0] == '0' && newPhoneNumber[1] == '0')
            {
                newPhoneNumber.Remove(0, 1);
                newPhoneNumber[0] = '+';
            }
            while (newPhoneNumber.Length > 0 && newPhoneNumber[0] == '0')
            {
                newPhoneNumber.Remove(0, 1);
            }

            if (newPhoneNumber.Length > 0 && newPhoneNumber[0] != '+')
            {
                newPhoneNumber.Insert(0, Constants.CountryPhoneCode);
            }

            newPhoneNumber.Clear();
            foreach (char ch in num)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    newPhoneNumber.Append(ch);
                }
            }

            if (newPhoneNumber.Length >= 2 && newPhoneNumber[0] == '0' && newPhoneNumber[1] == '0')
            {
                newPhoneNumber.Remove(0, 1); newPhoneNumber[0] = '+';
            }

            while (newPhoneNumber.Length > 0 && newPhoneNumber[0] == '0')
            {
                newPhoneNumber.Remove(0, 1);
            }

            if (newPhoneNumber.Length > 0 && newPhoneNumber[0] != '+')
            {
                newPhoneNumber.Insert(0, Constants.CountryPhoneCode);
            }

            newPhoneNumber.Clear();
            foreach (char ch in num)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    newPhoneNumber.Append(ch);
                }
            }

            if (newPhoneNumber.Length >= 2 && newPhoneNumber[0] == '0' && newPhoneNumber[1] == '0')
            {
                newPhoneNumber.Remove(0, 1); newPhoneNumber[0] = '+';
            }

            while (newPhoneNumber.Length > 0 && newPhoneNumber[0] == '0')
            {
                newPhoneNumber.Remove(0, 1);
            }

            if (newPhoneNumber.Length > 0 && newPhoneNumber[0] != '+')
            {
                newPhoneNumber.Insert(0, Constants.CountryPhoneCode);
            }


            return newPhoneNumber.ToString();
        }
    }
}