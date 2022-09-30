using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFader : MonoBehaviour
{
    public enum LightState
    {
        LIGHT_OFF = 0,
        LIGHT_ON,
        LIGHT_FADING,
        LIGHT_BRIGHTENING,
        LIGHT_FLICKERING,
        NUM_OF_STATES
    }

    [SerializeField] private Light myLight;
    [SerializeField] private bool affectIntensity;
    [SerializeField] private bool affectSpotAngle;
    [SerializeField] private float minIntensity;
    [SerializeField] private float maxIntensity;
    [SerializeField] private float minSpotAngle;
    [SerializeField] private float maxSpotAngle;
    [SerializeField] private float startingIntensity;
    [SerializeField] private float startingSpotAngle;
    [SerializeField] private bool flicker;
    [SerializeField] private float flickerTime;
    [SerializeField] private float flickerMinSpeed;
    [SerializeField] private float flickerMaxSpeed;
    [SerializeField] private float flickerMinIntensity;
    [SerializeField] private float flickerMaxIntensity;


    [SerializeField] private LightState currentState = LightState.LIGHT_ON;
    private float lightDuration;
    private Coroutine flickerCoroutine;
    private float flickerTimer = 0.0f;
    private Coroutine dimmingCoroutine;
    private Coroutine brighteningCoroutine;

    public LightState CurrentState { get => currentState; }

    //public LightController(Light light, float minIntensity, float maxIntensity, float minSpotAngle, float maxSpotAngle, bool flicker, float flickerTime, bool affectIntensity, bool affectSpotAngle)
    //{
    //    this.light = light;
    //    this.minIntensity = minIntensity;
    //    this.maxIntensity = maxIntensity;
    //    startingIntensity = this.light.intensity;

    //    this.minSpotAngle = minSpotAngle;
    //    this.maxSpotAngle = maxSpotAngle;
    //    startingSpotAngle = this.light.spotAngle;

    //    this.flicker = flicker;
    //    this.flickerTime = flickerTime;

    //    this.affectIntensity = affectIntensity;
    //    this.affectSpotAngle = affectSpotAngle;
    //}

    void Awake()
    {
        startingIntensity = this.myLight.intensity;
        startingSpotAngle = this.myLight.spotAngle;
    }

    void Update()
    {
        switch (currentState)
        {
            case LightState.LIGHT_OFF:
                break;
            case LightState.LIGHT_ON:
                break;
            case LightState.LIGHT_FADING:

                break;
            case LightState.LIGHT_FLICKERING:

                if (flickerCoroutine != null)
                {
                    flickerTimer += Time.deltaTime;
                    if (flickerTimer > flickerTime)
                    {
                        StopCoroutine(flickerCoroutine);
                        this.myLight.intensity = 0;
                        this.currentState = LightState.LIGHT_OFF;
                    }
                }

                break;
            case LightState.LIGHT_BRIGHTENING:
                break;
            case LightState.NUM_OF_STATES:
            default:
                break;
        }
    }
    IEnumerator FlickerLight()
    {
        float timer = 0.0f;
        while (timer <= flickerTime)
        {
            timer += Time.deltaTime;

            
            myLight.intensity = Random.Range(flickerMinIntensity, flickerMaxIntensity);
            yield return new WaitForSeconds(Random.Range(flickerMinSpeed, flickerMaxSpeed));
            myLight.intensity = 0;
            yield return new WaitForSeconds(Random.Range(flickerMinSpeed, flickerMaxSpeed));
        }

        myLight.intensity = 0;
        currentState = LightState.LIGHT_OFF;
    }

    IEnumerator LerpLightDim()
    {
        float timer = 0.0f;

        while (timer <= lightDuration)
        {
            timer += Time.deltaTime;

            if (affectIntensity)
            {
                myLight.intensity = Mathf.Lerp(startingIntensity, minIntensity, timer / lightDuration);
            }
            if (affectSpotAngle)
            {
                myLight.spotAngle = Mathf.Lerp(startingSpotAngle, minSpotAngle, timer / lightDuration);
            }

            yield return null;
        }

        if (affectIntensity)
        {
            myLight.intensity = minIntensity;
        }
        if (affectSpotAngle)
        {
            myLight.spotAngle = minSpotAngle;
        }

        if (flicker)
        {
            flickerCoroutine = StartCoroutine(FlickerLight());
            currentState = LightState.LIGHT_FLICKERING;
        }
        else
        {
            currentState = LightState.LIGHT_OFF;
        }

    }

    IEnumerator LerpLightBrighten()
    {
        float timer = 0.0f;
        float currentIntensity = myLight.intensity;
        float currentSpotAngle = myLight.spotAngle;

        while (timer <= lightDuration)
        {
            timer += Time.deltaTime;

            if (affectIntensity)
            {
                myLight.intensity = Mathf.Lerp(currentIntensity, startingIntensity, timer / lightDuration);
            }
            if (affectSpotAngle)
            {
                myLight.spotAngle = Mathf.Lerp(currentSpotAngle, startingSpotAngle, timer / lightDuration);
            }

            yield return null;
        }

        if (affectIntensity)
        {
            myLight.intensity = startingIntensity;
        }
        if (affectSpotAngle)
        {
            myLight.spotAngle = startingSpotAngle;
        }

        flickerTimer = 0;
        currentState = LightState.LIGHT_ON;

    }

    public void StartLightDimming(float duration)
    {
        //if (currentState != LightState.LIGHT_ON) return;
        if (brighteningCoroutine != null) StopCoroutine(brighteningCoroutine);
        lightDuration = duration;
        dimmingCoroutine = StartCoroutine(LerpLightDim());
        currentState = LightState.LIGHT_FADING;
    }

    public void StartLightBrightening(float duration)
    {
        //if (currentState != LightState.LIGHT_FADING) return;
        if (dimmingCoroutine != null) StopCoroutine(dimmingCoroutine);
        if (flickerCoroutine != null) StopCoroutine(flickerCoroutine);
        if ((affectIntensity == false) && (flicker == true)) myLight.intensity = startingIntensity;
        lightDuration = duration;
        brighteningCoroutine = StartCoroutine(LerpLightBrighten());
        currentState = LightState.LIGHT_BRIGHTENING;
    }

    public void LightOff()
    {
        if (dimmingCoroutine != null) StopCoroutine(dimmingCoroutine);
        if (flickerCoroutine != null) StopCoroutine(flickerCoroutine);
        if (brighteningCoroutine != null) StopCoroutine(brighteningCoroutine);
        if (affectIntensity)
        {
            myLight.intensity = minIntensity;
        }
        if (affectSpotAngle)
        {
            myLight.spotAngle = minSpotAngle;
        }
        currentState = LightState.LIGHT_OFF;
    }

    public void ResetLight()
    {
        if (this.currentState != LightState.LIGHT_OFF) return;
        this.myLight.intensity = startingIntensity;
        this.myLight.spotAngle = startingSpotAngle;
        this.flickerTimer = 0;
        this.currentState = LightState.LIGHT_ON;
    }
}
