using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    //Vector de direccion de movimiento inicializado en 0
    private Vector2 moveDirection = Vector2.zero;

    //Flags de acciones oprimidas inicializados en FALSO
    private bool sitPressed = false;
    private bool barkPressed = false;
    private bool sprintPressed = false;
    private bool interactPressed = false;
    public bool submitPressed = false;

    //------------------------------------------------------------------------------

    private void Awake()
    {
        //Asignamos el actual Script como la unica Instancia
        Instance = this;

    }

    #region INPUT CAPTURES

    //--------------------------------------------------------------------------------------------
    //FUCION: DETECCION DE INTERACCION CON Input de "Movimiento" (Recibe CONTEXTO de la interaccion)
    public void MovePressed(InputAction.CallbackContext context)
    {
        //Si la interaccion es "Oprimido"
        if (context.performed)
        {
            //Capturamos el movimiento en X del Vector 2 fruto del Input de moviminto
            moveDirection = new Vector2(
                context.ReadValue<Vector2>().x, 
                0);
        }
        //Si la interaccion es "Cancelado o Soltado"
        else if (context.canceled)
        {
            //Capturamos el movimiento en X del Vector 2 fruto del Input de moviminto
            moveDirection = new Vector2(
                context.ReadValue<Vector2>().x,
                0);
        }
    }

    //--------------------------------------------------------------------------------------------
    //FUCION: DETECCION DE INTERACCION CON Input de "LADRAR" (Recibe CONTEXTO de la interaccion)
    public void BarkPressed(InputAction.CallbackContext context)
    {
        //Si la interaccion es "Oprimido"
        if (context.performed)
        {
            //Activamos el Flag de Ladrido Orpimido
            barkPressed = true;
        }

        //Si la interaccion es "Cancelado o Soltado"
        else if (context.canceled)
        {
            //Desactivamos el Flag de Ladrido Oprimido
            barkPressed = false;
        }
    }

    //--------------------------------------------------------------------------------------------
    //FUCION: DETECCION DE INTERACCION CON Input de "SENTARSE" (Recibe CONTEXTO de la interaccion)
    public void SitPressed(InputAction.CallbackContext context)
    {
        //Si la interaccion es "Oprimido"
        if (context.performed)
        {
            //Activamos el Flag de Sentarse Orpimido
            sitPressed = true;
        }

        //Si la interaccion es "Cancelado o Soltado"
        else if (context.canceled)
        {
            //Desactivamos el Flag de Sentarse Oprimido
            sitPressed = false;
        }
    }

    //--------------------------------------------------------------------------------------------
    //FUCION: DETECCION DE INTERACCION CON Input de "Sprintar / Correr" (Recibe CONTEXTO de la interaccion)
    public void SprintPressed(InputAction.CallbackContext context)
    {
        //Si la interaccion es "Oprimido"
        if (context.performed)
        {
            //Activamos el Flag de Sprint Orpimido
            sprintPressed = true;
        }

        //Si la interaccion es "Cancelado o Soltado"
        else if (context.canceled)
        {
            //Desactivamos el Flag de Sprint Orpimido
            sprintPressed = false;
        }
    }

    //--------------------------------------------------------------------------------------------
    //FUCION: DETECCION DE INTERACCION CON Input de "INTERACTUAR" (Recibe CONTEXTO de la interaccion)
    public void InteractPressed(InputAction.CallbackContext context)
    {
        //Si la interaccion es "Oprimido"
        if (context.performed)
        {
            //Activamos el Flag de Interaccion Orpimida
            interactPressed = true;
        }

        //Si la interaccion es "Cancelado o Soltado"
        else if (context.canceled)
        {
            //Desactivamos el Flag de Interaccion Orpimida
            interactPressed = false;
        }
    }

    //--------------------------------------------------------------------------------------------
    //FUCION: DETECCION DE INTERACCION CON Input de "SUBMIT" (Recibe CONTEXTO de la interaccion)
    public void SubmitPressed(InputAction.CallbackContext context)
    {
        //Si la interaccion es "Oprimido"
        if (context.performed)
        {
            //Activamos el Flag de Interaccion Orpimida
            submitPressed = true;
        }

        //Si la interaccion es "Cancelado o Soltado"
        else if (context.canceled)
        {
            //Desactivamos el Flag de Interaccion Orpimida
            submitPressed = false;
        }
    }

    #endregion

    //----------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------

    #region INPUTS GETTERS

    //FUNCION: Retornar Direccion de movimiento
    public Vector2 GetMoveDirection()
    {
        //Retornamos la Direccion de movimiento
        return moveDirection;
    }

    //-------------------------------------------------------------------------------

    //FUNCION: Retornar Flag de "LADRAR" oprimido 
    public bool GetBarkPressed()
    {
        //Inicializamos el resultado con el Valor actual del Flag
        bool result = barkPressed;

        //Desactivamos el Flag de accion para que no se detecte como (Mantenido)
        barkPressed = false;

        //Devolvemos el resultado
        return result;
    }

    //-------------------------------------------------------------------------------

    //FUNCION: Retornar Flag de "SENTARSE" oprimido 
    public bool GetSitPressed()
    {
        //Inicializamos el resultado con el Valor actual del Flag
        bool result = sitPressed;

        //Desactivamos el Flag de accion para que no se detecte como (Mantenido)
        sitPressed = false;

        //Devolvemos el resultado
        return result;
    }

    //-------------------------------------------------------------------------------

    //FUNCION: Retornar Flag de "SPRINTAR" oprimido 
    public bool GetSprintPressed()
    {
        //Devolvemos el flag directamente
        return sprintPressed;
    }
    //-------------------------------------------------------------------------------

    //FUNCION: Retornar Flag de "INTERACTUAR" oprimido 
    public bool GetInteractPressed()
    {
        //Inicializamos el resultado con el Valor actual del Flag
        bool result = interactPressed;

        //Desactivamos el Flag de accion para que no se detecte como (Mantenido)
        interactPressed = false;

        //Devolvemos el resultado
        return result;
    }

    //-------------------------------------------------------------------------------

    //FUNCION: Retornar Flag de "CONTINUAR" oprimido 
    public bool GetSubmitPressed()
    {
        //Inicializamos el resultado con el Valor actual del Flag
        bool result = submitPressed;

        //Desactivamos el Flag de accion para que no se detecte como (Mantenido)
        submitPressed = false;

        //Devolvemos el resultado
        return result;
    }

    // FUNCION: Desactivar Flag de Submit
    public void RegisterSubmitPressed()
    {
        //Desactivamos el Flag de Submi Presionado
        submitPressed = false;
    }

    #endregion

}
