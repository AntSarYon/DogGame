using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpZoneController : MonoBehaviour
{
    void Update()
    {
        //Si Nugget esta mirando para la izquierda
        if (!GetComponentInParent<SpriteRenderer>().flipX)
        {
            transform.position = new Vector3(-0.764999986f, 0.136999995f, 0);

            //Si hay un objeto como Hizo del PickUpZone...
            if (GetComponentInChildren<SpriteRenderer>() != null)
            {

            }
        }

        else
        {
            transform.position = new Vector3(0.763999999f, 0.136999995f, 0);

            //Si hay un objeto como Hizo del PickUpZone...
            if (GetComponentInChildren<SpriteRenderer>() != null)
            {

            }
        }
    }
}
