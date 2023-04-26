using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PoliceButton()
    {
        SceneManager.LoadScene("PoliceInfo");
    }
    public void ThreatButton()
    {
        SceneManager.LoadScene("ThreatInfo");
    }
}
