using UnityEngine;
using ConversationAsset;


public class ConversationManager : Singleton<ConversationManager>
{
    [SerializeField]
    private ConversationController conversationController;
    public ConversationController ConversationController => conversationController;

    [SerializeField]
    private SelectionController selectionController;
    public SelectionController SelectionController => selectionController;
}

