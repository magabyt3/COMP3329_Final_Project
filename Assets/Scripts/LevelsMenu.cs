using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Level()
    {
        //SceneManager.LoadScene("Level" + ClickedButtonName);
        string ClickedButtonName = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene(ClickedButtonName);
    }
}
