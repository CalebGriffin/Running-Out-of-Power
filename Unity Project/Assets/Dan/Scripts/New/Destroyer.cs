using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        bool block = other.gameObject.GetComponent<Blocks>().isLast;
        Manager.Instance.UpdateBlockPositions(block);
        ScreenShake.Instance.Shake(4);
        Battery.UpdateBatteryLife(-10);
        Manager.Instance.CalculateAccuarcy(false);
        other.gameObject.SetActive(false);
    }
}
