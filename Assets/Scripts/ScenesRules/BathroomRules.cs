using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomRules : MonoBehaviour
{
    [Header("Interacción de Toalla")]
    [SerializeField] private GameObject Visual_towel;
    [SerializeField] private GameObject Trigger_towel;
    [SerializeField] private GameObject VisualCue_towel;

    [Header("Salida")]
    [SerializeField] private Collider2D exitTrigger;

    [Header("Dialogo de Emma")]
    [SerializeField] private DialogueTrigger emmaDialogueTrigger;
    [SerializeField] private TextAsset inkNuggetSinToalla;
    [SerializeField] private TextAsset inkNuggetConToalla;

    [Header("Nugget")]
    [SerializeField] private playerController player;

    [Header("UI Animator")]
    [SerializeField] private Animator uiAnimator;


    //--------------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        //Desactivamos la Interaccion de Toalla
        Trigger_towel.SetActive(false);
        VisualCue_towel.SetActive(false);

        //Volvemos colision la salida para que no haga efecto
        exitTrigger.isTrigger = false;
    }

    //--------------------------------------------------------------

    void Update()
    {
        if (emmaDialogueTrigger != null)
        {
            if (player.HasObjectInMouth)
                emmaDialogueTrigger.inkJSON = inkNuggetConToalla;

            else
                emmaDialogueTrigger.inkJSON = inkNuggetSinToalla;
        }
        
    }

    //--------------------------------------------------------------

    public void EnableTowel()
    {
        //Activamos la Interacción con la toalla
        Trigger_towel.SetActive(true);
        VisualCue_towel.SetActive(true);
    }

    //--------------------------------------------------------------

    public void DisableTowel()
    {
        //Desactivamos la Toalla en su totalidad
        Visual_towel.SetActive(false);
        Trigger_towel.SetActive(false);
        VisualCue_towel.SetActive(false);
    }

    //--------------------------------------------------------------

    public void EnableExit()
    {
        exitTrigger.isTrigger = true;
    }

    //--------------------------------------------------------------

    public void TakeTowel()
    {
        //Desactivamos el Flag de objetos en el hocico
        player.HasObjectInMouth = false;

        uiAnimator.Play("TemporalFade");

        //Destruimos a Emma para simular que se ha ido
        Invoke(nameof(DestroyEmma), 2.5f);
    }

    //--------------------------------------------------------------

    private void DestroyEmma()
    {
        //Destruimos a Emma
        Destroy(emmaDialogueTrigger.transform.parent.gameObject);
    }
}
