namespace Inventory
{
    internal interface IItemContainer {
        bool AddItem(ItemScriptableObject item, int quantity);
        bool RemoveItem(ItemScriptableObject item, int quantity);
        void Swap(int indexOne, int indexTwo);
        bool HasItem(ItemScriptableObject item);
    }
}
