using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public enum GameStates
    {
        PLAYING = 0,
        LOADING_LEVEL,
        PAUSED,
        SWITCHING_FACE,
        WIN,
        GAME_OVER,
        NUM_OF_STATES
    }

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject playerLight;
    [SerializeField] private bool resetLights;

    [SerializeField] private TextMeshPro levelTitle;
    [SerializeField] private TextMeshPro levelDetails;
    [SerializeField] private TextMeshPro levelFeedback;

    private static GameManager instance;

    private GameObject player;
    private GameStates gameState = GameStates.PLAYING;
    private bool loadingLevel = false;

    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<GameManager>();
            return instance;
        }
    }

    public GameStates GameState { get => gameState; }
    public bool LoadingLevel { get => loadingLevel; set => loadingLevel = value; }

    private void Awake()
    {
        SceneManager.AddLevel("Menu", "Menu", "Navigate to the levels before the light runs out\n\nMove: Left stick\nJump: South Button\nLoad Level: South Button", "", 10);
        SceneManager.AddLevel("Arrow Game", "ArrowGame", "Don't let the battery run out. Copy the arrows on the Left Stick. Red arrows should be reversed", "", 5);
        SceneManager.AddLevel("James", "ArrowGame", "Level 2 Text", "", 10);
        //SceneManager.AddLevel("Level 3", "ArrowGame", "Level 3 Text", "", 12);
        SceneManager.AddLevel("Haywire Protocol", "Jonathon's Scene", "Your Robot buddy is low on power and must be manually controlled, Instruct the robot to do actions", "", 13);
        SceneManager.AddLevel("Sockets", "RossScene", "Maintain all sockets connected, don't let the power drain!\n\nLeft stick: Move Wire Gun\nA: Fire Laser to connect pair of sockets.", "", 7);
        SceneManager.AddLevel("Core Collector", "GameScene", "Core Collector", "", 8.5f);
        SceneManager.AddLevel("Hack'N'Slasher", "HackNSlasher", "Hit enemies x3 to restore energy. Block bullets by charging at them.\n\nAttack / Dash: X or B", "", 12);
        SceneManager.AddLevel("Final Level", "BossLevel", "Match the falling blocks with the coloured columns\n\n Hold left stick to move platform, A to switch blocks", "", 4);


        SceneManager.LevelsSet = true;
        SceneManager.LevelLoading = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        LightFader playerLightFader;


        CubeController.Instance.SetCubeToLevel(SceneManager.PreviousLevel);

        player = SpawnPlayer();


        playerLightFader = player.GetComponentInChildren<LightFader>();

        if (playerLightFader != null)
        {
            LightingController.Instance.AddLight(playerLightFader);
        }

        LightingController.Instance.SetLightsToReduce(SceneManager.GetLevelInfo(CubeController.Instance.CurrentFaceLevel).cubeFaceDuration);

        LevelInfo level = SceneManager.GetLevelInfo(SceneManager.Levels.MENU);

        UpdateInfo(level.name, level.menuDisplayInfo, level.menuAchievementInfo);



    }

    private void firstFrame()
    {
        
    }

    private GameObject SpawnPlayer()
    {
        GameObject spawnedPlayer;
        if (SceneManager.PreviousLevel != SceneManager.Levels.MENU)
        {
            spawnedPlayer = Instantiate(playerPrefab, CubeController.Instance.GetReEntrySpawnPoint());
        }
        else
        {
            spawnedPlayer = Instantiate(playerPrefab, CubeController.Instance.GetSpawnPoint());
        }
        //spawnedPlayer.transform.parent = null;
        return spawnedPlayer;
    }

    public void UpdateInfo(string levelName, string levelDetails, string levelFeedback)
    {
        if (this.levelTitle != null) this.levelTitle.text = levelName;
        if (this.levelDetails != null) this.levelDetails.text = levelDetails;
        if (this.levelFeedback != null) this.levelFeedback.text = levelFeedback;
    }

    public void UpdateInfo(LevelInfo levelInfo)
    {
        if (this.levelTitle != null) this.levelTitle.text = levelInfo.name;
        if (this.levelDetails != null) this.levelDetails.text = levelInfo.menuDisplayInfo;
        if (this.levelFeedback != null) this.levelFeedback.text = levelInfo.menuAchievementInfo;
    }

    public void NextFace()
    {
        if (gameState == GameStates.SWITCHING_FACE) return;
        gameState = GameStates.SWITCHING_FACE;
        LightingController.Instance.SetLightsToIncrease(CubeController.Instance.RotationLerpDuration/2);
        //player.SetActive(false);
        player.GetComponent<Renderer>().enabled = false;
        CubeController.Instance.RotateNext();
    }

    public void Restart()
    {
        //gameState = GameStates.GAME_OVER;
        LightingController.Instance.ResetLights();
        levelFeedback.text = SceneManager.GetLevelInfo(CubeController.Instance.CurrentFaceLevel).menuAchievementInfo;
        //player.SetActive(false);
        player.GetComponent<Renderer>().enabled = false;
    }

    public void ForcedGameOver()
    {
        LightingController.Instance.SetLightsOff();
        gameState = GameStates.GAME_OVER;
        levelFeedback.text = "Press South Button\nTo Restart";
    }

    //private bool firstFrameRun = false;
    // Update is called once per frame
    void Update()
    {
        //if(!firstFrameRun)
        //{
        //    firstFrame();
        //    firstFrameRun = true;
        //}
        //if(resetLights)
        //{
        //    LightingController.Instance.ResetLights();
        //    LightingController.Instance.SetLightsToReduce(SceneManager.GetLevelInfo(CubeController.Instance.CurrentFaceLevel).cubeFaceDuration);
        //    resetLights = false;
        //}

        playerLight.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, playerLight.transform.position.z);

        switch (gameState)
        {
            case GameStates.PLAYING:
                if (LightingController.Instance.CurrentLightingState == LightingController.LightingState.LIGHTS_OFF)
                {
                    gameState = GameStates.GAME_OVER;
                    levelFeedback.text = "Press South Button\nTo Restart";
                }
                else
                {
                    if (loadingLevel) gameState = GameStates.LOADING_LEVEL;
                }
                break;
            case GameStates.PAUSED:
                break;
            case GameStates.SWITCHING_FACE:
                //player.transform.rotation = CubeController.Instance.gameObject.transform.rotation;
                if(CubeController.Instance.CubeState == CubeController.CubeStates.STATIC)
                {
                    player.transform.position = CubeController.Instance.GetSpawnPoint().position;

                    //player.SetActive(true);
                    //player.GetComponent<Renderer>().enabled = true;
                    Destroy(player);
                    player = Instantiate(playerPrefab, CubeController.Instance.GetSpawnPoint());
                    LightingController.Instance.SetLightsToReduce(SceneManager.GetLevelInfo(CubeController.Instance.CurrentFaceLevel).cubeFaceDuration);
                    gameState = GameStates.PLAYING;
                }
                break;
            case GameStates.WIN:
                break;
            case GameStates.GAME_OVER:
                if(LightingController.Instance.CurrentLightingState == LightingController.LightingState.LIGHTS_ON)
                {
                    Destroy(player);
                    player = Instantiate(playerPrefab, CubeController.Instance.GetSpawnPoint());
                    LightingController.Instance.SetLightsToReduce(SceneManager.GetLevelInfo(CubeController.Instance.CurrentFaceLevel).cubeFaceDuration);
                    gameState = GameStates.PLAYING;
                }
                break;
            case GameStates.LOADING_LEVEL:
                break;
            case GameStates.NUM_OF_STATES:
            default:
                break;
        }
    }



}
