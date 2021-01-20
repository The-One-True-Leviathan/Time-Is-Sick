using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject door;


    public void Open()
    {
        door.SetActive(false);

        Debug.LogWarning("Doors opened");
    }

    public void Close()
    {
        door.SetActive(true);
        Debug.LogWarning("Doors closed");
    }
}
