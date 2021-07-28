using UnityEngine;

namespace OutScal.PlatFormer
{
    /// <summary>
    /// class is for camera control 
    /// camera will follow the Player throughout the game
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float smoothFactor;

        private void LateUpdate()
        {
            FollowPlayer();
        }

        //function for follow player by the camera
        private void FollowPlayer()
        {
            Vector3 targetPosition = target.position + offset;
            Vector3 smothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.deltaTime);
            transform.position = targetPosition;
        }
    }
}