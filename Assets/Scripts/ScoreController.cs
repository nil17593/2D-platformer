using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace OutScal.PlatFormer
{
    /// <summary>
    /// score is managed by this class
    /// if player collects keys player rewarded with 10 points for each key
    /// </summary>
    public class ScoreController : MonoBehaviour
    {
        private TextMeshProUGUI scoreText;

        private int score = 0;

        private void Awake()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }
        private void Start()
        {
            RefreshUI();
        }

        //the score will increase by 10 points after each key collect
        public void IncreaseScore(int increament)
        {
            score += increament;
            RefreshUI();
        }

        private void RefreshUI()
        {
            scoreText.text = "Score: " + score;
        }
    }
}