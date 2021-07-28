using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace OutScal.PlatFormer
{
    /// <summary>
    /// this class will load next level after completing one level
    /// </summary>
    public class NextLevelController : MonoBehaviour
    {
        [SerializeField] private Button buttonMenu;
        [SerializeField] private Button buttonNextLevel;

        private void Awake()
        {
            buttonMenu.onClick.AddListener(LobbyScene);
            buttonNextLevel.onClick.AddListener(LoadNextScene);
        }

        //load lobby scene 
        private void LobbyScene()
        {
            SceneManager.LoadScene("Lobby");
        }

        //load next level after completing one level
        public void LoadNextScene()
        {
            SceneManager.LoadScene("Level2");
        }
    }
}