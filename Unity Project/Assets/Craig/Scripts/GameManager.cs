using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public enum GameStates
    {
        PLAYING = 0,
        PAUSED,
        SWITCHING_FACE,
        WIN,
        GAME_OVER,
        NUM_OF_STATES
    }

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private bool resetLights;

    [SerializeField] private TextMeshPro levelTitle;
    [SerializeField] private TextMeshPro levelDetails;
    [SerializeField] private TextMeshPro levelFeedback;

    private static GameManager instance;

    private GameObject player;
    private GameStates gameState = GameStates.PLAYING;

    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<GameManager>();
            return instance;
        }
    }

    public GameStates GameState { get => gameState; }

    // Start is called before the first frame update
    void Start()
    {
        LightFader playerLightFader;

        SceneManager.AddLevel("Menu", "Menu", "Navigate to the levels before the light runs out\n\nMove: Left stick\nJump: South Button\nLoad Level: South Button", "",10);
        SceneManager.AddLevel("Arrow Game", "ArrowGame", "Don't let the battery run out. Copy the arrows on the Left Stick. Red arrows should be reversed", "", 5);


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

    // Update is called once per frame
    void Update()
    {
        if(resetLights)
        {
            LightingController.Instance.ResetLights();
            LightingController.Instance.SetLightsToReduce(SceneManager.GetLevelInfo(CubeController.Instance.CurrentFaceLevel).cubeFaceDuration);
            resetLights = false;
        }

        switch (gameState)
        {
            case GameStates.PLAYING:
                if(LightingController.Instance.CurrentLightingState == LightingController.LightingState.LIGHTS_OFF)
                {
                    gameState = GameStates.GAME_OVER;
                    levelFeedback.text = "Press South Button\nTo Restart";
                }
                break;
            case GameStates.PAUSED:
                break;
            case GameStates.SWITCHING_FACE:
                break;
            case GameStates.WIN:
                break;
            case GameStates.GAME_OVER:
                break;
            case GameStates.NUM_OF_STATES:
            default:
                break;
        }
    }



}
