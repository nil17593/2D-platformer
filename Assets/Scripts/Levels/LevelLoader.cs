using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static OutScal.PlatFormer.LevelManager;

namespace OutScal.PlatFormer
{
    /// <summary>
    /// the class is for load different levels in the game
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] Button button;
        [SerializeField] string levelName;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnCliCk);

        }

        //function for different button operations
        private void OnCliCk()
        {
            LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);

            switch (levelStatus)
            {
                case LevelStatus.Locked:
                    Debug.Log("cant load level is locked");
                    break;

                case LevelStatus.Unlocked:
                    SoundManager.Instance.Play(Sounds.ButtonClick);
                    SceneManager.LoadScene(levelName);
                    break;

                case LevelStatus.Completed:
                    SoundManager.Instance.Play(Sounds.ButtonClick);
                    SceneManager.LoadScene(levelName);
                    break;
            }
        }
    }
}