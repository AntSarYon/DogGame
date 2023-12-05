using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    [Header("Nombre de la siguiente escena")]
    [SerializeField] string nameNextScene;

    //----------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            FindObjectOfType<HUDController>().FadeInChangeScene(nameNextScene);
        }
    }
}
