using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Dialogue.Models
{
    public class DialogueNode
    {
        public int ID;          // format: {parentDialogueEvent.ID}00
        public string Text = null;                  // break if dialogue if null
        public string Speaker = null;
        public Image Image = null;
        public Image Model = null;
        public List<DialogueNode> Children = null;      // continue parent if null
        public int ChildEvent = -1;
        public int RequiredQuest = -1;                  // Locked or ignored if Quest not -1 and not completed
    }
}