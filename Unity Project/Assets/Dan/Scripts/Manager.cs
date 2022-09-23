using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will hold scene references and monitor the overall flow of the game
public class Manager : MonoBehaviour
{
    #region Singleton
    public static Manager Instance {get; private set;}
    private void Awake() {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    #endregion
    [SerializeField] private Transform playerRef;
    

    public Vector3 GetPlayerPosition() => playerRef.position;
}
