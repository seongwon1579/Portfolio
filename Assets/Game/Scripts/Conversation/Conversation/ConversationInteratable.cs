using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace ConversationAsset
{
    public class ConversationInteratable : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private Conversation conversation;
        public Conversation Conversation
        {
            get { return conversation; }
            set { conversation = value; }
        }

        [SerializeField]
        private EventsBundle eventsBundle;

        public void OffInteraction()
        {
            ConversationManager.Instance.ConversationController.OffConversation();
            ConversationManager.Instance.SelectionController.OffSelection();
        }

        public void OnInteraction()
        {
            if (ConversationManager.Instance.SelectionController.isSelection)
                return;

            eventsBundle?.actionArgBool(false);
            ConversationManager.Instance.ConversationController.Set(Conversation);
        }
    }
}
