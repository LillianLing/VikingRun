using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class gameGuide : MonoBehaviour, IPointerClickHandler
{
    public Canvas guideWindow;
    public Canvas mainMenu;
    public Button back;

    public void OnPointerClick(PointerEventData e)
    {
        guideWindow.enabled = true;
        mainMenu.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        guideWindow.enabled = false;
        mainMenu.enabled = true;
        back.onClick.AddListener(BackToMenu);
    }

    private void BackToMenu()
    {
        guideWindow.enabled = false;
        mainMenu.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
