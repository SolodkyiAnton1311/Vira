using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjects;
  
    
    void Start()
    {
        foreach (var game in _gameObjects)
        {
            if (PlayerPrefs.GetInt(game.name,0) == 1)
            {
                game.GetComponentInChildren<Text>().enabled = false;
                game.GetComponent<Button>().onClick.AddListener(()=>
                {
                    Debug.Log(game.GetComponent<Image>().sprite);
                    BallScript.Instance.ChangeSkin(game.GetComponent<Image>().sprite);
                    
                });
            }
            else
            {
                game.GetComponent<Button>().onClick.AddListener(() =>
                {
                    buySkin(game);
                });
            }
        }
    }

    private void buySkin(GameObject gameObject)
    {
       
        if (PlayerPrefs.GetInt("Star",0) == Int32.Parse(gameObject.name))
        {
            gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
            PlayerPrefs.SetInt(Int32.Parse(gameObject.name).ToString(),1);
            PlayerPrefs.SetInt("Star",PlayerPrefs.GetInt("Star")-Int32.Parse(gameObject.name));
            gameObject.GetComponentInChildren<Text>().enabled = false;
            gameObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                BallScript.Instance.ChangeSkin(gameObject.GetComponent<Image>().sprite);
            });
           
        }

        
    }

    

   
}
