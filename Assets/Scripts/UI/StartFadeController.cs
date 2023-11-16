using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartFadeController : MonoBehaviour
{
    private Animator mAnimator;

    //--------------------------------------------------

    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
    }

    //--------------------------------------------------

    void Start()
    {
        //Creamos un Delegado para cuando se Descargue una Escena.
        SceneManager.sceneUnloaded += SceneUnloadedDelegate;
    }

    //--------------------------------------------------

    private void SceneUnloadedDelegate(Scene sceneUnloaded)
    {
        //Si la escena de la cual venimos no es el menu principal
        if (sceneUnloaded.name != "MENU")
        {
            //Reproducimos el Default --> No hay FadeOut
            mAnimator.Play("default");
        }
    }
}
