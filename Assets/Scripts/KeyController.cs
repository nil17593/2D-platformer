using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OutScal.PlatFormer
{
    /// <summary>
    /// whenever player will collide with key
    /// the key will gets destroy
    /// and player will get score of 10 points
    /// </summary>
    public class KeyController : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
                PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
                playerController.PickupKey();
                gameObject.SetActive(false);
            }
        }
    }
}