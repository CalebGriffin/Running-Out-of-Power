using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, CubeController.Instance.GetSpawnPoint());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
