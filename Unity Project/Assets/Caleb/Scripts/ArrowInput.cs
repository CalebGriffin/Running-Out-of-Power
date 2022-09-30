using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class ArrowInput : MonoBehaviour
{
    MainInput controls;

    Queue<int> arrowQueue = new Queue<int>();

    [SerializeField] private float sensitivityValue = 0.3f;

    private int score = 0, batteryLife = 100;

    public int BatteryLife { get { return batteryLife; }}

    private bool arrowsMoving = false;
    private bool gameOver = false;

    [SerializeField] private TextMeshProUGUI scoreText, batteryLifeText;

    [SerializeField] private GameObject arrowPrefab;

    List<GameObject> arrowList = new List<GameObject>();

    [SerializeField] private Image batteryImage;
    [SerializeField] private GameObject batteryObj;

    void Start()
    {
        // Populate the queue
        PopulateTheQueue();
    }

    void Awake()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1f);
        if (batteryLife > 0)
        {
            batteryLife--;
            UIUpdate();
            StartCoroutine(Countdown());
        }
        else
        {
            GameOver();
        }
    }

    private void PopulateTheQueue()
    {
        for (int i = 0; i < 5; i++)
        {
            AddToTheQueue();
        }
    }

    private void AddToTheQueue()
    {
        int arrowValue = Random.Range(1, 9);
        arrowQueue.Enqueue(arrowValue);
        SpawnArrow(arrowValue);
    }

    private void SpawnArrow(int arrowValue)
    {
        GameObject arrowObj = Instantiate(arrowPrefab, Vector3.zero, Quaternion.identity);
        arrowList.Add(arrowObj);
        arrowObj.transform.position = new Vector3(0, arrowList.Count - 2, 0);
        if (arrowList.Count > 1)
            arrowObj.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        arrowObj.GetComponent<ArrowController>().SetUp(arrowValue);
    }

    private void RemoveFromTheQueue()
    {
        arrowQueue.Dequeue();

        // Destroy the GameObject
        GameObject arrowObj = arrowList.First();
        arrowList.RemoveAt(0);
        Destroy(arrowObj);

        arrowsMoving = true;

        // Tell all of the other GameObjects to move down
        foreach (GameObject arrow in arrowList)
            arrow.GetComponent<ArrowController>().MoveDown();
        
        StartCoroutine(WaitForInput());

        AddToTheQueue();
    }

    private IEnumerator WaitForInput()
    {
        yield return new WaitForSeconds(0.2f);
        arrowsMoving = false;
    }
    
    private void UIUpdate()
    {
        scoreText.text = score.ToString();
        batteryLifeText.text = batteryLife.ToString() + "%";
        batteryImage.fillAmount = batteryLife / 100f;
        float animTime = 1f - (batteryLife / 100f);
        batteryObj.GetComponent<Animator>().Play("BatteryAction", 0, animTime);
    }

    // Gives an argument for a Vector2 for the direction in which the joystick is being pressed
    public void OnLeft_Stick(InputValue value)
    {
        if (arrowsMoving)
            return;
        if (gameOver)
            return;

        // Get the Vector2 from the input value
        Vector2 inputVector = value.Get<Vector2>();

        // If both values are less than the sensitivity value and greater than the negative of the sensitivity value then return
        if ((inputVector.x < sensitivityValue && inputVector.x > -sensitivityValue && (inputVector.y < sensitivityValue && inputVector.y > -sensitivityValue)))
        {
            return;
        }

        // Is the user trying to go horizontally or vertically
        if (Mathf.Abs(inputVector.x) > Mathf.Abs(inputVector.y))
        {
            LeftOrRight(inputVector.x);
        }
        else
        {
            UpOrDown(inputVector.y);
        }
    }

    private void LeftOrRight(float x)
    {
        if (x > 0 && (arrowQueue.Peek() == 2 || arrowQueue.Peek() == 8))
        {
            CorrectMove();
        }
        else if (x < 0 && (arrowQueue.Peek() == 4 || arrowQueue.Peek() == 6))
        {
            CorrectMove();
        }
        else
        {
            IncorrectMove();
        }
    }

    private void UpOrDown(float y)
    {
        if (y > 0 && (arrowQueue.Peek() == 1 || arrowQueue.Peek() == 7))
        {
            CorrectMove();
        }
        else if (y < 0 && (arrowQueue.Peek() == 3 || arrowQueue.Peek() == 5))
        {
            CorrectMove();
        }
        else
        {
            IncorrectMove();
        }
    }

    private void CorrectMove()
    {
        score++;
        UIUpdate();
        RemoveFromTheQueue();
    }

    private void IncorrectMove()
    {
        if (batteryLife > 5)
        {
            batteryLife -= 5;
            UIUpdate();
        }
        else
        {
            batteryLife = 0;
            UIUpdate();
            GameOver();
        }

        //TODO: Put any visual clues that you made a wrong move here
    }

    private void GameOver()
    {
        gameOver = true;
        LevelLoader.Instance.StartTransition(SceneManager.Levels.MENU, $"You got a score of: {score}");
    }
}
