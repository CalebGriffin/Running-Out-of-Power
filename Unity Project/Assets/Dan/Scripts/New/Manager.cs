using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    [SerializeField] private TextMeshProUGUI accuracyText; 
    [SerializeField] private GameObject accuracyObj;
    [SerializeField] private GameObject howToPlay;
    private float accuracy;
    private float totalBlocks;
    private float correctBlocks;
    private float blockSpeedTimer = 10;
    private void Start() {
        blocksFinished = 0;
        accuracy = 0;
        totalBlocks = 0;
        correctBlocks = 0;
        LeanTween.scale(accuracyObj, new Vector3(0, 0, 0), 0f);
        StartCoroutine(ManageText());
    }
    private void Update() {
        speed += 1f * Time.deltaTime;
    }

    public void UpdateBlockPositions(bool isFinished){
        if(isFinished) blocksFinished++;

        if(blocksFinished == 4) GameOver();
    }

    public void GameOver(){
        Debug.Log("Game Over");
        
        LevelLoader.Instance.StartTransition(SceneManager.Levels.MENU, $"Your accuracy was: {accuracy}");
    }

    public float GetSpeed() => speed;
    public void CalculateAccuarcy(bool correct){
        totalBlocks++;
        if(correct){
            correctBlocks++;
        }
        accuracy = Mathf.Round((correctBlocks / totalBlocks) * 100);
        accuracyText.text = accuracy.ToString() + "%";
    }

    private IEnumerator ManageText(){
        yield return new WaitForSeconds(10f);
        LeanTween.scale(howToPlay, new Vector3(0, 0, 0), 0.5f).setOnComplete(ShowAccuracy);
    }
    private void ShowAccuracy(){
        LeanTween.scale(accuracyObj, new Vector3(1, 1, 1), 0.5f);
    }

}
