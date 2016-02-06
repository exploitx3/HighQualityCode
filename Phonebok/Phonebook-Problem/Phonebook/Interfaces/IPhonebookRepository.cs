namespace Phonebook.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface IPhonebookRepository
    {
        bool AddPhone(string personName, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        PhoneEntry[] ListEntries(int startIndex, int count);
    }
}