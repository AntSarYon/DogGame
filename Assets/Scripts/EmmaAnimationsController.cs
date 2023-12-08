using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmmaAnimationsController : MonoBehaviour
{
    [SerializeField] private Animator mAnimator;

    [SerializeField] private AudioClip clipWP;

    //------------------------------------------------

    public void StartCrying()
    {
        mAnimator.Play("Crying");
    }

    public void StartCryingWithMedicine()
    {
        mAnimator.Play("CryingWithMedicine");
    }

    public void StartLookingDown()
    {
        mAnimator.Play("LookingDown");
    }

    public void StartLookingLeft()
    {
        mAnimator.Play("LookingLeft");
    }

    public void StartLookingRight()
    {
        mAnimator.Play("LookingRight");
    }

    public void StartLookingUp()
    {
        mAnimator.Play("LookingUp");
    }

    public void StartSit()
    {
        mAnimator.Play("Sit");
    }

    public void StartWalkingDown()
    {
        mAnimator.Play("walkingDown");
    }

    public void StartWalkingLeft()
    {
        mAnimator.Play("walkingLeft");
    }

    public void StartWalkingRight()
    {
        mAnimator.Play("walkingRight");
    }

    public void StartWalkingUp()
    {
        mAnimator.Play("walkingUp");
    }

    public void PlayWpNotification()
    {
        GetComponent<AudioSource>().PlayOneShot(clipWP, 1f);
    }

    public void StopBackgroundMusic()
    {
        Destroy(GameObject.Find("BackgroundMusic"));
    }

    public void ShowNotification()
    {
        FindObjectOfType<HUDController>().FadeInChangeScene("NOTIFICATION");
    }

}
