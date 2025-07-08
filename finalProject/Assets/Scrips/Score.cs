using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    Text text;
    public static int currentScore = 0;
    void Start()
    {
        text=GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = currentScore.ToString();
    }
    public void UpdateScore()
    {
        currentScore+=1;
    }
    public int GetCurrentScore()
    {
        return currentScore;
    }
}
