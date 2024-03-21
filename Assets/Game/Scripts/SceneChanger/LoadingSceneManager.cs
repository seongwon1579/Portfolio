using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneManager : MonoBehaviour
{
    private static string curScene;

    public Image loadingBar;
   
    public static void Set(string scene)
    {
        curScene = scene;
        SceneManager.LoadScene("LoadingScene");     
    }

    private void Start()
    {
        StartCoroutine(SceneLoadAsyn());
    }
  
    private IEnumerator SceneLoadAsyn()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(curScene);
        async.allowSceneActivation = false;

        float fakeTime = 0f;

        while (!async.isDone)
        {
            yield return null;

            if (async.progress < 0.9f)
            {
                loadingBar.fillAmount = async.progress;
            }
            else
            {
                fakeTime += Time.unscaledDeltaTime;
                loadingBar.fillAmount = Mathf.Lerp(0.9f, 1, fakeTime);

                if (loadingBar.fillAmount >= 1f)
                {
                    async.allowSceneActivation = true;
                    break;
                }
            }
        }
    } 
}
