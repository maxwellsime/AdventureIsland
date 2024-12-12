using Inventory.Models;

namespace Inventory.Services
{
    internal interface IItemContainerService {
        void AddItem(ItemScriptableObject item, int quantity);
        bool RemoveItem(ItemScriptableObject item, int quantity);
        void Swap(int indexOne, int indexTwo);
        bool HasItem(ItemScriptableObject item);
    }
}
