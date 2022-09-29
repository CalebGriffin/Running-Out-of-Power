using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    //Battery will be constantly draining
    //Matching the blocks to the correct colours will increase the battery by 10 
    //Incorrect matches will decrease by 10
    [SerializeField] private static float batteryLife;
    private void Start() {
        batteryLife = 100f;
    }
    // Update is called once per frame
    void Update()
    {
        batteryLife -= Time.deltaTime;
        transform.localScale = new Vector3(1, Mathf.Clamp01(batteryLife / 100), 1);

        if(batteryLife <= 0){
            Manager.Instance.GameOver();
        }
    }

    public static void UpdateBatteryLife(float batteryValue) => batteryLife = Mathf.Clamp(batteryLife += batteryValue, 0, 100);
}
