using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeJumpController : MonoBehaviour
{
    [SerializeField] private HUDController hudController;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(GoToBedRoomUnhealthy), 5f);
    }

    public void GoToBedRoomUnhealthy()
    {
        hudController.FadeInChangeScene("BEDROOMUNHEALTHY");
    }
}
