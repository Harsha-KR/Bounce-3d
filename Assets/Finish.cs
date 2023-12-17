using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Scene scene = SceneManager.GetActiveScene();
            if(scene.buildIndex +1 > (SceneManager.sceneCountInBuildSettings - 1))
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(scene.buildIndex + 1);
            }
        }
    }
}
