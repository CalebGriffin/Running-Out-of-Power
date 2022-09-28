using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private bool resetLights;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        LightFader playerLightFader;

        SceneManager.AddLevel("Menu", "Menu", "", "");
        SceneManager.AddLevel("Arrow Game", "ArrowGame", "", "");


        player = Instantiate(playerPrefab, CubeController.Instance.GetSpawnPoint());

        playerLightFader = player.GetComponentInChildren<LightFader>();

        if (playerLightFader != null)
        {
            LightingController.Instance.AddLight(playerLightFader);
        }

        LightingController.Instance.SetLightsToReduce(10);

    }

    // Update is called once per frame
    void Update()
    {
        if(resetLights)
        {
            LightingController.Instance.ResetLights();
            LightingController.Instance.SetLightsToReduce(10);
            resetLights = false;
        }
    }



}
