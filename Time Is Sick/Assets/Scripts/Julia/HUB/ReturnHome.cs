using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnHome : MonoBehaviour
{
    public InteractibleBehavior interactible;
    // Start is called before the first frame update
    void Start()
    {
        GameObject map = GameObject.FindGameObjectWithTag("Map");
        map.GetComponent<RectTransform>().localScale = Vector3.zero;
        interactible = GetComponentInChildren<InteractibleBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactible.interacted)
        {
            GameObject.Destroy(GameObject.Find("Game Components"));
            interactible.interacted = false;
            SceneManager.LoadScene("HUB");

        }
    }
}
