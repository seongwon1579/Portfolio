using UnityEngine;
using TMPro;
using UniRx;

namespace ConversationAsset
{
    public class ConversationController : MonoBehaviour
    {
        [Header("Conversation")]
        [SerializeField]
        private TextMeshProUGUI characterName;
        [SerializeField]
        private TextMeshProUGUI text;
        [SerializeField]
        private GameObject conversationUI;

        private ReactiveCommand<Conversation> selectionCommand;

        private int conversationIndex = 0;

        private Conversation curConversation;

        private void Awake()
        {
            selectionCommand = new ReactiveCommand<Conversation>();
            SetEvent();
        }

        private void SetEvent()
        {
            selectionCommand.Subscribe(conversation =>
            {
                if (conversation.Selection)
                    ConversationManager.Instance.SelectionController.Set(conversation.Selection);
            });           
        }

        public void Set(Conversation conversation)
        {                   
            if(curConversation == null)
                curConversation = conversation;

            OnConversation();
        }

        public void OnConversation()
        {
            conversationUI.SetActive(true);
            if (conversationIndex < curConversation.Talks.Length)
            {
                characterName.text = curConversation.Talks[conversationIndex].name;
                text.text = curConversation.Talks[conversationIndex].text;
                conversationIndex++;
            }
            else
            {
                selectionCommand.Execute(curConversation);
                OffConversation();               
            }
        }

        public void OffConversation()
        {
            curConversation = null;
            conversationUI.SetActive(false);
            conversationIndex = 0;
        }
    }
}
