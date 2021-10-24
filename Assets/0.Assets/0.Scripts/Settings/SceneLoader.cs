using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum LOADING_TRANSITION_TYPE
{
    CROSS_FADE, CIRCLE_WIPE, LOGO_TRANSITION
}

public class SceneLoader : MonoBehaviour
{
    //
    [System.Serializable]
    private class LoadingBar
    {
        public bool isLoadingBarOn;
        public GameObject loadingBarObject;
        public Slider slider;
        public TextMeshProUGUI progressText;
    }

    [SerializeField]
    private LoadingBar loadingBar = new LoadingBar();
   

    //
    [System.Serializable]
    private class LoadingTransition
    {
        public GameObject crossFade;
        public GameObject circleWipe;
        //public GameObject logoTransition;
    }

    [SerializeField]
    private LoadingTransition loadingTransition = new LoadingTransition();
    //

    //[SerializeField] GameObject crossFade; 
    private Animator animator;


    // enum
    public LOADING_TRANSITION_TYPE loadingTransitionType;
    [SerializeField] private float transitionTime = 1f;


    [System.NonSerialized]
    private int currentSceneIndex;


    //
    public SceneName sceneName = new SceneName();

    private int mainLevel = 0;
    private int subLevel = 0;


    public void DisableAllLoadingScreen()
    {
        loadingBar.loadingBarObject.SetActive(false);

        loadingTransition.crossFade.SetActive(false);
        loadingTransition.circleWipe.SetActive(false);

    }

    public void SetLoadingScreen(bool turnOnLoadingBar = false)
    {
       

    }

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        /*

        switch (loadingTransitionType)
        {
            case LOADING_TRANSITION_TYPE.CROSS_FADE:
                {
                    animator = loadingTransition.crossFade.GetComponent<Animator>();
                }
                break;
            case LOADING_TRANSITION_TYPE.CIRCLE_WIPE:
                {
                    animator = loadingTransition.circleWipe.GetComponent<Animator>();
                }
                break;

                
            case LOADING_TRANSITION_TYPE.LOGO_TRANSITION:
                {

                }
                break;
                
        }
        */

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

        operation.allowSceneActivation = false;

        loadingBar.loadingBarObject.SetActive(true);

        while(!operation.isDone)
        {
            // operation.progress 는 0~ 0.9 까지만 임 그래서 0~1로 하려면 아래 공식 필요.
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            loadingBar.slider.value = progress;
            loadingBar.progressText.text = "Loading... " + progress * 100f + "%";
            

            yield return null;

            if(operation.progress == 1)
            {
                print("Loading Done press Return");
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                print("Enter Pressed");
                operation.allowSceneActivation = true;

            }
        }

       
    }

}
