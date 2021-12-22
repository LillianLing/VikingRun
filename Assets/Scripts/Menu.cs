using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Menu : MonoBehaviour, IPointerClickHandler
{
    public Canvas pauseWindow;
    public Button cont;

    public void OnPointerClick(PointerEventData e)
    {
        pauseWindow.enabled = true;
        Time.timeScale = 0;

    }

    // Start is called before the first frame update
    void Start()
    {
        pauseWindow.enabled = false;
        cont.onClick.AddListener(ContinueGame);
    }

    private void ContinueGame()
    {
        pauseWindow.enabled = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
