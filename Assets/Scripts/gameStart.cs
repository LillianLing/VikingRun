using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour, IPointerClickHandler
{
    public int SceneIndexDestination = 1;

    public void OnPointerClick(PointerEventData e)
    {
        // get the current scene
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("current scene name = " + scene.name + " and scene index = " + scene.buildIndex);

        // load a new scene
        SceneManager.LoadScene(SceneIndexDestination);
        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
