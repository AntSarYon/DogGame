using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuController : MonoBehaviour
{
    [Header("Panel de Creditos")]
    [SerializeField] private GameObject creditsPanel;

    [Header("Panel de Creditos")]
    [SerializeField] private GameObject settingsPanel;

    [Header("Clips de Audio")]
    [SerializeField] private AudioClip clipSelected;
    [SerializeField] private AudioClip clipClicked;

    [Header("Otros Componentes")]
    private AudioSource mAS;
    private Animator mAnimator;

    //------------------------------------------------------

    private void Awake()
    {
        //Obtenemos referencia a Componentes
        mAS = GetComponent<AudioSource>();
        mAnimator = GetComponent<Animator>();
    }

    //------------------------------------------------------

    void Start()
    {
        //Desactivamos el Panel de Creditos y Settings
        creditsPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    //------------------------------------------------------

    public void OpenCreditsPanel()
    {
        //Activamos el Panel de Creditos
        creditsPanel.SetActive(true);
    }

    //------------------------------------------------------

    public void CloseCreditsPanel()
    {
        //Desactivamos el Panel de Creditos
        creditsPanel.SetActive(false);
    }

    //------------------------------------------------------

    public void OpenSettingsPanel()
    {
        //Activamos el Panel de Creditos
        settingsPanel.SetActive(true);
    }

    //------------------------------------------------------

    public void CloseSettingsPanel()
    {
        //Desactivamos el Panel de Creditos
        settingsPanel.SetActive(false);
    }

    //------------------------------------------------------

    public void PlaySelected()
    {
        //Reproducimos Clip de Seleccion de boton
        mAS.PlayOneShot(clipSelected, 1f);
    }

    //------------------------------------------------------

    public void PlayClicked()
    {
        //Reproducimos Clip de Click de boton
        mAS.PlayOneShot(clipClicked, 1f);
    }

    //------------------------------------------------------

    public void StartGame()
    {
        //Reproducimos Animacion de FadeIn
        mAnimator.Play("PawIn");

        //Tras un breve delay, cambiamos a la iNTRO
        Invoke(nameof(ChangeToIntro), 2);
    }

    //------------------------------------------------------

    private void ChangeToIntro()
    {
        //Cambiamos a la escena de INTRO
        SceneManager.LoadScene("INTRO");
    }
}
