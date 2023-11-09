using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{
    public void Bind(Story story) //Puede agregarse otro parametro de ser necesario...
    {
        story.BindExternalFunction("ladrar", () =>
            ladrar()
            );

        //Se debera agregar uno nuevo por cada Funcion Externa creada
        /*
         story.BindExternalFunction("funcionEjemplo", (string parametroEjemploInk) => 
            FuncionEjemplo(parametroEjemploInk)
            );
         */

        /*
         story.BindExternalFunction("funcionEjemplo", (string parametroEjemploInk) => 
            FuncionEjemplo(parametroEjemploInk)
            );
         */

    }

    //--------------------------------------------------------------------------------------

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("ladrar");
    }

    #region External Functions INK

    public void ladrar()
    {
        //Disparamos el Trigger de la animacion de ladrar
        GameObject.Find("Player").GetComponent<Animator>().SetTrigger("Bark");
    }

    #endregion
}
