using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    TextMeshProUGUI _Lives;
    TextMeshProUGUI _Score;
    int CurrentScore;

   
    private void Start()
    {
        CurrentScore = 0;
        _Lives = GameObject.Find("TMP_Lives").GetComponent<TextMeshProUGUI>();
        _Lives.text = " ";
        _Score = GameObject.Find("TMP_Score").GetComponent<TextMeshProUGUI>();
        _Score.text = CurrentScore.ToString();
    }

    
    public void UpdateUILives(int other)
    {
        _Lives = GameObject.Find("TMP_Lives").GetComponent<TextMeshProUGUI>();
        _Lives.text = "abc";
    }

    public void UpdateUIScore(int m_Score)
    {
        CurrentScore = CurrentScore + m_Score;
        _Score.text = CurrentScore.ToString();
    }

}
