using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Image blackImage;

    [SerializeField] private float transitionTime = 0.5f;

    private static LevelLoader instance;

    public static LevelLoader Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnEnable()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        blackImage.color = new Color(0, 0, 0, 1);
        float timeElapsed = 0;
        while (timeElapsed < transitionTime)
        {
            float alpha = Mathf.Lerp(1, 0, timeElapsed / transitionTime);
            blackImage.color = new Color(0, 0, 0, alpha);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        blackImage.color = new Color(0, 0, 0, 0);
    }

    public void StartTransition(SceneManager.Levels levelToLoad)
    {
        StartCoroutine(TransitionToScene(levelToLoad, ""));
    }

    public void StartTransition(SceneManager.Levels levelToLoad, string displayText)
    {
        StartCoroutine(TransitionToScene(levelToLoad, displayText));
    }

    private IEnumerator TransitionToScene(SceneManager.Levels levelToLoad, string displayText)
    {
        float timeElapsed = 0;
        while (timeElapsed < transitionTime)
        {
            float alpha = Mathf.Lerp(0, 1, timeElapsed / transitionTime);
            blackImage.color = new Color(0, 0, 0, alpha);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        blackImage.color = new Color(0, 0, 0, 1);

        // Call the static class to actually change the scene
        SceneManager.LoadLevel(levelToLoad, displayText);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
