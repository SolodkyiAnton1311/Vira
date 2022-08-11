using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class SoundManagerScript : MonoBehaviour
    {
        private static SoundManagerScript _instance;
        public static SoundManagerScript Instance => _instance;
        private void Awake()
        {
            _instance = this;
        }

        public void Knock()
        {
            GetComponent<AudioSource>().Play();
        }
    }

