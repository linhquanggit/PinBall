using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PinBall
{
    public class BumperController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private int bumperScore;
        private bool scale;
        // Start is called before the first frame update
        void Start()
        {
            scale = false;
            animator.SetBool("IsBumper", scale);
            animator.SetBool("IsIdle", !scale);
        }

        // Update is called once per frame
        void Update()
        {
            animator.SetBool("IsBumper", scale);
            animator.SetBool("IsIdle", !scale);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                scale = true;
                GameManager.Instance.AddScore(bumperScore);
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