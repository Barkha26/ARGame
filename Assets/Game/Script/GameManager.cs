using Assets._Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    // public float xMin, xMax, yMin, yMax;
    public enum GameStates { START, STOP, WIN, LOOSE, PAUSE, RESUME };
    public GameStates gameState;

    public Transform GameOverPopUp;
    public TextMeshProUGUI GameStatus;

    //difficulty Level
    public int currentLevel;

    public List<DifficultyLevel> difficultyLevels;
    public Transform MountainParent;
    public ObjectOrientation objectOrientationInstance;
    public GameObject tapToStartBtn;

    public GameObject swipeUp, swipeDown;

    [HideInInspector]
    public float MountainSpeed;
    [HideInInspector]
    public float PlayerSpeed;
    [HideInInspector]
    public float WaterSpeed;

    public GameObject Player;
   [HideInInspector] 
    public GameObject Mountain;

    public GameObject WinParticlePrefab;
    public GameObject gameAssetHeightOffset;
    [HideInInspector]
    public IEnumerator playWinParticleCor, retryMethod = null;
    public GameObject ARGame;
    //variables to define difficulty levels
    //mountain,player,water movement
    //number of obstacles on path
    //gap between each obstacles {on/off few obstacles}


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
       

        // Application.targetFrameRate = 60;
        if (!PlayerPrefs.HasKey(ConstantVariableManager.TUTORIAL))
        {
            PlayerPrefs.SetInt(ConstantVariableManager.TUTORIAL, 0);
        }
        else
        {
            PlayerPrefs.SetInt(ConstantVariableManager.TUTORIAL, 1);
        }
    }

    public GameObject ObjectOrientation;
    IEnumerator Start()
    {
        gameState = GameStates.STOP;//make it stop and gameUI off in inspector

        ObjectOrientation.transform.parent.GetComponent<ObjectOrientation>().flagForLevelSlected = true; //comment this for level testing also activate "LevelTesting in heirarchy"
        //currentLevel = 0; //remove this after testing
       // Debug.Log("GameManagerTest: "+ NativeBridge.instance.Type);
        switch ("BRONZE")
        {
            case ConstantVariableManager.COIN_LEVEL_BRONZE:                 
                currentLevel = 0;
                //if (!NativeBridge.instance.loadedAfterPause) {
                //    if (NativeBridge.instance.currentGameAttemptsLeft <= 0)
                //    {
                //        NativeBridge.instance.currentGameAttemptsLeft = 1;
                //    }
                //    NativeBridge.instance.currentGameAttemptsLeft--;
                //}
                
                break;

            case ConstantVariableManager.COIN_LEVEL_SILVER:
                currentLevel = 1;

                //if (!NativeBridge.instance.loadedAfterPause) {
                //    if (NativeBridge.instance.currentGameAttemptsLeft <= 0)
                //    {
                //        NativeBridge.instance.currentGameAttemptsLeft = 2;
                //    }
                //    NativeBridge.instance.currentGameAttemptsLeft--;
                //}
                  
                break;

            case ConstantVariableManager.COIN_LEVEL_GOLD:
                currentLevel = 2;

                //if (!NativeBridge.instance.loadedAfterPause) {
                //    if (NativeBridge.instance.currentGameAttemptsLeft <= 0)
                //    {
                //        NativeBridge.instance.currentGameAttemptsLeft = 3;
                //    }
                //    NativeBridge.instance.currentGameAttemptsLeft--;
                //}
                    
                break;

            case ConstantVariableManager.COIN_LEVEL_ROSE:
                currentLevel = 2;

                //if (!NativeBridge.instance.loadedAfterPause) {
                //    if (NativeBridge.instance.currentGameAttemptsLeft <= 0)
                //    {
                //        NativeBridge.instance.currentGameAttemptsLeft = 3;
                //    }
                //    NativeBridge.instance.currentGameAttemptsLeft--;
                //}
                    
                break;

            case ConstantVariableManager.COIN_LEVEL_PLATINUM:
                currentLevel = 2;

                //if (!NativeBridge.instance.loadedAfterPause) {
                //    if (NativeBridge.instance.currentGameAttemptsLeft <= 0)
                //    {
                //        NativeBridge.instance.currentGameAttemptsLeft = 3;
                //    }
                //    NativeBridge.instance.currentGameAttemptsLeft--;
                //}
                    
                break;

            case ConstantVariableManager.COIN_LEVEL_DIAMOND:
                currentLevel = 2;

                //if (!NativeBridge.instance.loadedAfterPause)
                //{
                //    if (NativeBridge.instance.currentGameAttemptsLeft <= 0)
                //    {
                //        NativeBridge.instance.currentGameAttemptsLeft = 3;
                //    }
                //    NativeBridge.instance.currentGameAttemptsLeft--;
                //}
                   
                break;

            case ConstantVariableManager.COIN_LEVEL_CENTURION:
                currentLevel = 2;

                //if (!NativeBridge.instance.loadedAfterPause) {
                //    if (NativeBridge.instance.currentGameAttemptsLeft <= 0)
                //    {
                //        NativeBridge.instance.currentGameAttemptsLeft = 3;
                //    }
                //    NativeBridge.instance.currentGameAttemptsLeft--;
                //}
                    
                break;
         
            default:
                Debug.Log("Native brigde Type is not matched or null");
                break;
        }
        
        while (!ObjectOrientation.activeInHierarchy || ObjectOrientation.transform.parent.GetComponent<ObjectOrientation>().flagForLevelSlected == false)
        {
            yield return null;
        }

        //if (ObjectOrientation.activeInHierarchy) {
        //    Debug.Log("############WE");
        //    if (ObjectOrientation.transform.parent.GetComponent<ObjectOrientation>().flagForLevelSlected == true) {
        //        Debug.Log("############WE^^^^^^^^^");
        //    }
        //    Debug.Log("TESTTTT%%%%%%%%%%%%%%%%");
        //}

        Debug.Log("TESTTTT");
        //check for difficulty level and instantiate accordingly         
        //Mountain = Instantiate(difficultyLevels[currentLevel].Mountain, MountainParent);

        string resourcePath;
        switch (currentLevel) {
            case 0:
                resourcePath = "Game/Mountain_Level1_";
                break;
            case 1:
                resourcePath = "Game/Mountain_Level2_";
                break;
            case 2:
                resourcePath = "Game/Mountain_Level3_";
                break;
            case 3:
                resourcePath = "Game/Mountain_Level4";
                break;
            case 4:
                resourcePath = "Game/Mountain_Level5";
                break;
            case 5:
                resourcePath = "Game/Mountain_Level6";
                break;
            case 6:
                resourcePath = "Game/Mountain_Level7";
                break;
            case 7:
                resourcePath = "Game/Mountain_Level8";
                break;
            case 8:
                resourcePath = "Game/Mountain_Level9";
                break;
            case 9:
                resourcePath = "Game/Mountain_Level10";
                break;
            default:
                resourcePath = "Game/Mountain_Level1";
                break;
        }

        var unloader = Resources.UnloadUnusedAssets();
        while (!unloader.isDone)
        {
            yield return null;
        }

        GameObject instance = Instantiate(Resources.Load(resourcePath, typeof(GameObject))) as GameObject;        
        Mountain = instance;         
        Mountain.transform.SetParent(MountainParent);
        //Mountain.transform.position = Vector3.zero;
        Mountain.transform.localPosition = Vector3.zero;
        Mountain.transform.localRotation = Quaternion.identity;
        Mountain.transform.localScale = Vector3.one;
        

        /*string resourcePath;
        switch (currentLevel)
        {
            case 0:
                resourcePath = "Game/DynamicAssets_Level1";
                break;
            case 1:
                resourcePath = "Game/DynamicAssets_Level2";
                break;
            case 2:
                resourcePath = "Game/DynamicAssets_Level3";
                break;
            default:
                resourcePath = "Game/DynamicAssets_Level1";
                break;
        }

        var unloader = Resources.UnloadUnusedAssets();
        while (!unloader.isDone)
        {
            yield return null;
        }

        GameObject instance = Instantiate(Resources.Load(resourcePath, typeof(GameObject))) as GameObject;
        instance.transform.SetParent(Mountain.transform.GetChild(0));
        instance.transform.localPosition = Vector3.zero;
        instance.transform.localRotation = Quaternion.identity;
        instance.transform.localScale = Vector3.one;
        */

        MountainSpeed = difficultyLevels[currentLevel].MountainSpeed;
        PlayerSpeed = difficultyLevels[currentLevel].PlayerSpeed;
        WaterSpeed = difficultyLevels[currentLevel].WaterSpeed;

        objectOrientationInstance.retryBtn.SetActive(false);
        objectOrientationInstance.goBackToMap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        checkForGameState();

        //For testing only (remove this)
        /*if (Input.GetKeyDown(KeyCode.P)) {
            OnApplicationPause(true);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            OnApplicationPause(false);
        }*/
    }

    private void checkForGameState()
    {
        switch (gameState)
        {
            case GameStates.START:

                break;
            case GameStates.STOP:

                break;
            case GameStates.WIN:
                //run player win animation            

                //NativeBridge.instance.loadedAfterPause = false;

                //open gameover screen
                GameOverPopUp.gameObject.SetActive(true);
                // GameStatus.text = "You Win";
                GameOverPopUp.Find("Win").gameObject.SetActive(true);
                GameOverPopUp.Find("Loose").gameObject.SetActive(false);
                Debug.Log("6666");

                if (retryMethod == null)
                {
                    //NativeBridge.instance.isWin = true;
                   // NativeBridge.instance.GameStatusWin();
                    retryMethod = CallRetryFunc();
                    StartCoroutine(retryMethod);
                }

                break;
            case GameStates.LOOSE:
                //destroy player
                //   Destroy(Player);

                //NativeBridge.instance.loadedAfterPause = false;

                //open gameover screen
                GameOverPopUp.gameObject.SetActive(true);
                //GameStatus.text = "You Loose";
                GameOverPopUp.Find("Win").gameObject.SetActive(false);
                GameOverPopUp.Find("Loose").gameObject.SetActive(true);

                if (retryMethod == null)
                {
                    //NativeBridge.instance.isWin = false;
                  // NativeBridge.instance.GameStatusLose();
                    retryMethod = CallRetryFunc();
                    StartCoroutine(retryMethod);
                }
                break;
        }
    }

    IEnumerator CallRetryFunc()
    {
        yield return new WaitForSeconds(3f);

        //if (NativeBridge.instance.currentGameAttemptsLeft <= 0)
        //{
            objectOrientationInstance.OnGameOver();
        //}
        //else
        //{
        //    objectOrientationInstance.retryBtn.SetActive(true);
        //    objectOrientationInstance.goBackToMap.SetActive(true);
        //    // objectOrientationInstance.OnRestartClick();
        //}

       // objectOrientationInstance.Retry(NativeBridge.instance.Type);

    }

    //IEnumerator playWinParticle() {
    //    Debug.Log("INSWINNNNNNNNNNNNNN");
    //    //Instantiate particle effect at screen
    //    Transform _winParent = GameOverPopUp.Find("Win").Find("WinParticle");
    //    Vector3 particlePos = new Vector3(Random.Range(0f, 6f), Random.Range(0f, -9f), 0);
    //    GameObject winParticle = Instantiate(WinParticlePrefab, Vector3.zero, Quaternion.identity, _winParent);
    //    //winParticle.transform.localPosition = particlePos;

    //    yield return new WaitForSeconds(0.6f);
    //    Debug.Log("#######");
    //    playWinParticleCor = playWinParticle();
    //    StartCoroutine(playWinParticleCor);
    //}

    #region Check For Tutorial 
    /// <summary>
    /// if User had seen tutorial one time after installing the app , the tutorial will not be shown next time.
    /// </summary>
    public void CheckForTutorial()
    {
        //ObjectOrientation.gameObject.SetActive(false);
       // tapToStartBtn.gameObject.SetActive(true);
        
       if (PlayerPrefs.HasKey(ConstantVariableManager.TUTORIAL))
        {
            ObjectOrientation.gameObject.SetActive(false);
            if (PlayerPrefs.GetInt(ConstantVariableManager.TUTORIAL) == 0)
            {
                swipeUp.SetActive(true);
            }
            else
            {
                swipeUp.SetActive(false);
                swipeDown.SetActive(false);
                tapToStartBtn.gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.Log(ConstantVariableManager.WARNING_NO_KEY_FOUND);
        }
    }
    #endregion

    #region Application in background/foreground
    private void OnApplicationPause(bool pause)
    {
        Debug.Log("OnApplicationPause2: "+ pause);
        if (!pause) {
            //donot make the game to loose its attempts so put a check while loading(start)
            //put a check : if game is win/loose then pause then redirect to map scene.
            if (gameState == GameStates.WIN || gameState == GameStates.LOOSE)
            {
                objectOrientationInstance.OnGameOver();
            }
            else {
               //NativeBridge.instance.loadedAfterPause = true;
               objectOrientationInstance.OnRestartClick();
            }            
        }
    }
    #endregion
}
[System.Serializable]
public class DifficultyLevel
{
    public char LevelNumber;
    //public GameObject Mountain;
    public float MountainSpeed;
    public float PlayerSpeed;
    public float WaterSpeed;
}
