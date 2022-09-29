using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoaderScreen : MonoBehaviour
{
    [SerializeField] private SceneManager.Levels levelID;

    public SceneManager.Levels LevelID { get => levelID; }

}
