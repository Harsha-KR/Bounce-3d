using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUIUpdater : MonoBehaviour
{
    int score;
    public TextMeshProUGUI text;

    private void Start()
    {
        StartCoroutine(UpdateScoreUI());
    }
    public IEnumerator UpdateScoreUI()
    {
        while (true)
        {
            yield return new WaitForSeconds(.5f);
            score = SpawnManager._Instance.score;
            text.text = "Score: " + score;
        }
    }
}
