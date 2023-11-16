using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicInstance : MonoBehaviour
{
    public static BGMusicInstance Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
