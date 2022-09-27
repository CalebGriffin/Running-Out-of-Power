using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    //Battery will be constantly draining
    //Matching the blocks to the correct colours will increase the battery by 10 
    //Incorrect matches will decrease by 10
    [SerializeField] private static float batteryLife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        batteryLife -= Time.deltaTime;
        transform.localScale = new Vector3(1, Mathf.Clamp01(batteryLife / 100), 1);
    }

    public static void  UpdateBatteryLife(float batteryValue) => batteryLife += batteryValue;
}
