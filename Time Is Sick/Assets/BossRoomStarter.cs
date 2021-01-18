using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomStarter : MonoBehaviour
{
    bool started;

    // Start is called before the first frame update
    private void Update()
    {
        if (!started)
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
                started = true;
            }
        }
    }
}
