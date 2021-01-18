using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    TextMeshProUGUI _Lives;
    TextMeshProUGUI _Score;
    int CurrentScore;

    private void OnEnable()
    {
        SpawnManager.UpdateLives += UpdateUILives;
        Collectable.UpdateScoreUI += UpdateUIScore;
    }

    private void OnDisable()
    {
        SpawnManager.UpdateLives -= UpdateUILives;
        Collectable.UpdateScoreUI -= UpdateUIScore;
    }
    private void Start()
    {
        CurrentScore = 0;
        _Lives = GameObject.Find("TMP_Lives").GetComponent<TextMeshProUGUI>();
        _Lives.text = " ";
        _Score = GameObject.Find("TMP_Score").GetComponent<TextMeshProUGUI>();
        _Score.text = CurrentScore.ToString();
    }
    
    private void UpdateUILives(int m_Lives)
    {
        _Lives.text = m_Lives.ToString();
    }

    private void UpdateUIScore(int m_Score)
    {
        CurrentScore = CurrentScore + m_Score;
        _Score.text = CurrentScore.ToString();
    }

}
