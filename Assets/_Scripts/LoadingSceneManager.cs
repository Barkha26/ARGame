using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    #region Variable_Declaration
    public GameObject loadingPanel;
    public Image loadingBar;
    public Text textPercentage;
    #endregion

    /*public void LoadMapScene()
    {
        LoadScene("1");
    }*/
    #region LoadScene
    /// <summary>
    /// This method is used to load a scene and it waits until the scene is load successfully.
    /// </summary>
    /// <param name="sceneIndexNum"></param>
    public void LoadScene(string sceneIndexNum)
    {
        StartCoroutine(LoadYourAsyncScene(sceneIndexNum));
    }

    IEnumerator LoadYourAsyncScene(string sceneIndexNum)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex.

        loadingPanel.SetActive(true);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndexNum);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            loadingBar.fillAmount = asyncLoad.progress / 0.9f; //Async progress returns always 0 here 
            textPercentage.text = (loadingBar.fillAmount * 100f).ToString("F0") + "%"; //I have always 0% because he fillAmount is always 0
            Debug.Log("Progress :- ");
            yield return null;
        }
    }
    #endregion
}
