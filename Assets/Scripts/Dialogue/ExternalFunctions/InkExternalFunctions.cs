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

        story.BindExternalFunction("IntroEmmaWalkAway", () =>
            IntroEmmaWalkAway()
            );

        story.BindExternalFunction("EnableDress", () =>
            EnableDress()
            );
        story.BindExternalFunction("OpenIntroDoor", () =>
            OpenIntroDoor()
            );
        story.BindExternalFunction("EnableTowel", () =>
            EnableTowel()
            );
        story.BindExternalFunction("OpenBathroomDoor", () =>
            OpenBathroomDoor()
            );
        story.BindExternalFunction("TakeTowel", () =>
            TakeTowel()
            );
        story.BindExternalFunction("BathroomEmmaLookLeft", () =>
            BathroomEmmaLookLeft()
            );
        story.BindExternalFunction("EnableCalendar", () =>
            EnableCalendar()
            );
        story.BindExternalFunction("KitchennEmmaRetire", () =>
            KitchennEmmaRetire()
            );
        story.BindExternalFunction("KitchennEmmaWalkAndLook", () =>
            KitchennEmmaWalkAndLook()
            );
        story.BindExternalFunction("KitchennEmmaLookLeft", () =>
            KitchennEmmaLookLeft()
            );
        story.BindExternalFunction("StopFryingSound", () =>
            StopFryingSound()
            );
        story.BindExternalFunction("DisableCalendar", () =>
            DisableCalendar()
            );

    }

    //--------------------------------------------------------------------------------------

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("ladrar"); 
        story.UnbindExternalFunction("IntroEmmaWalkAway");
        story.UnbindExternalFunction("EnableDress");
        story.UnbindExternalFunction("OpenIntroDoor");
        story.UnbindExternalFunction("EnableTowel");
        story.UnbindExternalFunction("OpenBathroomDoor");
        story.UnbindExternalFunction("TakeTowel");
        story.UnbindExternalFunction("BathroomEmmaLookLeft");
        story.UnbindExternalFunction("EnableCalendar");
        story.UnbindExternalFunction("DisableCalendar");
        story.UnbindExternalFunction("KitchennEmmaRetire");
        story.UnbindExternalFunction("KitchennEmmaWalkAndLook");
        story.UnbindExternalFunction("KitchennEmmaLookLeft");
        story.UnbindExternalFunction("StopFryingSound");
    }

    #region External Functions INK

    public void ladrar()
    {
        //Disparamos el Trigger de la animacion de ladrar
        GameObject.Find("PlayerNugget").GetComponent<Animator>().SetTrigger("Bark");
    }

    // - - -- - - - - - - - - - - - - - - - - - - - - - - - - - - - -- - - - - - - - - - -

    public void IntroEmmaWalkAway()
    {
        GameObject Emma = GameObject.Find("NpcEmma");

        //Convertimos el collider de Emma en Trigger
        Emma.GetComponentInChildren<BoxCollider2D>().isTrigger = true;

        //Disparamos su animacion de Irse.
        Emma.GetComponent<Animator>().Play("WalkAway");
    }

    // - - -- - - - - - - - - - - - - - - - - - - - - - - - - - - - -- - - - - - - - - - -

    public void EnableDress()
    {
        GameObject.FindObjectOfType<IntroRules>().EnableDress();
    }

    // - - -- - - - - - - - - - - - - - - - - - - - - - - - - - - - -- - - - - - - - - - -

    public void OpenIntroDoor()
    {
        GameObject.FindObjectOfType<IntroRules>().EnableExit();
        GameObject.FindObjectOfType<IntroRules>().DisableDress();
    }
    // - - -- - - - - - - - - - - - - - - - - - - - - - - - - - - - -- - - - - - - - - - -
    public void EnableTowel()
    {
        GameObject.FindObjectOfType<BathroomRules>().EnableTowel();
    }
    // - - -- - - - - - - - - - - - - - - - - - - - - - - - - - - - -- - - - - - - - - - -
    public void OpenBathroomDoor()
    {
        GameObject.FindObjectOfType<BathroomRules>().EnableExit();
    }

    // - - -- - - - - - - - - - - - - - - - - - - - - - - - - - - - -- - - - - - - - - - -
    public void TakeTowel()
    {
        GameObject.FindObjectOfType<BathroomRules>().TakeTowel();
    }

    // - - -- - - - - - - - - - - - - - - - - - - - - - - - - - - - -- - - - - - - - - - -

    public void BathroomEmmaLookLeft()
    {
        GameObject Emma = GameObject.Find("NpcEmma");

        //Disparamos su animacion de Mirar a la Izquierda.
        Emma.GetComponent<Animator>().Play("LookingLeft");
    }

    public void EnableCalendar()
    {
        GameObject.FindObjectOfType<kitchenRules>().EnableCalendar();
    }

    public void DisableCalendar()
    {
        GameObject.FindObjectOfType<kitchenRules>().DisableCalendar();
    }

    public void StopFryingSound()
    {
        GameObject.FindObjectOfType<kitchenRules>().StopFryingSound();
    }

    public void KitchennEmmaLookLeft()
    {
        GameObject Emma = GameObject.Find("NpcEmma");

        //Convertimos el collider de Emma en Trigger
        //Emma.GetComponentInChildren<BoxCollider2D>().isTrigger = true;

        //Disparamos su animacion de Irse.
        Emma.GetComponent<Animator>().Play("LookLeft");
    }

    public void KitchennEmmaWalkAndLook()
    {
        GameObject Emma = GameObject.Find("NpcEmma");

        //Convertimos el collider de Emma en Trigger
        //Emma.GetComponentInChildren<BoxCollider2D>().isTrigger = true;

        //Disparamos su animacion de Irse.
        Emma.GetComponent<Animator>().Play("WalkAndLook");
    }

    public void KitchennEmmaRetire()
    {
        GameObject Emma = GameObject.Find("NpcEmma");

        //Convertimos el collider de Emma en Trigger
        //Emma.GetComponentInChildren<BoxCollider2D>().isTrigger = true;

        //Disparamos su animacion de Irse.
        Emma.GetComponent<Animator>().Play("Retire");
    }

    #endregion
}
