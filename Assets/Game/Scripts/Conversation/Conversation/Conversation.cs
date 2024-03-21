using UnityEngine;

namespace ConversationAsset
{
    [CreateAssetMenu (menuName = "ScriptableObject/Conversation")]
    public class Conversation : ScriptableObject
    {
        [System.Serializable]
        public class Talk
        {
            public string name;
            [TextArea(2,3)]
            public string text;
        }

        [SerializeField]
        private Talk[] talks;
        public Talk[] Talks { get { return talks; } }

        [SerializeField]
        private Selection selection;
        public Selection Selection { get { return selection; } }
    }
}
