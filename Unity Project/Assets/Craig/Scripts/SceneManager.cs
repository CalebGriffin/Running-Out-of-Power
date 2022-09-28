
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneManager
{

    private static List<LevelInfo> levels;

    public static int currentLevel = 0;


    public static void AddLevel(string name, string sceneName, string menuDisplayInfo = "")
    {
        levels.Add(new LevelInfo(name, sceneName, menuDisplayInfo));
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
    public string sceneName;

    public LevelInfo(string name, string sceneName)
    {
        this.name = name;
        this.sceneName = sceneName;
        this.menuDisplayInfo = "";
    }

    public LevelInfo(string name, string sceneName, string menuDisplayInfo)
    {
        this.name = name;
        this.sceneName = sceneName;
        this.menuDisplayInfo = menuDisplayInfo;

    }
}
