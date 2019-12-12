using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishspawner : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject fishTemplate;
    private System.Random random;

    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();  
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void spawnFish()
    {
        int i = random.Next(spawnpoints.Length);
        var thisSpawnPoint = spawnpoints[i];
        var fish = Instantiate(fishTemplate);
        fish.transform.position = thisSpawnPoint.position;
        fish.transform.Translate(random.Next(-7, 8), 0, random.Next(-7, 8));
        fish.transform.Rotate(0, (float)(random.NextDouble() * 360), 0);
        fish.gameObject.SetActive(true);
    }
}
