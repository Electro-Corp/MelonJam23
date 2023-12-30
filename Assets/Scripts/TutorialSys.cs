using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSys : MonoBehaviour
{
    public GameObject tutorialText;

    

    // Start is called before the first frame update
    void Start()
    {
        tutorialText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        tutorialText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        tutorialText.SetActive(false);
    }
}
