namespace Phonebook.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    internal class PhoneBook : IPhonebookRepository
    {
        public List<PhoneEntry> phoneEntries = new List<PhoneEntry>();

        public bool AddPhone(string personName, IEnumerable<string> phoneNumbers)
        {
            var oldPhoneEntry = from entry in this.phoneEntries
                                where entry.PersonName.ToLowerInvariant() == personName.ToLowerInvariant()
                                select entry;

            bool isFirstEntryForPerson;
            if (oldPhoneEntry.Count() == 0)
            {
                PhoneEntry newPhoneEntry = new PhoneEntry();
                newPhoneEntry.PersonName = personName;
                newPhoneEntry.PhoneNumbers = new SortedSet<string>();

                foreach (var number in phoneNumbers)
                {
                    newPhoneEntry.PhoneNumbers.Add(number);
                }
                this.phoneEntries.Add(newPhoneEntry);
                isFirstEntryForPerson = true;
            }
            else if (oldPhoneEntry.Count() == 1)
            {
                PhoneEntry newPhoneEntry = oldPhoneEntry.First();
                foreach (var num in phoneNumbers)
                {
                    newPhoneEntry.PhoneNumbers.Add(num);
                }

                isFirstEntryForPerson = false;
            }
            else
            {
                Console.WriteLine("Duplicated name in the phonebook found: " + personName);
                return false;
            }

            return isFirstEntryForPerson;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var list = from e in this.phoneEntries
                       where e.PhoneNumbers.Contains(oldent)
                       select e;

            int nums = 0;
            foreach (var entry in list)
            {
                entry.PhoneNumbers.Remove(oldent); entry.PhoneNumbers.Add(newent);
                nums++;
            }

            return nums;
        }

        public PhoneEntry[] ListEntries(int start, int num)
        {
            if (start < 0 || start + num > this.phoneEntries.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            this.phoneEntries.Sort();
            PhoneEntry[] ent = new PhoneEntry[num];

            for (int i = start; i <= start + num - 1; i++)
            {
                PhoneEntry entry = this.phoneEntries[i];
                ent[i - start] = entry;
            }

            return ent;
        }
    }
}