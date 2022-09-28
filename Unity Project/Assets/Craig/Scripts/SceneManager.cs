
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneManager
{
    public enum Levels
    {
        MENU = 0,
        LEVEL1,
        LEVEL2,
        LEVEL3,
        LEVEL4,
        LEVEL5,
        LEVEL6,
        LEVEL7
    }

    private static List<LevelInfo> levels = new List<LevelInfo>();

    public static int currentLevel = 0;


    public static void AddLevel(string name, string sceneName, string menuDisplayInfo = "", string menuAchievementInfo = "")
    {
        levels.Add(new LevelInfo(name, sceneName, menuDisplayInfo, menuAchievementInfo));
    }

    public static void LoadLevel(int level)
    {
        currentLevel = level;

    }


    public static void ReturnToMenu()
    {
        
    }

    public static void ReturnToMenu(string displayText)
    {

    }

}

public class LevelInfo
{
    public string name;
    public string menuDisplayInfo;
    public string menuAchievementInfo;
    public string sceneName;

    public LevelInfo(string name, string sceneName)
    {
        this.name = name;
        this.sceneName = sceneName;
        this.menuDisplayInfo = "";
        this.menuAchievementInfo = "";
    }

    public LevelInfo(string name, string sceneName, string menuDisplayInfo, string menuAchievementInfo)
    {
        this.name = name;
        this.sceneName = sceneName;
        this.menuDisplayInfo = menuDisplayInfo;
        this.menuAchievementInfo = menuAchievementInfo;

    }
}
