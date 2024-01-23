using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PinBall
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private int forceValue;
        [SerializeField] private int minForce;
        [SerializeField] private int maxForce;
        [SerializeField] private float randomX;
        [SerializeField] private float randomX1;
        [SerializeField] private float randomX2;
        [SerializeField] private Collider2D ballCollider;
        [SerializeField] private Vector3 startPos;
        private float verticalVelocity;
        private float startBounciness;
        // Start is called before the first frame update
        void Start()
        {
            startBounciness = ballCollider.sharedMaterial.bounciness;
             startPos = new Vector3(0f, -21.8f, 0f);
            
        }
        private void Update()
        {
            verticalVelocity = rb.velocity.y;
            if (Random.Range(0, 2) == 0)
            {
                randomX = randomX1;
            }
            else
            {
                randomX = randomX2;
            }
            forceValue = Random.Range(minForce, maxForce);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.CompareTag("Minus"))
            {

                if (verticalVelocity > 0)
                {
                    ballCollider.sharedMaterial.bounciness = startBounciness;
                    Debug.Log("Bounciness on up" + ballCollider.sharedMaterial.bounciness);     
                    AudioManager.Instance.PlayStartBallSFXClip();
                }
                else
                {
                    transform.position = new Vector3(0f, transform.position.y, transform.position.z);
                    ballCollider.sharedMaterial.bounciness = 0f;
                    Debug.Log("Bounciness on down" + ballCollider.sharedMaterial.bounciness);
                    GameManager.Instance.AddScore(-10);
                }
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Bottom"))
            {
                Debug.Log("Bottom");
                transform.position = startPos;
                Vector2 forceDirection = new Vector2(randomX, 14.5f);
                Debug.Log("ForceDirection" + forceDirection);
                rb.AddForce(forceDirection * forceValue);
            }
        }

    }
}