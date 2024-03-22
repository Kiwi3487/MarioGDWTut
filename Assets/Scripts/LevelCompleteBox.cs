using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class LevelCompleteBox : MonoBehaviour
{
    [SerializeField] private List<Sprite> powerupList;

    private float changeTimer = 0;
    private int previousChoice = 5;

    private bool itemCollected;

    // Update is called once per frame
    void Update()
    {
        if (!itemCollected)
        {
            ChangeImage();
        }
    }

    void ChangeImage()
    {
        if (changeTimer < Time.realtimeSinceStartup)
        {
            int choice = (int)Random.Range(0, powerupList.Count - 1);

            if (choice == previousChoice)
            {
                ChangeImage();
                return;
            }

            GetComponent<SpriteRenderer>().sprite = powerupList[choice];
            changeTimer = Time.realtimeSinceStartup + 0.25f;
            previousChoice = choice;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        itemCollected = true;

        SceneManager.LoadScene("MainMenu");
    }
}
