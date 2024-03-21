using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace ConversationAsset
{
    [RequireComponent(typeof(Button))]
    public class SelectionButton : MonoBehaviour
    {   
        private Button button;
        [SerializeField]
        private TextMeshProUGUI text;
        private Selection.SelectionUnit curUnit;

        private void Awake()
        {
            button = GetComponent<Button>();
            SetEvent();
        }

        private void SetEvent()
        {
            button.onClick.AddListener(() =>
            {
                EntranceManager.Instance.SceneTransitionInteractable.IsOpen = curUnit.isOpen;
                ConversationManager.Instance.SelectionController.OffSelection();
                if(curUnit.conversation != null)
                    ConversationManager.Instance.ConversationController.Set(curUnit.conversation);
            });
        }

        public void Set(Selection.SelectionUnit unit)
        {
            curUnit = unit;
            text.text = unit.name;
        }
    }
}
