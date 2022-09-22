using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocation 
{
    private Transform playerLocation;
    public PlayerLocation(Transform playerLocation){
        this.playerLocation = playerLocation;
    }
    public Vector3 ReturnPlayerLocation() => playerLocation.position;
    
}
