using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PinBall
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                    instance = FindObjectOfType<GameManager>();
                return instance;
            }
        }

        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private float minX;
        [SerializeField] private float maxX;
        [SerializeField] private float minY;
        [SerializeField] private float maxY;
        [SerializeField] private float randomX;
        [SerializeField] private float randomY;
        [SerializeField] private Vector3 respawnPos;
        public Action<int> onScoreChanged;
        public Action<bool> onObiettiviDestroyed;
        private int score;

        private void OnEnable()
        {
            onScoreChanged += OnScoreChanged;
        }
        private void OnDisable()
        {
            onScoreChanged -= OnScoreChanged;
        }
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
        }
        // Start is called before the first frame update
        void Start()
        {
            SpawnManager.Instance.SpawnObiettivi(GetRandomPos());

        }

        // Update is called once per frame
        void Update()
        {

            GetRandomPos();
        }
        private Vector3 GetRandomPos()
        {
            randomX = UnityEngine.Random.Range(minX, maxX);
            randomY = UnityEngine.Random.Range(minY, maxY);
            respawnPos = new Vector3(randomX, randomY, 0);
            return respawnPos;
        }
        private void OnScoreChanged(int score)
        {
            scoreText.text = "" + score;
        }
        public void AddScore(int value)
        {
            score += value;
            if(score<0)
            {
                score = 0;
            }
            onScoreChanged(score);
        }
        public void OnObiettiviDestroyed(bool spawn)
        {
            SpawnManager.Instance.SpawnObiettivi(GetRandomPos());
        }
        public void RespawnObietivi(bool respan)
        {
            if(respan)
            {
                OnObiettiviDestroyed(true);
            }
            else
            {
                OnObiettiviDestroyed(false);
            }
        }
    }
}
