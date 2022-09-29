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
    [SerializeField] private int blocksFinished;
    [SerializeField] private float speed;
    [SerializeField] private float speedValue;
    private float blockSpeedTimer = 10;
    private void Start() {
        blocksFinished = 0;
    }
    private void Update() {
        speed += 1.5f * Time.deltaTime;
    }

    public void UpdateBlockPositions(bool isFinished){
        if(isFinished) blocksFinished++;

        if(blocksFinished == 4) GameOver();
    }

    public void GameOver(){
        Debug.Log("Game Over");
    }

    public float GetSpeed() => speed;

}
