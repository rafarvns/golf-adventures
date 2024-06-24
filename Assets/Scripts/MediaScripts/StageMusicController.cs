using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace MediaScripts
{
    public class StageMusicController : MonoBehaviour
    {
        public bool onlyBackground = false;
        public AudioClip backgroundMusic;
        public AudioClip startMusic;
        public AudioClip victoryMusic;
        public AudioClip golfSwingSoundEffect;
        public AudioClip wallHitSoundEffect;
        [FormerlySerializedAs("bonusCollectSound")] public AudioClip bonusCollectSoundEffect;
        // public AudioClip loseMusic;

        private AudioSource _backgroundAudioSource;
        private List<AudioSource> _soundEffectsList;
        
        private int _previousState = -1;
        private int _state = 1;

        void Start()
        {
            if (onlyBackground)
            {
                _state = 0;
            }
            _backgroundAudioSource = GetComponent<AudioSource>();
            _soundEffectsList = new List<AudioSource>();
        }

        void Update()
        {
            if (_previousState != _state)
            {
                PlayBackgroundMusic();
                _previousState = _state;
            }

            if (!onlyBackground)
            {
                ChangeDefaultBackgroundMusicWhenCurrentHasBeenFinished();
                ExcludeInactivesoundEffects();                
            }
        }

        private void PlayBackgroundMusic()
        {
            switch (_state)
            {
                case 0:
                    _backgroundAudioSource.Stop();
                    _backgroundAudioSource.loop = true;
                    _backgroundAudioSource.clip = backgroundMusic;
                    _backgroundAudioSource.Play();
                    break;
                case 1:
                    _backgroundAudioSource.Stop();
                    _backgroundAudioSource.loop = false;
                    _backgroundAudioSource.clip = startMusic;
                    _backgroundAudioSource.Play();
                    break;
                case 2:
                    _backgroundAudioSource.Stop();
                    _backgroundAudioSource.loop = false;
                    _backgroundAudioSource.clip = victoryMusic;
                    _backgroundAudioSource.Play();
                    break;
            }
        }

        public void PlaySoundEffect(SoundEffectEnum soundEffect)
        {
            AudioSource sfAudioSource = gameObject.AddComponent<AudioSource>();
            sfAudioSource.loop = false;
            sfAudioSource.playOnAwake = false;
            switch (soundEffect)
            {
                case SoundEffectEnum.GOLF_SWING:
                    sfAudioSource.clip = golfSwingSoundEffect;
                    break;
                case SoundEffectEnum.WALL_HIT:
                    sfAudioSource.clip = wallHitSoundEffect;
                    break;
                case SoundEffectEnum.BONUS:
                    if (bonusCollectSoundEffect)
                    {
                        sfAudioSource.clip = bonusCollectSoundEffect;   
                    }
                    break;
                default:
                    return;
            }
            sfAudioSource.Play();
            _soundEffectsList.Add(sfAudioSource);
        }

        private void ChangeDefaultBackgroundMusicWhenCurrentHasBeenFinished()
        {
            if (_state != 0)
            {
                if (!_backgroundAudioSource.isPlaying)
                {
                    ChangeBackgroundMusic(0);
                }
            }
        }
        
        private void ExcludeInactivesoundEffects()
        {
            int i = 0;
            while (i < _soundEffectsList.Count)
            {
                if (!_soundEffectsList[i].isPlaying)
                {
                    Destroy(_soundEffectsList[i]);
                    _soundEffectsList.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }

        public void ChangeBackgroundMusic(int newState)
        {
            _state = newState;
        }
    }
}