using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PinBall
{
    public class ShoulderController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private bool scale;
        // Start is called before the first frame update
        void Start()
        {
            scale = false;
            animator.SetBool("IsBumper", false);
            animator.SetBool("IsIdle", true);
        }

        // Update is called once per frame
        void Update()
        {
            if (scale)
            {
                animator.SetBool("IsBumper", true);
                animator.SetBool("IsIdle", false);
            }
            else
            {
                animator.SetBool("IsBumper", false);
                animator.SetBool("IsIdle", true);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                scale = true;
                GameManager.Instance.AddScore(1);
                AudioManager.Instance.PlayBumperSFXClip();
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                scale = false;
            }
        }
    }
}
