using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrysisRules : MonoBehaviour
{
    [SerializeField] private HUDController controller;

    void Start()
    {
        Invoke(nameof(PasarATimeJump), 6f);
    }

    public void PasarATimeJump()
    {
        controller.FadeInChangeScene("TIMEJUMP");
    }
}
