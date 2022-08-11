using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSetting : MonoBehaviour
{
    public string key;
    [SerializeField] private Sprite onSprite;
    [SerializeField] private Sprite offSprite;
    private GameObject _audioSource;
    private Button btn;

    private void Start()
    {
        _audioSource = GameObject.Find("SoundManager");
        btn = gameObject.GetComponent<Button>();
        if (PlayerPrefs.GetInt(key, 1) == 0)
        {
            btn.image.sprite = offSprite;
        }

        btn.onClick.AddListener(() => Swicher(PlayerPrefs.GetInt(key, 1)));
    }

    void Swicher(int mode)
    {
        if (mode == 0)
        {
            PlayerPrefs.SetInt(key, 1);
            btn.image.sprite = onSprite;

            return;
        }

        PlayerPrefs.SetInt(key, 0);
        btn.image.sprite = offSprite;
    }
}

