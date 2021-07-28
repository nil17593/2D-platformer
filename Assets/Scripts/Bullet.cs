using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OutScal.PlatFormer
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] EnemyController enemyController;
        [SerializeField] int damage;
        public new Rigidbody2D rigidbody2D;
        void Start()
        {
            rigidbody2D.velocity = transform.right * speed;
        }

        void OnTriggerEnter2D(Collider2D hitImpact)
        {
            Debug.Log(hitImpact.name);
            enemyController = hitImpact.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.TakeDamage(damage);
                
            }
            Destroy(gameObject);
        }
    }
}