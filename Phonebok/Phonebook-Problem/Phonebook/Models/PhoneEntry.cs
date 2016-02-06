namespace Phonebook.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhoneEntry : IComparable<PhoneEntry>
    {
        private string personName;
        private string personNameLowerCase;

        public SortedSet<string> PhoneNumbers;

        public string PersonName
        {
            get
            {
                return this.personName;
            }

            set
            {
                this.personName = value;

                this.personNameLowerCase = value.ToLowerInvariant();
            }
        }

        public int CompareTo(PhoneEntry other)
        {
            return this.personNameLowerCase.CompareTo(other.personNameLowerCase);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Clear();
            result.Append('[');
            result.Append(this.PersonName);

            bool hasNotAppendedName = true;
            foreach (var phone in this.PhoneNumbers)
            {
                if (hasNotAppendedName)
                {
                    result.Append(": ");
                    hasNotAppendedName = false;
                }
                else
                {
                    result.Append(", ");
                }

                result.Append(phone);
            }

            result.Append(']');
            return result.ToString();
        }
    }
}