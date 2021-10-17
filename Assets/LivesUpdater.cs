using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUpdater : MonoBehaviour
{
    int lives;
    public TextMeshProUGUI text;

    private void Start()
    {
        StartCoroutine(UpdateLivesUI());
    }
    public IEnumerator UpdateLivesUI()
    {
        while (true)
        {
            yield return new WaitForSeconds(.5f);
            lives = SpawnManager._Instance.lives;
            text.text = "Lives: " + lives;
        }
    }
}
