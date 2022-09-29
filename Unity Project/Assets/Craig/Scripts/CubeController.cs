using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private static CubeController instance;

    public enum CubeStates
    {
        STATIC = 0,
        ROTATING,
        NUM_OF_STATES
    }

    [SerializeField] private float rotationAngle = 90.0f;
    [SerializeField] private float rotationLerpDuration = 3.0f;
    [SerializeField] private List<Vector3> rotationSequence;
    [SerializeField] private List<Transform> startingSpawnPoints;
    [SerializeField] private List<Transform> reentrySpawnPoints;

    private int rotationSequenceIndex = 0;
    private Vector3 eulerLerpOutput = Vector3.zero;
    private Vector3 eulerLerpStart = Vector3.zero;
    private Vector3 eulerLerpEnd = Vector3.zero;

    private Quaternion qStart = Quaternion.Euler(Vector3.zero);
    private Quaternion qEnd = Quaternion.Euler(Vector3.zero);
    private Vector3 positionStart = Vector3.zero;
    private Vector3 positionEnd = Vector3.zero;
    private float rotationRate = 0.0f;

    private SceneManager.Levels currentFaceLevel = SceneManager.Levels.LEVEL1;

    private CubeStates cubeState = CubeStates.STATIC;
    public CubeStates CubeState { get => cubeState; }
    public static CubeController Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<CubeController>();
            return instance;
        }
    }

    public SceneManager.Levels CurrentFaceLevel { get => currentFaceLevel; }

    void Awake()
    {

        if (rotationSequence.Count <= 0)
        {
            Debug.LogError("Error: rotationSequence not set!");
            return;
        }
        rotationRate = rotationAngle / rotationLerpDuration;

        

        eulerLerpStart = eulerLerpOutput = gameObject.transform.eulerAngles = rotationSequence[rotationSequenceIndex];
        qStart = transform.rotation;
        qEnd = transform.rotation;
        positionEnd = transform.position;
        positionStart = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch(cubeState)
        {
            case CubeStates.STATIC:

                transform.rotation = qEnd;
                transform.position = positionEnd;
                break;
            case CubeStates.ROTATING:
                

                break;
            
            case CubeStates.NUM_OF_STATES:
            default:
                // should not get here
                break;
        }
        //transform.eulerAngles = eulerLerpOutput;
    }

    IEnumerator rotateFunc()
    {
        for(float i = 0.0f; i < rotationAngle; i += Time.deltaTime * rotationRate)
        {
            yield return null;
            transform.Rotate(rotationSequence[rotationSequenceIndex], Time.deltaTime * rotationRate);
        }

        cubeState = CubeStates.STATIC;
    }

    public Transform GetSpawnPoint()
    {
        return startingSpawnPoints[rotationSequenceIndex];
    }

    public Transform GetReEntrySpawnPoint()
    {
        return reentrySpawnPoints[rotationSequenceIndex];
    }

    public void RotateNext()
    {
        if (cubeState == CubeStates.ROTATING) return;
        
        if(++rotationSequenceIndex >= rotationSequence.Count) return;

        qStart = transform.rotation;
        positionStart = transform.position;

        transform.Rotate(rotationSequence[rotationSequenceIndex], rotationAngle);

        qEnd = transform.rotation;
        positionEnd = transform.position;

        transform.rotation = qStart;
        transform.position = positionStart;

        StartCoroutine(rotateFunc());

        currentFaceLevel++;
        cubeState = CubeStates.ROTATING;

        //transform.RotateAround()
        //rotationSequenceIndex++;
        //eulerLerpStart = Vector3.Scale(transform.eulerAngles, rotationSequence[rotationSequenceIndex]);
        //eulerLerpEnd = Vector3.Scale()
        //StartCoroutine(LerpRotation());
        //cubeState = CubeStates.ROTATING;
    }



    //IEnumerator LerpRotation()
    //{
    //    float timeElapsed = 0;

    //    while (timeElapsed < rotationLerpDuration)
    //    {
    //        eulerLerpOutput = Vector3.Lerp(eulerLerpStart, rotationSequence[rotationSequenceIndex], timeElapsed / rotationLerpDuration);
    //        timeElapsed += Time.deltaTime;
    //        yield return null;
    //    }

    //    eulerLerpOutput = rotationSequence[rotationSequenceIndex];
    //    cubeState = CubeStates.STATIC;
    //}
}
