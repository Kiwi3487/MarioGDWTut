using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LevelCompleteSquare : MonoBehaviour
{
    [SerializeField] private List<Sprite> powerupList;

    private float _changeTimer = 0;
    private int _previousChoice = 5;
    private int timeScore;
    private TimeCounter _timeCounter;

    private bool _itemCollected;
    
    void Start()
    {
        _timeCounter = FindObjectOfType<TimeCounter>(); // Find the TimeCounter script in the scene
    }

    void Update()
    {
        if (!_itemCollected)
        {
            ChangeImage();
        }
    }

    private void ChangeImage()
    {
        if (_changeTimer < Time.realtimeSinceStartup)
        {
            int choice = (int)Random.Range(0, powerupList.Count - 1);

            if (choice == _previousChoice)
            {
                ChangeImage();
                return;
            }

            GetComponent<SpriteRenderer>().sprite = powerupList[choice];
            
            _changeTimer = Time.realtimeSinceStartup + 0.25f;

            _previousChoice = choice;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(WaitFewSecondsBeforeClear());
        
        FindObjectOfType<AudioManager>().Stop("Music");
        
        if (_timeCounter != null)
        {
            timeScore = _timeCounter.timeCount * 100;
        }
        else
        {
            timeScore = 0;
        }
        
        FindObjectOfType<ScoreCounter>().AddScore(timeScore);
        FindObjectOfType<AudioManager>().Play("LevelClear");
        
        _itemCollected = true;
    }

    IEnumerator WaitFewSecondsBeforeClear()
    {
        yield return new WaitForSeconds(5);
        FindObjectOfType<LevelStatus>().SetLevelComplete(true);
    }
}