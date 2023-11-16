using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonDestroyOnLoad : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
