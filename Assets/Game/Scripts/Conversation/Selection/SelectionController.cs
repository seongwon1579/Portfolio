
using UnityEngine;
using TMPro;

namespace ConversationAsset
{
    public class SelectionController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI description;

        [SerializeField]
        private GameObject selectionUI;

        [SerializeField]
        private SelectionButton selectionButton;

        [SerializeField]
        private Transform parent_SelectionButton;

        private Selection curSelection;

        public bool isSelection = false;

        // 대화에셋에서 선택지가 있을 때 호출, 초기화 목적 
        public void Set(Selection selection)
        {
            curSelection = selection;
            isSelection = true;
            OnSelection();
        }

        // UI를 띄우고 버튼 생성 준비 
        private void OnSelection()
        {   
            selectionUI.SetActive(true);
            description.text = curSelection.description;
            SetButton();
        }

        // 선택이 끝나고 (선택지 에셋에 대화 내용이 있으면 대화 내용까지 끝나면) UI 비활성화 
        public void OffSelection()
        {
            isSelection = false;
            selectionUI.SetActive(false);           
        }

        private void SetButton()
        {
            foreach (Transform child in parent_SelectionButton)
                Destroy(child.gameObject);

            for(int i = 0; i < curSelection.SelectionUnits.Length; i++)         
                Instantiate(selectionButton, parent_SelectionButton).Set(curSelection.SelectionUnits[i]);
        }
    }
}
