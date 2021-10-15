using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lives : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _Text;
    private SpawnManager _Lives;

    private void Start()
    {
        _Lives = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        LivesUIUpdate();
    }

    private void Update()
    {
        LivesUIUpdate();
    }
    public void LivesUIUpdate()
    {
        //Debug.Log("Lives Updated in the UI");
        _Text.text = "Lives: " + _Lives.Lives.ToString() ;
    }


}
