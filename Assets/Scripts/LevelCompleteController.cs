using UnityEngine;
using UnityEngine.SceneManagement;

namespace OutScal.PlatFormer
{
    /// <summary>
    /// if level is completed by the player this class will call
    /// </summary>
    public class LevelCompleteController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {          
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
                PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
                LevelManager.Instance.MarkCurrentLevelComplete();
                SoundManager.Instance.PlayMusic(Sounds.LevelComplete);
                SceneManager.LoadScene("LevelComplete");
            }
        }
    }
}