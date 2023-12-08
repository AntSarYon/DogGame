using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudioRules : MonoBehaviour
{
    [Header("Nugget")]
    [SerializeField] private playerController player;

    private bool objectiveAccomplished;
    private float timeSitting;

    //------------------------------------------------------------

    private void Start()
    {
        objectiveAccomplished = false;
        timeSitting = 0;
    }

    //------------------------------------------------------------

    // Update is called once per frame
    void Update()
    {
        if (!objectiveAccomplished)
        {
            if (player.isSitting)
            {
                timeSitting += Time.deltaTime;

                if (timeSitting >= 4)
                {
                    GoToLivingRoom();
                    objectiveAccomplished=true;
                }
            }
        }
        
    }

    //------------------------------------------------------------

    public void GoToLivingRoom()
    {
        FindObjectOfType<HUDController>().FadeInChangeScene("LIVINGROOM");
    }
}
