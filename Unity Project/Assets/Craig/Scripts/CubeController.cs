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
        OPENING,
        NUM_OF_STATES
    }

    [SerializeField] private float rotationAngle = 90.0f;
    [SerializeField] private float rotationLerpDuration = 3.0f;
    
    [SerializeField] private float openingCountTime = 3.0f;
    [SerializeField] private float openingAmount = -10f;
    [SerializeField] private List<Vector3> rotationSequence;
    [SerializeField] private List<Transform> startingSpawnPoints;
    [SerializeField] private List<Transform> reentrySpawnPoints;
    [SerializeField] private List<GameObject> movingFaces;
    [SerializeField] private List<GameObject> faces;


    private int rotationSequenceIndex = 0;
    private Vector3 eulerLerpOutput = Vector3.zero;
    private Vector3 eulerLerpStart = Vector3.zero;
    private Vector3 eulerLerpEnd = Vector3.zero;

    private int openingCount = 0;

    private Quaternion qStart = Quaternion.Euler(Vector3.zero);
    private Quaternion qEnd = Quaternion.Euler(Vector3.zero);
    private Vector3 positionStart = Vector3.zero;
    private Vector3 positionEnd = Vector3.zero;
    private float rotationRate = 0.0f;
    private bool rotationComplete = false;

    private Coroutine openingCoroutine = null;

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
    public float RotationLerpDuration { get => rotationLerpDuration; }

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

    private float checkTimer = 0;
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
            case CubeStates.OPENING:
                if(rotationComplete)
                {
                    transform.rotation = qEnd;
                    transform.position = positionEnd;

                    checkTimer += Time.deltaTime;
                    if(checkTimer > openingCountTime)
                    {
                        if(openingCoroutine != null) StopCoroutine(openingCoroutine);
                        cubeState = CubeStates.STATIC;
                    }
                    
                }
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
        faces[rotationSequenceIndex - 1].SetActive(false);
        if (cubeState == CubeStates.OPENING)
        {
            rotationComplete = true;
            openingCoroutine = StartCoroutine(lerpOpen());
        }
        else
        {
            cubeState = CubeStates.STATIC;
        }
        
    }

    IEnumerator lerpOpen()
    {
        float duration = 0;
        Vector3 tempPos = Vector3.zero;
        float lerpedValue = 0;

        while (duration < openingCountTime)
        {
            duration += Time.deltaTime;

            foreach(GameObject face in movingFaces)
            {
                lerpedValue = Mathf.Lerp(face.transform.localPosition.z, (face.transform.localPosition.z + openingAmount), duration / openingCountTime);
                tempPos = new Vector3(face.transform.localPosition.x, face.transform.localPosition.y, lerpedValue);
                face.transform.localPosition = tempPos;
                yield return null;
            }
        }

        foreach(GameObject face in movingFaces)
        {
            tempPos = new Vector3(face.transform.position.x, face.transform.position.y, (face.transform.position.z + openingAmount));
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

    public void SetCubeToLevel(SceneManager.Levels level)
    {
        if (level == SceneManager.Levels.MENU) level++;

        foreach(GameObject face in faces)
        {
            face.SetActive(false);
        }
        faces[(int)level - 1].SetActive(true);

        transform.eulerAngles = Vector3.zero;
        for (rotationSequenceIndex = 0; rotationSequenceIndex < (int)level; rotationSequenceIndex++)
        {
            transform.Rotate(rotationSequence[rotationSequenceIndex], rotationAngle);
        }
        qEnd = transform.rotation;
        positionEnd = transform.position;
        rotationSequenceIndex--;
        currentFaceLevel = level;
    }

    public void RotateNext()
    {
        if (cubeState == CubeStates.ROTATING) return;
        
        if(++rotationSequenceIndex >= rotationSequence.Count-1)
        {
            //time to open the cube
            rotationAngle = 45;
            cubeState = CubeStates.OPENING;
        }
        else
        {
            cubeState = CubeStates.ROTATING;
        }

        faces[rotationSequenceIndex].SetActive(true);
        

        qStart = transform.rotation;
        positionStart = transform.position;

        transform.Rotate(rotationSequence[rotationSequenceIndex], rotationAngle);

        qEnd = transform.rotation;
        positionEnd = transform.position;

        transform.rotation = qStart;
        transform.position = positionStart;

        StartCoroutine(rotateFunc());

        currentFaceLevel++;
        

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
