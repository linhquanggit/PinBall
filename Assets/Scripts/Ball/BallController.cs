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
        [SerializeField] private Vector3 startPos;
        private float verticalVelocity;
        // Start is called before the first frame update
        void Start()
        {
            startPos = new Vector3(0f, -22f, 0f);
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
                    AudioManager.Instance.PlayStartBallSFXClip();
                }
                else
                {
                    GameManager.Instance.AddScore(-10);
                }
               
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Bottom"))
            {
                Debug.Log("Bottom");
                transform.position = new Vector3(0f, transform.position.y, transform.position.z);
                transform.position = startPos;
                StartCoroutine(IEStart());
            }
        }

        IEnumerator IEStart()
        {
            yield return new WaitForSeconds(1f);
            Vector2 forceDirection = new Vector2(randomX-transform.position.x, 14.5f);
            rb.AddForce(forceDirection * forceValue);
        }

    }
}