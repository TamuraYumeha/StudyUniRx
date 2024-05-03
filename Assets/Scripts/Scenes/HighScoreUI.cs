using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text highscore = GetComponent<Text>();
        highscore.text = "HighScore:" + PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
