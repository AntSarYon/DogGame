using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroRules : MonoBehaviour
{

    [Header("Interacción de vestido")]
    [SerializeField] private GameObject DI_dress;

    [Header("Salida")]
    [SerializeField] private Collider2D exitTrigger;

    //----------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        //Desactivamos la Interaccion de Vestido
        DI_dress.SetActive(false);

        //Volvemos colision la salida para que no haga efecto
        exitTrigger.isTrigger = false;
    }

    //----------------------------------------------------

    public void DisableDress()
    {
        DI_dress.SetActive(false);
    }

    public void EnableDress()
    {
        DI_dress.SetActive(true);
    }

    public void EnableExit()
    {
        exitTrigger.isTrigger = true;
    }
}
