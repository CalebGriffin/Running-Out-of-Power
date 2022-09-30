
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class SceneManager
{
    public enum Levels : int
    {
        MENU = 0,
        LEVEL1,
        LEVEL2,
        LEVEL3,
        LEVEL4,
        LEVEL5,
        LEVEL6,
        LEVEL7,
        NUM_OF_LEVELS
    }

    private static List<LevelInfo> levels = new List<LevelInfo>();

    private static SceneManager.Levels currentLevel = Levels.MENU;
    private static SceneManager.Levels previousLevel = Levels.LEVEL6;
    private static bool levelsSet = false;
    private static bool levelLoading = false;

    public static Levels CurrentLevel { get => currentLevel; }
    public static bool LevelsSet
    {
        get => levelsSet; set
        {
            if(!levelsSet) levelsSet = value;
        }
    }

    public static Levels PreviousLevel { get => previousLevel; }
    public static bool LevelLoading { get => levelLoading; set => levelLoading = value; }

    public static LevelInfo GetLevelInfo(SceneManager.Levels level)
    {
        return levels[(int)level];
    }

    public static void AddLevel(string name, string sceneName, string menuDisplayInfo = "", string menuAchievementInfo = "", float cubeFaceDuration = 10.0f)
    {
        if(!levelsSet) levels.Add(new LevelInfo(name, sceneName, menuDisplayInfo, menuAchievementInfo, cubeFaceDuration));
    }

    public static void LoadLevel(SceneManager.Levels level, string displayText = "")
    {
        // prevent people loading the menu twice through race conditions and causing spurious spawn points in the menu
        if (levelLoading == true) return;
        if(level == Levels.MENU) levelLoading = true;

        previousLevel = currentLevel;
        levels[(int)CurrentLevel].menuAchievementInfo = displayText;
        currentLevel = level;
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(levels[(int)level].sceneName);
    }

}

public class LevelInfo
{
    public string name;
    public string menuDisplayInfo;
    public string menuAchievementInfo;
    public string sceneName;
    public float cubeFaceDuration;
    public bool levelPlayed;

    public LevelInfo(string name, string sceneName)
    {
        this.name = name;
        this.sceneName = sceneName;
        this.menuDisplayInfo = "";
        this.menuAchievementInfo = "";
        this.cubeFaceDuration = 10;
        this.levelPlayed = false;
    }

    public LevelInfo(string name, string sceneName, string menuDisplayInfo, string menuAchievementInfo, float cubeFaceDuration)
    {
        this.name = name;
        this.sceneName = sceneName;
        this.menuDisplayInfo = menuDisplayInfo;
        this.menuAchievementInfo = menuAchievementInfo;
        this.cubeFaceDuration = cubeFaceDuration;
        this.levelPlayed = false;
    }
}
