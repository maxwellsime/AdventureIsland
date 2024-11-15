using System.Text;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
    public class ItemScriptableObject : ScriptableObject
    {
        public int id;
        public Sprite icon;
        public string description;
        public int value;
        public int quantity; 
        public string itemName;
        
        public string GetDisplayText()
        {
            StringBuilder builder = new();

            builder.Append(itemName).AppendLine();
            builder.Append(description).AppendLine();
            builder.Append(value).AppendLine();

            return builder.ToString();
        }
    }
}
