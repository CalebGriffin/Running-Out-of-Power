using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoaderScreen : MonoBehaviour
{
    [SerializeField] private SceneManager.Levels levelID;
    [SerializeField] private Forcefield forcefield;

    public SceneManager.Levels LevelID { get => levelID; }

    private void Start()
    {
        if (forcefield == null) return;
        if (SceneManager.GetLevelInfo(levelID).levelPlayed) forcefield.Off();
    }

}
