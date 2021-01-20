using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDetector : MonoBehaviour
{
    public List<GameObject> doors;
    public LayerMask ennemies;
    public Collider detector;
    bool allEnemiesDestroyed;

    //Musiks
    public AudioClip battleTheme, suspenseTheme;
    public AudioSource musicSource;

    void Start()
    {
        musicSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        detector = GetComponent<Collider>();
        int children = transform.parent.parent.parent.childCount;
        for (int i = 0; i < children; i++)
        {
            if (transform.parent.parent.parent.GetChild(i).GetComponent<DoorManager>())
            {
                doors.Add(transform.parent.parent.parent.GetChild(i).gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        allEnemiesDestroyed = true;
        Collider[] foes = Physics.OverlapBox(detector.bounds.center, detector.bounds.extents, Quaternion.identity, ennemies);
        foreach (Collider foe in foes)
        {
            EnemyDamage enemy = foe.GetComponent<EnemyDamage>();
            if (enemy.isTrap == true || enemy.isTable == true || enemy.isEnvironment == true)
            { } else
            {

            
                allEnemiesDestroyed = false;
            }
        }

        if (allEnemiesDestroyed)
        {
            foreach (GameObject door in doors)
            {
                door.GetComponent<DoorManager>().Open();
            }
            musicSource.clip = suspenseTheme;
            musicSource.Play();
        }
        else
        {
            musicSource.volume = 0;
            musicSource.clip = battleTheme;
            musicSource.Play();
            musicSource.volume += 50 * Time.deltaTime;
        }
    }
}
