using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OutScal.PlatFormer
{
    /// <summary>
    /// this is level manager class
    /// all the levels are managed through this class
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        private static LevelManager instance;
        public static LevelManager Instance { get { return instance; } }
        [SerializeField] private string[] levels;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        //function for set 1st level always unlocked
        private void Start()
        {
            if (GetLevelStatus(levels[0]) == LevelStatus.Locked)
            {
                SetLevelStatus(levels[0], LevelStatus.Unlocked);
            }
        }

        //function for lock current level complete status
        public void MarkCurrentLevelComplete()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            //set level status to complete
            SetLevelStatus(currentScene.name, LevelStatus.Completed);

            int currentSceneIndex = Array.FindIndex(levels, level => level == currentScene.name);
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex < levels.Length)
            {
                SetLevelStatus(levels[nextSceneIndex], LevelStatus.Unlocked);
            }

        }

        //function for get level status
        public LevelStatus GetLevelStatus(string level)
        {
            LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
            return levelStatus;
        }

        //function for set level status
        public void SetLevelStatus(string level, LevelStatus levelStatus)
        {
            PlayerPrefs.SetInt(level, (int)levelStatus);
            Debug.Log("setting Level" + level + "Status" + levelStatus);
        }
        public enum LevelStatus
        {
            Locked,
            Unlocked,
            Completed,
        }
    }
}