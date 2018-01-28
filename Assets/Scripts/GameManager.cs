using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
    
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
        public int[] scores;
        public string[] levels;

        void Awake()
        {   
            scores = new int[levels.Length];
            for(int i = 0; i < levels.Length; i++)
            {
                scores[i] = PlayerPrefs.GetInt(levels[i]);
            }
            instance = this;
            /*if (instance == null)
            {
                //if not, set instance to this
                instance = this;
            }
            //If instance already exists and it's not this:
            else if (instance != this)
            {
                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);            
            } 
            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);*/
        }
        //Update is called every frame.
        void Update()
        {
            
        }
        public void LoadLevel(int levelIndex)
        {
            SceneManager.LoadScene(levels[levelIndex]);
        }
    }
