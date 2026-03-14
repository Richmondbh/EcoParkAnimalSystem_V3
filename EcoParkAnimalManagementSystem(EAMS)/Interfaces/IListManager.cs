using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoParkAnimalManagementSystem_EAMS_.Interfaces
{
    /// Generic interface for managing a collection of items of any type.
    /// Provides standard list operations including add, remove, modify, and retrieve.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list</typeparam>
    public interface IListManager<T>
    {
        // Gets the number of elements in the list.
        int Count { get; }

        // Adds an item to the end of the list.
        bool Add(T type);

        // Replaces an item at the specified index with a new item.
        bool ChangeAt(T type, int index);

        // Checks if the specified index is valid for the current list.
        bool CheckIndex(int index);

        // Removes all items from the list.
        void DeleteAll();

        // Removes the item at the specified index.
        bool DeleteAt(int index);

        // Retrieves the item at the specified index.
        T GetAt(int index);

        // Returns an array containing the ToString() representation of all items in the list.
        string[] ToStringArray();

        // Returns a list containing the ToString() representation of all items in the list.
        List<string> ToStringList();
    }
}
