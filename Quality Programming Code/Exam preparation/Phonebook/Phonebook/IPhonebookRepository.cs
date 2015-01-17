namespace Phonebook
{
    using System.Collections.Generic;

    /// <summary>
    /// This interface is used for listing, adding and changing phonebook entries
    /// It Contains: AddPhone and ChangePhone methods
    /// </summary>
    public interface IPhonebookRepository
    {
        /// <summary>
        /// This method adds a new phone to a contact
        /// </summary>
        /// <param name="name">The name of the contact</param>
        /// <param name="phoneNumbers">Collection of phone numbers to be added</param>
        /// <returns>Whether or not the name already exists</returns>
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        /// <summary>
        /// This method change old phone number with new phone number
        /// </summary>
        /// <param name="oldPhoneNumber">The old number to be changed</param>
        /// <param name="newPhoneNumber">The new number</param>
        /// <returns>Count of numbers changed</returns>
        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        /// <summary>
        /// Get list of contacts with count from startIndex 
        /// </summary>
        /// <param name="startIndex">Start index to get contacts</param>
        /// <param name="count">Count of contacts</param>
        /// <returns>Return all contacts from current index to count</returns>
        IEnumerable<PhonebookEntry> ListEntries(int startIndex, int count);
    }
}
