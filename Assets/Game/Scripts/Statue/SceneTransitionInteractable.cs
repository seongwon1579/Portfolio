using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ConversationAsset
{
    public class SceneTransitionInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private GameObject descriptionPanel;

        [SerializeField]
        private EventsBundle eventsBundle;

        private bool isOpen = false;
        // 선택지에 선택된 bool값으로 초기화 
        public bool IsOpen
        {
            set
            {
                isOpen = value;
                eventsBundle.actionArgBool.Invoke(isOpen);
            }
        }

        public void OnInteraction()
        {
            if (isOpen)
                StartCoroutine(LoadSceneCo());
        }

        // 진입이 가능할 시 다음신 이동을 위한 로딩씬 매니저 호출
        IEnumerator LoadSceneCo()
        {
            descriptionPanel.SetActive(true);
            yield return new WaitForSeconds(5f);
            descriptionPanel.SetActive(false);
            LoadingSceneManager.Set("2nd");
        }

        public void OffInteraction()
        {
        }
    }  
}
