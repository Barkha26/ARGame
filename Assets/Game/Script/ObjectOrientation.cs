using Assets._Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;
//using Assets._Scripts;

public class ObjectOrientation : MonoBehaviour
{
    //public List<Transform> EnvironmentalObjects;
    public Slider RotationSlider;
    public Slider ScalingSlider, heightOffsetSlider;
    public GameObject GameUI, retryBtn, goBackToMap;
    private Dictionary<Transform, Vector3> EnvironmentObjectScales;
    public Transform EnvironmentObject;
    public LoadingSceneManager loadingSceneManagerInstance;
    public GameManager gameManagerInstance;

    private float environmentObjScale;
    private float yVal;
    //only for testing levels
    public bool flagForLevelSlected = false;
   

    private void Start()
    {

        //store intial scales for each enviroment object 
        /*EnvironmentObjectScales = new Dictionary<Transform, Vector3>();
        foreach (Transform element in EnvironmentalObjects)
        {
            EnvironmentObjectScales.Add(element,element.localScale);
        }*/
        environmentObjScale = EnvironmentObject.localScale.x;
        yVal = GameManager.Instance.gameAssetHeightOffset.transform.localPosition.y;
    }

    public void OnRotate()
    {
        //foreach
        float rotationAmount = RotationSlider.value;
        /*foreach (Transform element in EnvironmentalObjects) {
            element.rotation = Quaternion.Euler(element.rotation.eulerAngles.x, rotationAmount, element.rotation.eulerAngles.z);
        }*/
        EnvironmentObject.rotation = Quaternion.Euler(EnvironmentObject.rotation.eulerAngles.x, rotationAmount, EnvironmentObject.rotation.eulerAngles.z);
    }

    public void OnScale()
    {
        /*float scaleAmount = ScalingSlider.value;

        foreach (KeyValuePair<Transform, Vector3> keyValuePair in EnvironmentObjectScales)
        {
            keyValuePair.Key.localScale = keyValuePair.Value * scaleAmount;
        }*/

        EnvironmentObject.localScale = new Vector3(ScalingSlider.value, ScalingSlider.value, ScalingSlider.value);
        GameManager.Instance.Player.GetComponent<PlayerController>().scaleConstants = ScalingSlider.value;
    }

    #region Change Game Asset Height dynamically
    public void OnValueChangedFromSlider()
    {
        float offset = heightOffsetSlider.value;
        GameObject gb = GameManager.Instance.gameAssetHeightOffset;
        gb.transform.localPosition = new Vector3(gb.transform.localPosition.x, yVal + offset, gb.transform.localPosition.z);
    }
    #endregion


    public void OnStartClick()
    {
        gameObject.SetActive(false);
        //GameUI.SetActive(true);
        //GameManager.GameStarted = true;     
        GameManager.Instance.gameState = GameManager.GameStates.START;
    }

    public void OnRestartClick()
    {
        //reload scene
        loadingSceneManagerInstance.LoadScene(ConstantVariableManager.SCENE_NAME_INDEX_4);
        //SceneManager.LoadScene("MainGame");
    }

    public void OnResetClick() {
        //NativeBridge.instance.loadedAfterPause = true;
        OnRestartClick();
    }

    public void OnGameOver()
    {
        Debug.Log("Unity: ObjectOrient: OnGameOver");
        // NativeBridge.instance.loadedAfterGame = true;
        // DigitalEyewearARController.Instance.SetViewerActive(true, true);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("SampleScene");
        //loadingSceneManagerInstance.LoadScene("MainGame");
        //TrackerManager.Instance.GetStateManager().ReassociateTrackables();
        //NativeBridge.instance.ResetiOSTab();
    }

    #region Testing
    //only for testing difficulty-levels
    public TMP_InputField MSpeed_Level_0;
    public TMP_InputField PSpeed_Level_0;
    public TMP_InputField WSpeed_Level_0;

    public TMP_InputField MSpeed_Level_1;
    public TMP_InputField PSpeed_Level_1;
    public TMP_InputField WSpeed_Level_1;

    public TMP_InputField MSpeed_Level_2;
    public TMP_InputField PSpeed_Level_2;
    public TMP_InputField WSpeed_Level_2;

    public void OnMSpeed_Level_0()
    {
        GameManager.Instance.difficultyLevels[0].MountainSpeed = float.Parse(MSpeed_Level_0.text);
    }
    public void OnPSpeed_Level_0()
    {
        GameManager.Instance.difficultyLevels[0].PlayerSpeed = float.Parse(PSpeed_Level_0.text);
    }
    public void OnWSpeed_Level_0()
    {
        GameManager.Instance.difficultyLevels[0].WaterSpeed = float.Parse(WSpeed_Level_0.text);
    }

    public void OnMSpeed_Level_1()
    {
        GameManager.Instance.difficultyLevels[1].MountainSpeed = float.Parse(MSpeed_Level_1.text);
    }
    public void OnPSpeed_Level_1()
    {
        GameManager.Instance.difficultyLevels[1].PlayerSpeed = float.Parse(PSpeed_Level_1.text);
    }
    public void OnWSpeed_Level_1()
    {
        GameManager.Instance.difficultyLevels[1].WaterSpeed = float.Parse(WSpeed_Level_1.text);
    }

    public void OnMSpeed_Level_2()
    {
        GameManager.Instance.difficultyLevels[2].MountainSpeed = float.Parse(MSpeed_Level_2.text);
    }
    public void OnPSpeed_Level_2()
    {
        GameManager.Instance.difficultyLevels[2].PlayerSpeed = float.Parse(PSpeed_Level_2.text);
    }
    public void OnWSpeed_Level_2()
    {
        GameManager.Instance.difficultyLevels[2].WaterSpeed = float.Parse(WSpeed_Level_2.text);
    }

    public void OnLevel_0Click()
    {
        flagForLevelSlected = true;
        GameManager.Instance.currentLevel = 0;
    }
    public void OnLevel_1Click()
    {
        flagForLevelSlected = true;
        GameManager.Instance.currentLevel = 1;
    }
    public void OnLevel_2Click()
    {
        flagForLevelSlected = true;
        GameManager.Instance.currentLevel = 2;
    }
    #endregion
}
