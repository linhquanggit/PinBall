using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PinBall
{
    public class ObiettiviController : MonoBehaviour
    {
        [SerializeField] private float minX;
        [SerializeField] private float maxX;
        [SerializeField] private float minY;
        [SerializeField] private float maxY;
        [SerializeField] private float randomX;
        [SerializeField] private float randomY;
        [SerializeField] private int obiettiviScore;
        private ObiettiviContainer obiettiviContainer;
        [SerializeField] private ParticleSystem particlesSystem;
        private void Awake()
        {
            if (particlesSystem == null)
            {
                return;
            }

        }
        private void OnEnable()
        {
            particlesSystem.Play();
        }
        // Start is called before the first frame update
        void Start()
        {
            obiettiviContainer = FindObjectOfType<ObiettiviContainer>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                SpawnManager.Instance.ReleaseObiettivi(obiettiviContainer);
                GameManager.Instance.AddScore(obiettiviScore);
                GameManager.Instance.RespawnObietivi(true);
                AudioManager.Instance.PlayAddScoreSFXClip();
            }
        }
    }
}