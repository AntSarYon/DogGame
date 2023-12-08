using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{
    private Animator mAnimator;

    private AudioSource mAudioSource;
    [SerializeField] private AudioClip clipShower;

    [HideInInspector] public string nextSceneName;

    //--------------------------------------------------

    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
        mAudioSource = GetComponent<AudioSource>();
    }

    //--------------------------------------------------

    public void FadeInChangeScene(string SceneName)
    {
        nextSceneName = SceneName;
        mAnimator.Play("FadeIn");

        Invoke(nameof(ChangeScene), 1.5f);
    }

    //--------------------------------------------------

    public void PlayShower()
    {
        mAudioSource.PlayOneShot(clipShower,0.85f);
    }

    //--------------------------------------------------

    public void ChangeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
