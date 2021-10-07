using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

using UnityEngine;
using System.Collections;



public enum LOADING_TRANSITION
{
    CROSS_FADE, CIRCLE_WIPE, LOGO_TRANSITION
}

public class SceneLoader : MonoBehaviour
{
    //
    [System.Serializable]
    private class LoadingBarScreen
    {
        public bool isLoadingBarOn;
        public GameObject loadingBarObject;
        public Slider slider;
        public TextMeshProUGUI progressText;
    }

    [SerializeField]
    private LoadingBarScreen loadingBarScreen = new LoadingBarScreen();


    //
    [System.Serializable]
    private class LoadingTransitionType
    {
        public GameObject crossFade;
        public GameObject circleWipe;
        public GameObject logoTransition;
    }

    [SerializeField]
    private LoadingTransitionType loadingTransitionType = new LoadingTransitionType();
    //

    //[SerializeField] GameObject crossFade; 
    Animator animator;


    public LOADING_TRANSITION loading_Transition { get; set; }
    [SerializeField] private float transitionTime = 1f;


    [System.NonSerialized]
    private int currentSceneIndex;

    public SceneNames sceneNames = new SceneNames();

    private void Start()
    {
        
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;


        if(loadingBarScreen != null)
        loadingBarScreen.loadingBarObject.SetActive(false);

        if(loadingTransitionType.crossFade != null)
        {
            animator = loadingTransitionType.crossFade.GetComponent<Animator>();
        }

        switch(loading_Transition)
        {
            case LOADING_TRANSITION.CIRCLE_WIPE:
                {

                }
                break;
            case LOADING_TRANSITION.CROSS_FADE:
                {

                }
                break;
            case LOADING_TRANSITION.LOGO_TRANSITION:
                {

                }
                break;
        }

    }


    public void RestartScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }


    public void LoadNextScene()
    {

        SceneManager.LoadScene(currentSceneIndex + 1);
    }


    public void QuitGame()
    {
        Application.Quit();
    }


    //

    public void LoadingCrossFace()
    {
        StartCoroutine(LoadLevel((SceneManager.GetActiveScene().buildIndex) + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        if(animator != null)
        {
            animator.SetTrigger("Start");
        }

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    //

    public void LoadingScreenBar(int sceneIndex)
    {
        StartCoroutine(LoadAsyncOperation(sceneIndex));
    }

    IEnumerator LoadAsyncOperation (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingBarScreen.loadingBarObject.SetActive(true);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            loadingBarScreen.slider.value = progress;
            loadingBarScreen.progressText.text = progress * 100f + "%";

            yield return null;
        }
    }
}
