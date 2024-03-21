using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConversationAsset
{
    [CreateAssetMenu(menuName = "ScriptableObject/Selection")]
    public class Selection : ScriptableObject
    {

        [System.Serializable]
        public class SelectionUnit
        {
            public string name;
            public Conversation conversation;
            public bool isOpen;
        }

        [SerializeField]
        private SelectionUnit[] selectionUnits;
        public SelectionUnit[] SelectionUnits { get { return selectionUnits; } }

        [SerializeField, TextArea(5, 5)]
        public string description;


    }
}
