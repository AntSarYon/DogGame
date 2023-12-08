using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchenRules : MonoBehaviour
{
    [Header("Interacción de vestido")]
    [SerializeField] private GameObject DI_Calendar;

    [Header("Sonido de Cocina")]
    [SerializeField] private AudioSource fryingAudioSource;

    void Start()
    {
        //Desactivamos la Interaccion del Calendario
        DI_Calendar.SetActive(false);
    }

    public void DisableCalendar()
    {
        DI_Calendar.SetActive(false);

        Invoke(nameof(GoToStudio), 3.5f);
    }

    public void EnableCalendar()
    {
        DI_Calendar.SetActive(true);
    }

    public void StopFryingSound()
    {
        fryingAudioSource.Stop();
    }

    public void GoToStudio()
    {
        FindObjectOfType<HUDController>().FadeInChangeScene("STUDIO");
    }
}
