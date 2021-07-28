using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace OutScal.PlatFormer
{
    /// <summary>
    ///all animations and player movement is set in this class
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [Header("player animator variables")]
        [SerializeField] private Animator animator;
        [SerializeField] private float speed;
        [SerializeField] private float jump;
        [SerializeField] private float groundVelocity;
        [SerializeField] private float jumpVelocity;
        [SerializeField] private float jumpFallVelocity;

        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask grounLayer;
        private bool isGrounded;
        

        [Header("rigidbody and box colliders")]
        Rigidbody2D rb2d;
        BoxCollider2D boxCollider2D;

        [Header("Collider position")]
        [SerializeField] private Vector2 crouchoffset;
        [SerializeField] private Vector2 crouchsize;
        [SerializeField] private Vector2 offset;
        [SerializeField] private Vector2 size;

        [Header("palyer scores and life")]
        [SerializeField] private int score;
        [SerializeField] private Image[] hearts;
        [SerializeField] private int livesRemain = 1;
        [SerializeField] private ScoreController scoreController;
        [SerializeField] private string reloadCurrentScene;
        [SerializeField] private GameOverController gameOverController;
        private bool gameOver;

        void Awake()
        {
            rb2d = gameObject.GetComponent<Rigidbody2D>();
            boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        }
        private void FixedUpdate()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, grounLayer);
        }
        //update function
        void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Jump");
            PlayerMovementAnimation(horizontal);
            PlayerJumpAnimation(vertical);
            MoveCharacter(horizontal, vertical);
            PlayerCrouchAnimation();
        }
  
        //player pick key and increase score function
        public void PickupKey()
        {
            Debug.Log("picked up the key");
            SoundManager.Instance.PlayMusic(Sounds.CollectItems);
            scoreController.IncreaseScore(score);
        }
        //player died function
        public void KillPlayer()
        {
            livesRemain--;
            transform.position = new Vector2(0,0);
            UpdateLifeUI();
            if (gameOver == true)
            {
                gameOverController.PlayerDied();
            }
        }
        //reload current scene
        private void ReloadScene()
        {
            SceneManager.LoadScene(reloadCurrentScene);
        }

        //horizontal movement function
        private void PlayerMovementAnimation(float horizontal)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            Vector2 scale = transform.localScale;
            if (horizontal < 0 )
            {
                scale.x = -1f * Mathf.Abs(scale.x);
            }
            else if (horizontal > 0 )
            {
                scale.x = Mathf.Abs(scale.x);
            }
            transform.localScale = scale;
        }

        //jump animation function
        private void PlayerJumpAnimation(float vertical)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                SoundManager.Instance.PlayMusic(Sounds.PlayerJump);
                animator.SetBool("Jump", true);              
                rb2d.velocity = new Vector2(groundVelocity, jumpVelocity);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                SoundManager.Instance.PlayMusic(Sounds.PlayerLand);
                animator.SetBool("Jump", false);
                rb2d.velocity = new Vector2(groundVelocity, jumpFallVelocity);
            }
        }

        //player movement function
        private void MoveCharacter(float horizontal, float verticle)
        {
            // Move character horizontally
            Vector2 position = transform.position;
            position.x += horizontal * speed * Time.deltaTime;
            transform.position = position;

            // Move character vertically
            if (verticle > 0)
            {
                rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
            }
        }

        //the function manages the life of player
        private void UpdateLifeUI()
        {
            hearts[livesRemain].gameObject.SetActive(false);

            if (livesRemain == 0)
            {
                hearts[livesRemain].gameObject.SetActive(false);
                gameOver = true;
            }
        }
         
        //crouch animation function
        private void PlayerCrouchAnimation()
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                SoundManager.Instance.Play(Sounds.PlayerCrouch);
                animator.SetBool("IsCrouch", true);
                boxCollider2D.offset = new Vector2(crouchoffset.x, crouchoffset.y);
                boxCollider2D.size = new Vector2(crouchsize.x, crouchsize.y);
            }
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                animator.SetBool("IsCrouch", false);
                boxCollider2D.offset = new Vector2(offset.x,offset.y);
                boxCollider2D.size = new Vector2(size.x, size.y);
            }
        }
        
    }
}
