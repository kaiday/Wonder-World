using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MiniGameLV3 : MonoBehaviour
{

    private AudioSource finishSound;
    public string m_Scene = "Level 1";
    public GameObject m_MyGameObject;


    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rhino")
        {

            finishSound.Play();

            ScriptLV1.portal = false;

            StartCoroutine(LoadYourAsyncScene());
        }
    }

 

    IEnumerator LoadYourAsyncScene()
    {
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(m_Scene, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(m_MyGameObject, SceneManager.GetSceneByName(m_Scene));
        ScriptLV1.portal = false;
        
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
}


