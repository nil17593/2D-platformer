using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OutScal.PlatFormer 
{
    /// <summary>
    /// player will die after falling from platform
    /// </summary>
    public class PlayerDeadControlller : MonoBehaviour
    {
        [SerializeField] private GameOverController gameOverController;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
                gameOverController.PlayerDied();
            }
        }
    }
}