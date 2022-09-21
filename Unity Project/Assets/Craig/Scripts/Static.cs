using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Static : MonoBehaviour
{


    [SerializeField] private Texture2D[] staticFrames;
    [SerializeField] private int speed;

    private Material myMat;
    private int count;
    private int frameCount;

    // Start is called before the first frame update
    void Start()
    {
        myMat = GetComponent<Renderer>().material;
        count = 0;
        frameCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == speed)
        {
            myMat.mainTexture = staticFrames[frameCount++];
            if (frameCount == staticFrames.Length) frameCount = 0;
            count = 0;
        }
        count++;


    }
}
