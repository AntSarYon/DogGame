using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationController : MonoBehaviour
{

    [SerializeField] private HUDController hudController;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(GoToCrysis), 9f);
    }

    public void GoToCrysis()
    {
        hudController.FadeInChangeScene("CRYSIS");
    }
}
