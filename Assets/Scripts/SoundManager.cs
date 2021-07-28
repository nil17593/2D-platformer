using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OutScal.PlatFormer
{
    /// <summary>
    /// this class manages all the sounds in the game
    /// all button click,collectibles,level complete and player died sounds are added
    /// </summary>
    public class SoundManager : MonoBehaviour
    {
        private static SoundManager instance;
        public static SoundManager Instance { get { return instance; } }
        [SerializeField] private AudioSource soundEffect;
        [SerializeField] private AudioSource soundMusic;
        [SerializeField] private SoundType[] sounds;
        [SerializeField] bool isMute = false;
        [SerializeField] float volume;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            SetVolume(0.5f);
            PlayMusic(Sounds.Music);
        }
        //we can access sound controll in unity
        public void SetVolume(float Volume)
        {
            volume = Volume;
            soundEffect.volume = volume;
            soundMusic.volume = volume;
        }
        //we can mute sound in unity inspector pannel
        public void Mute(bool status)
        {
            isMute = status;
        }

        public void PlayMusic(Sounds sound)
        {
            if (isMute)
                return;
            AudioClip clip = GetSoundClip(sound);
            if (clip != null)
            {
                soundMusic.clip = clip;
                soundMusic.Play();
            }
            else
            {
                Debug.LogError("clip not found for the soundType: " + sound);
            }
        }

        public void Play(Sounds sound)
        {
            if (isMute)
                return;
            AudioClip clip = GetSoundClip(sound);
            if (clip != null)
            {
                soundEffect.PlayOneShot(clip);
            }
            else
            {
                Debug.LogError("clip not found for the soundType: " + sound);
            }
        }
        //sound getter function
        private AudioClip GetSoundClip(Sounds sound)
        {
            SoundType item = Array.Find(sounds, i => i.soundType == sound);
            if (item != null)
                return item.audioClip;
            return null;
        }
    }
    [Serializable]
    public class SoundType
    {
        public Sounds soundType;
        public AudioClip audioClip;
    }
    public enum Sounds
    {
        ButtonClick,
        Music,
        PlayerMove,
        PlayerCrouch,
        PlayerJump,
        PlayerLand,
        CollectItems,
        PlayerDeath,
        EnemyDeath,
        LevelComplete,
        GunFire,
    }
}

