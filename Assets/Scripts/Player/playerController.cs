using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //Componentes
    private Animator mAnimator;
    private Rigidbody2D mRb;
    private SpriteRenderer mSpriteRenderer;
    private AudioSource mAudioSource;

    //Velocidad de movimiento
    private float speed = 4f;
    private float sprintMultiplier = 1;

    //Variables de estado
    private bool isBarking = false;
    public bool isSitting = false;

    [SerializeField] private GameObject PickUpZoneRight;
    [SerializeField] private GameObject PickUpZoneLeft;

    private bool hasObjectInMouth;

    public bool HasObjectInMouth { get => hasObjectInMouth; set => hasObjectInMouth = value; }

    //--------------------------------------------------------------

    private void Awake()
    {
        //Obtenemos referencia a componentes
        mAnimator = GetComponent<Animator>();
        mRb = GetComponent<Rigidbody2D>();
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        mAudioSource = GetComponent<AudioSource>();

        //Inicialmente no tiene nada en la Boca
        hasObjectInMouth = false;
    }

    //--------------------------------------------------------------

    private void Start()
    {
        //Desactivamos ambos PickupsZones
        PickUpZoneLeft.SetActive(false);
        PickUpZoneRight.SetActive(false);
    }

    //--------------------------------------------------------------

    private void FixedUpdate()
    {
        //Si no estamos ni sentados, ni ladrando...
        if (!isSitting && !isBarking)
        {
            //Habilitamos el Movimiento del RigidBody a una nueva posicion 
            ControlMove();
        }
        
    }

    //--------------------------------------------------------------

    private void ControlMove()
    {
        //Si No hay un dialogo en progreso
        if (!DialogueManager.Instance.dialogueIsPlaying)
        {
            //Si se esta recibiendo una direccion de movimiento,
            if (InputManager.Instance.GetMoveDirection() != Vector2.zero)
            {
                //Mantenemos activado el flag de animacion de "Moviendose"
                mAnimator.SetBool("Moving", true);

                mRb.MovePosition(
                    transform.position + // <-- Tomamos como base su ubicacion actual
                    new Vector3(
                        //Agregamos valor en base a los Inputs de movimiento
                        InputManager.Instance.GetMoveDirection().x,
                        InputManager.Instance.GetMoveDirection().y,
                        0) * speed * sprintMultiplier * Time.fixedDeltaTime // <-- Multiplicamos en base a la velocidad y al Tiempo Delta
                    );
            }
            else
                //Caso contrario desactivamos el flag...
                mAnimator.SetBool("Moving", false);
        }
        
        else
            //Caso contrario desactivamos el flag...
            mAnimator.SetBool("Moving", false);
        
        
    }

    //--------------------------------------------------------------

    void Update()
    {
        ManageDirection();

        ManagePickUpBoxes();

        //Si se ha oprimido la accion de Ladrar
        if (InputManager.Instance.GetBarkPressed())
        {
            //Si no estamos ladrando
            if (!isBarking)
            {
                //Activamos el Flag de Ladrando
                isBarking = true;

                //Disparamos el trigger de la animación de Ladrido
                mAnimator.SetTrigger("Bark");

                Invoke(nameof(EndOfBarking), 0.8f);
            }
        }

        //Si se ha oprimido la accion de Sentarse
        if (InputManager.Instance.GetSitPressed())
        {
            //Si no estamos ladrando
            if (!isSitting)
            {
                //Activamos el Flag de Ladrando
                isSitting = true;

                //Disparamos el trigger de la animación de Sentarse
                mAnimator.SetTrigger("Sit");
            }
            //Si ya está sentado
            else
                //Disparamos el trigger de la animación de Levantarse
                mAnimator.SetTrigger("GetUp");
        }

        //Si se esta oprimiendo la accion de Sprint
        if (InputManager.Instance.GetSprintPressed())
        {
            //El multiplicador de Sprint sube a 2
            sprintMultiplier = 1.5f;
            //Activamos el Flag de "Sprintando"
            mAnimator.SetBool("Sprinting", true);
        }
        else
        {
            //Sino, se mantiene en 1
            sprintMultiplier = 1;
            //Desactivamos el Flag de "Sprintando"
            mAnimator.SetBool("Sprinting", false);
        }
    }

    //----------------------------------------------------------------------------------------------

    public void ManagePickUpBoxes()
    {
        //Si tiene objetos en la boca...
        if (hasObjectInMouth)
        {
            //Si esta viendo a la derecha...
            if (mSpriteRenderer.flipX == true)
            {
                PickUpZoneRight.SetActive(true);
                PickUpZoneLeft.SetActive(false);
            }
            else
            {
                PickUpZoneRight.SetActive(false);
                PickUpZoneLeft.SetActive(true);
            }
        }

        //Si no tiene objetos en la boca...
        else
        {
            //Ambos PickupObjexts estaran desactivados
            PickUpZoneRight.SetActive(false);
            PickUpZoneLeft.SetActive(false);
        }
    }

    //----------------------------------------------------------------------------------------------

    public void PlayBark()
    {
        mAudioSource.Play();
    }

    //--------------------------------------------------------------

    #region CONTROL DE ANIMACIONES

    //--------------------------------------------------------------
    //FUNCION: Indicar Fin de animacion de Ladrido y desactivación de Flag
    public void EndOfBarking()
    {
        //Desactivamos el flag de "Ladrando"
        isBarking = false;
    }

    //--------------------------------------------------------------
    //FUNCION: Indicar Fin del estado Sentado desactivando el Flag
    public void EndOfSitting()
    {
        //Desactivamos el flag de "Ladrando"
        isSitting = false;
    }

    //--------------------------------------------------------------
    //FUNCION: Manejar la direccion en la que MIRA el Sprite
    private void ManageDirection()
    {
        //Si no se esta reproduciendo dialogo
        if (!DialogueManager.Instance.dialogueIsPlaying)
        {
            //Si el input de movimiento indica que se mueve a la derecha
            if (InputManager.Instance.GetMoveDirection().x > 0)
                //Invertimos el Sprite
                mSpriteRenderer.flipX = true;

            else if (InputManager.Instance.GetMoveDirection().x < 0)
                //Mostramos el Sprite en su direccion original 
                mSpriteRenderer.flipX = false;

            else
                //Lo mantenemos como esta
                mSpriteRenderer.flipX = mSpriteRenderer.flipX;
        }
        
    }

    #endregion
}
