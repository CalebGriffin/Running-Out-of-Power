using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPoint : MonoBehaviour
{
    //Stuff to do:
        //!When blocks collide with the touchpoint create logic to handle if the blocks are in the correct place
        //!Depending on above make changes to the battery life 
        //*Add VFX
        //*Add sounds 

    [SerializeField] private InputController inputController;
    [Header("Battery Values")]
    [SerializeField] private float correctValue;
    [SerializeField] private float incorrectValue;
    
    private void OnCollisionEnter2D(Collision2D other) {
        //Get the active container's id 
        if(other.gameObject.CompareTag("blueBlock"))
            if(inputController.ActiveContainer.AreBlocksPlacedCorrectly(other.transform.position.x)){
                Debug.Log("Correct");
                Battery.UpdateBatteryLife(correctValue);
            }
            else{
                Battery.UpdateBatteryLife(incorrectValue);
                Debug.Log("Incorrect");
            }

        //Set the blocks to inactive to avoid a missing reference exception
        other.gameObject.SetActive(false); 
        //if(inputController.ActiveContainer.CorrectBlockId()) Debug.Log("Correct");
        //else Debug.Log("Incorrect");
        
    }
}
