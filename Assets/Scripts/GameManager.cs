using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
   [SerializeField] private GameObject setkaPrefab;
   [SerializeField] private GameObject starPrefub;
   [SerializeField] private Transform ball;
   private static GameManager _instance;
   public int score;
   public int chanceSpawnStar;
   public static GameManager Instance => _instance;

   private void Awake()
   {
      _instance = this;
   }

   public void spawnSetka()
   {
      
         Vector3 spawnPosition = new Vector3(transform.position.x, ball.position.y, transform.position.z);
         transform.position = spawnPosition;
         float rndPosX = Random.Range(-1.5f, 1.5f);
         spawnPosition.y += Random.Range(1f, 2f);
         spawnPosition.x += rndPosX;
         while (spawnPosition.x - ball.position.x < 1f && spawnPosition.x - ball.position.x > -1f)
         {
            Debug.Log(spawnPosition.x - ball.position.x);
            spawnPosition.x -= rndPosX;
            rndPosX = Random.Range(-1.5f, 1.5f);
            spawnPosition.x += rndPosX;
         }
         Instantiate(setkaPrefab, spawnPosition, Quaternion.identity);
         UIController.Instance.updateScore();
         TryToSpawnStar(spawnPosition);
      
   }

   private void TryToSpawnStar(Vector3 spawnPosition)
   {
      if (Random.Range(1, chanceSpawnStar) == chanceSpawnStar)
      {
         spawnPosition.y += 0.5f; 
         Instantiate(starPrefub,spawnPosition,Quaternion.identity);
      }
      
   }

   public void RestartGame()
   {
      SceneManager.LoadScene(0);
      Camera.main.gameObject.GetComponent<CameraFollow>().enabled = true;
   }
}
