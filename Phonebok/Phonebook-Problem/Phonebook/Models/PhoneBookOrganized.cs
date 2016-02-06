namespace Phonebook.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Wintellect.PowerCollections;

    public class PhoneBookOrganized : IPhonebookRepository
    {
        private readonly Dictionary<string, PhoneEntry> phoneByPerson =
            new Dictionary<string, PhoneEntry>();

        private readonly MultiDictionary<string, PhoneEntry> phonesByPerson =
            new MultiDictionary<string, PhoneEntry>(false);

        private readonly OrderedSet<PhoneEntry> sorted =
            new OrderedSet<PhoneEntry>();

        public bool AddPhone(string personName, IEnumerable<string> phoneNumbers)
        {
            string name2 = personName.ToLowerInvariant();
            PhoneEntry newPhoneEntry;

            bool flag = !this.phoneByPerson.TryGetValue(name2, out newPhoneEntry);
            if (flag)
            {
                newPhoneEntry = new PhoneEntry();
                newPhoneEntry.PersonName = personName;
                newPhoneEntry.PhoneNumbers = new SortedSet<string>();
                this.phoneByPerson.Add(name2, newPhoneEntry);

                this.sorted.Add(newPhoneEntry);
            }

            newPhoneEntry.PhoneNumbers.UnionWith(phoneNumbers);
            return flag;
        }

        public int ChangePhone(string oldPhoneNumber, string newPhoneNumber)
        {
            var foundEntries = this.sorted.Where(p => p.PhoneNumbers.Contains(oldPhoneNumber)).ToList();
            foreach (var entry in foundEntries)
            {
                entry.PhoneNumbers.Remove(oldPhoneNumber);

                entry.PhoneNumbers.Add(newPhoneNumber);
            }

            return foundEntries.Count;
        }

        public PhoneEntry[] ListEntries(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex + count > this.phoneByPerson.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            PhoneEntry[] sortedPhoneEntries = new PhoneEntry[count];
            for (int i = startIndex; i <= startIndex + count - 1; i++)
            {
                PhoneEntry entry = this.sorted[i];
                sortedPhoneEntries[i - startIndex] = entry;
            }

            return sortedPhoneEntries;
        }
    }
}