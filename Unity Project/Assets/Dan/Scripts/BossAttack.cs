using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private Transform toast; 


    //! TEMPORY VARIALBES
    [SerializeField] private float time = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0){
            GameObject tempToast = Instantiate(toast, transform.position, Quaternion.identity).gameObject;
            tempToast.GetComponent<Toast>().StartUp(Manager.Instance.GetPlayerPosition());
            time = 5f;
        }
    }
}
