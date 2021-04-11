using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class SceneTransitionsActions : MonoBehaviour
{
    // Start is called before the first frame update
    public string objectName;
    private void Awake()
    {
        GameObject tp = GameObject.Find(objectName);
        CreatePermanentGameSettings(tp);

    }

    private void CreatePermanentGameSettings(GameObject gameSettingObjects)

    {
        if (gameSettingObjects.GetInstanceID() == gameObject.GetInstanceID())
        {

            Debug.Log("Creating permanent Game Setting Object.");
            GameObject.DontDestroyOnLoad(this.gameObject);
        }

        else
        {
           Destroy(gameObject);
        };

    }


    // Update is called once per frame
    void Update()
    {
       
    }
}
