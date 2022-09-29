using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private GameObject arrowModel;

    [SerializeField] private Material same, opposite;

    private Vector3 currentPos, targetPos;

    private float shrinkTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUp(int arrowValue)
    {
        Vector3 rotation = transform.rotation.eulerAngles; 
        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, -90 * arrowValue);
        arrowModel.GetComponent<MeshRenderer>().material = arrowValue > 4 ? opposite : same;
    }

    public void MoveDown()
    {
        currentPos = transform.localPosition;
        targetPos = new Vector3(currentPos.x, currentPos.y - 1, currentPos.z);

        StartCoroutine(MoveRoutine());

        if (targetPos.y == -1)
        {
            StartCoroutine(GrowRoutine());
        }
    }

    private IEnumerator MoveRoutine()
    {
        float timeElapsed = 0;
        while (timeElapsed < 0.2f)
        {
            transform.localPosition = Vector3.Lerp(currentPos, targetPos, timeElapsed / 0.2f);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = targetPos;

        if (transform.localPosition.y == -1)
        {
            shrinkTime = ((GameObject.Find("Input Manager").GetComponent<ArrowInput>().BatteryLife * 4) / 100) + 1;
            Debug.Log($"Shrink time is {shrinkTime}");
            StartCoroutine(ShrinkRoutine());
        }
    }

    private IEnumerator ShrinkRoutine()
    {
        float timeElapsed = 0;
        while (timeElapsed < shrinkTime)
        {
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, timeElapsed / shrinkTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        ArrowInput inputManager = GameObject.Find("Input Manager").GetComponent<ArrowInput>();
        inputManager.SendMessage("IncorrectMove");
        inputManager.SendMessage("RemoveFromTheQueue");
    }

    private IEnumerator GrowRoutine()
    {
        float timeElapsed = 0;
        while (timeElapsed < 0.2f)
        {
            transform.localScale = Vector3.Lerp(new Vector3(0.6f, 0.6f, 0.6f), Vector3.one, timeElapsed / 0.2f);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }
}
