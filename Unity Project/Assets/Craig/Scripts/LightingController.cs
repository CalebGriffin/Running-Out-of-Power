using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightingController : MonoBehaviour
{
    //[Serializable]
    //public class LightController
    //{
    //    public enum LightState
    //    {
    //        LIGHT_OFF = 0,
    //        LIGHT_ON,
    //        LIGHT_FADING,
    //        LIGHT_FLICKERING,
    //        NUM_OF_STATES
    //    }

    //    [SerializeField] public Light light;
    //    [SerializeField] public bool affectIntensity;
    //    [SerializeField] public bool affectSpotAngle;
    //    [SerializeField] public float minIntensity;
    //    [SerializeField] public float maxIntensity;
    //    [SerializeField] public float minSpotAngle;
    //    [SerializeField] public float maxSpotAngle;
    //    [SerializeField] public float startingIntensity;
    //    [SerializeField] public float startingSpotAngle;
    //    [SerializeField] public bool flicker;
    //    [SerializeField] public float flickerTime;

    //    [SerializeField] private LightState currentState = LightState.LIGHT_ON;
    //    private float lightDuration;

    //    public LightState CurrentState { get => currentState; }

    //    public LightController(Light light, float minIntensity, float maxIntensity, float minSpotAngle, float maxSpotAngle, bool flicker, float flickerTime, bool affectIntensity, bool affectSpotAngle)
    //    {
    //        this.light = light;
    //        this.minIntensity = minIntensity;
    //        this.maxIntensity = maxIntensity;
    //        startingIntensity = this.light.intensity;

    //        this.minSpotAngle = minSpotAngle;
    //        this.maxSpotAngle = maxSpotAngle;
    //        startingSpotAngle = this.light.spotAngle;
            
    //        this.flicker = flicker;
    //        this.flickerTime = flickerTime;

    //        this.affectIntensity = affectIntensity;
    //        this.affectSpotAngle = affectSpotAngle;
    //    }

    //    public void Update()
    //    {
    //        switch (currentState)
    //        {
    //            case LightState.LIGHT_OFF:
    //                break;
    //            case LightState.LIGHT_ON:
    //                break;
    //            case LightState.LIGHT_FADING:
                    
    //                break;
    //            case LightState.LIGHT_FLICKERING:
    //                currentState = LightState.LIGHT_OFF;
    //                break;
    //            case LightState.NUM_OF_STATES:
    //            default:
    //                break;
    //        }
    //    }

    //    IEnumerator LerpLight()
    //    {
    //        float timer = 0.0f;

    //        while(timer <= lightDuration)
    //        {
    //            timer += Time.deltaTime;

    //            if(affectIntensity)
    //            {
    //                light.intensity = Mathf.Lerp(startingIntensity, minIntensity, timer / lightDuration);
    //            }
    //            if(affectSpotAngle)
    //            {
    //                light.spotAngle = Mathf.Lerp(startingSpotAngle, minSpotAngle, timer / lightDuration);
    //            }

    //            yield return null;
    //        }

    //        if (affectIntensity)
    //        {
    //            light.intensity = minIntensity;
    //        }
    //        if (affectSpotAngle)
    //        {
    //            light.spotAngle = minSpotAngle;
    //        }

    //        if(flicker)
    //        {
    //            currentState = LightState.LIGHT_FLICKERING;
    //        }
    //        else
    //        {
    //            currentState = LightState.LIGHT_OFF;
    //        }

    //    }

    //    public void StartLightBehaviour(float duration)
    //    {
    //        if (currentState != LightState.LIGHT_ON) return;
    //        lightDuration = duration;
            
    //        currentState = LightState.LIGHT_FADING;
    //    }

    //    public void ResetLight()
    //    {
    //        this.light.intensity = startingIntensity;
    //        this.light.spotAngle = startingSpotAngle;
    //        this.currentState = LightState.LIGHT_ON;
    //    }

    //}

    public enum LightingState
    {
        LIGHTS_OFF = 0,
        LIGHTS_ON,
        LIGHTS_DIMMING,
        LIGHTS_BRIGHTENING,
        NUM_OF_STATES
    }

    [SerializeField] List<LightFader> lights;
    [SerializeField] private TextMeshPro menuText;
    [SerializeField] private float menuTextGlowDefault;

    private static LightingController instance;

    [SerializeField] private LightingState currentLightingState = LightingState.LIGHTS_ON;

    public static LightingController Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<LightingController>();
            return instance;
        }
    }

    public LightingState CurrentLightingState { get => currentLightingState;}

    public void AddLight(LightFader lightFader)
    {
        lights.Add(lightFader);
    }

    public void SetLightsToReduce(float duration)
    {
        if (currentLightingState != LightingState.LIGHTS_ON) return;
        
        foreach(LightFader lightFader in lights)
        {
            lightFader.StartLightDimming(duration);
        }
        
        currentLightingState = LightingState.LIGHTS_DIMMING;
    }

    public void SetLightsToIncrease(float duration)
    {
        if ((currentLightingState != LightingState.LIGHTS_DIMMING) && (currentLightingState != LightingState.LIGHTS_OFF) ) return;
        foreach (LightFader lightFader in lights)
        {
            lightFader.StartLightBrightening(duration);
        }

        currentLightingState = LightingState.LIGHTS_BRIGHTENING;
    }

    public void ResetLights()
    {
        foreach(LightFader lightFader in lights)
        {
            lightFader.ResetLight();
            
        }
        
        //menuText.fontMaterial.SetFloat(ShaderUtilities.ID_GlowPower, menuTextGlowDefault);
        menuText.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowPower, menuTextGlowDefault);
        currentLightingState = LightingState.LIGHTS_ON;
    }

    // Start is called before the first frame update
    void Awake()
    {
        //menuTextGlowDefault = menuText.fontMaterial.GetFloat(ShaderUtilities.ID_GlowPower);
        ResetLights();
    }

    public void SetLightsOff()
    {
        foreach (LightFader lightFader in lights)
        {
            lightFader.LightOff();
        }

        currentLightingState = LightingState.LIGHTS_DIMMING;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentLightingState)
        {
            case LightingState.LIGHTS_OFF:
                break;
            case LightingState.LIGHTS_ON:
                break;
            case LightingState.LIGHTS_DIMMING:
                int lightsCompletedDimming = 0;

                foreach (LightFader lightFader in lights)
                {

                    if (lightFader.CurrentState == LightFader.LightState.LIGHT_OFF) lightsCompletedDimming++;
                }

                if (lightsCompletedDimming == lights.Count)
                {
                    //menuText.fontMaterial.SetFloat(ShaderUtilities.ID_GlowPower, 0.0f);
                    menuText.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowPower, 0.0f);
                    currentLightingState = LightingState.LIGHTS_OFF;
                }

                break;
            case LightingState.LIGHTS_BRIGHTENING:
                int lightsCompletedBrightening = 0;

                foreach (LightFader lightFader in lights)
                {

                    if (lightFader.CurrentState == LightFader.LightState.LIGHT_ON) lightsCompletedBrightening++;
                }

                if (lightsCompletedBrightening == lights.Count)
                {
                    //menuText.fontMaterial.SetFloat(ShaderUtilities.ID_GlowPower, 0.0f);
                    //menuText.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowPower, 0.0f);
                    currentLightingState = LightingState.LIGHTS_ON;
                }
                break;
            case LightingState.NUM_OF_STATES:
            default:
                break;
        }
    }
}
