using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{
    private Animator mAnimator;

    [HideInInspector] public string nextSceneName;

    //--------------------------------------------------

    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
    }

    //--------------------------------------------------

    public void FadeInChangeScene(string SceneName)
    {
        nextSceneName = SceneName;
        mAnimator.Play("FadeIn");

        Invoke(nameof(ChangeScene), 1.5f);
    }

    //--------------------------------------------------

    public void ChangeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
