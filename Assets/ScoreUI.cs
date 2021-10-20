using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI instance;
    void Awake() => instance = this;

    int score;
    Text scoreText;
    void Start()
    {
        scoreText = transform.Find("Text").GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    internal void AddScore(int addValue)
    {
        score += addValue;
        scoreText.text = score.ToString();
    }
}
