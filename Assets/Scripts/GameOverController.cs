using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace OutScal.PlatFormer
{
    /// <summary>
    /// this class has game over logic whenever player dies the game over screen will load
    /// different sound clips are added
    /// </summary>
    public class GameOverController : MonoBehaviour
    {
        [SerializeField] private string loadLobbyScene;
        [SerializeField] private Button buttonRestart;
        [SerializeField] private Button buttonLobby;
        private void Awake()
        {
            buttonRestart.onClick.AddListener(RealoadScene);
            buttonLobby.onClick.AddListener(LobbyScene);
        }
        //function for load lobby scene
        private void LobbyScene()
        {
            SceneManager.LoadScene("Lobby");       
        }
        //after collide with enemy player will died
        public void PlayerDied()
        {
            SoundManager.Instance.PlayMusic(Sounds.PlayerDeath);
            gameObject.SetActive(true);
        }
        //to reload current scene
        public void RealoadScene()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex);
        }
    }
}