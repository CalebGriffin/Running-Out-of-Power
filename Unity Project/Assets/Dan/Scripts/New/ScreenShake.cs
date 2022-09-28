using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake Instance {get; private set;}
    private int intensity;

    private void Awake() {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Shake(int intensity){
        this.intensity = intensity;
        ShakeRight();
    }
    private void ShakeLeft(){
        if(intensity > 0){
            intensity--;
            LeanTween.moveX(gameObject, -0.05f, 0.05f).setOnComplete(ShakeRight);
        }
        else LeanTween.moveX(gameObject, 0, 0.05f);
    }
    private void ShakeRight(){
        if (intensity > 0)
        {
            intensity--;
            LeanTween.moveX(gameObject, 0.05f, 0.05f).setOnComplete(ShakeLeft);
        }
        else LeanTween.moveX(gameObject, 0, 0.05f);
    }
    
}
