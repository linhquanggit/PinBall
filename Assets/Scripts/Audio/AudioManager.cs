using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PinBall
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager instance;
        public static AudioManager Instance
        {
            get
            {
                if (instance == null)
                    instance = FindObjectOfType<AudioManager>();
                return instance;
            }
        }
        [SerializeField] private AudioSource sfx;
        [SerializeField] private AudioSource armSource;

        [SerializeField] AudioClip bumperSFXClip;
        [SerializeField] AudioClip addScoreSFXClip;
        [SerializeField] AudioClip flipperSFXClip;
        [SerializeField] AudioClip startBallSFXClip;
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
        }

        public void PlayBumperSFXClip()
        {
            sfx.PlayOneShot(bumperSFXClip);
        }
        public void PlayStartBallSFXClip()
        {
            sfx.PlayOneShot(startBallSFXClip);
        }
        public void PlayAddScoreSFXClip()
        {
            sfx.PlayOneShot(addScoreSFXClip);
            
        }
        public void PlayFlipperSFXClip()
        {
            armSource.PlayOneShot(flipperSFXClip);
        }
    }
}
