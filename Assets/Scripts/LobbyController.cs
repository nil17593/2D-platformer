using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace OutScal.PlatFormer
{
    /// <summary>
    /// all the lobby actions are managed here
    /// we can select levels to play from here
    /// </summary>
    public class LobbyController : MonoBehaviour
    {
        [SerializeField] Button buttonPlay;
        public GameObject LevelSelection;
        private void Awake()
        {
            buttonPlay.onClick.AddListener(PlayGame);
        }

        private void PlayGame()
        {
            SoundManager.Instance.Play(Sounds.ButtonClick);
            LevelSelection.SetActive(true);
        }
    }
}