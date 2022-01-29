using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{
    public bool ally;
    
    private int hp = 100;

    public int base_dmg = 1;
    public int max_rand_dmg = 4;
    public int rand_dmg;

    public GameObject target;
    private GameObject enemies;

    public GameObject targeter_prefab;

    void make_choice()
    {
        rand_dmg = Random.Range(0, max_rand_dmg);
        target = enemies.transform.GetChild(Random.Range(0, enemies.transform.childCount)).gameObject;
        Debug.Log(gameObject.name + " targets " + target.name);
        
        Quaternion rot = Quaternion.identity;
        if (!ally)
        {
            rot = Quaternion.Euler(0,180,0);
        }
        
        float to_x = target.transform.position.x;
        float from_x =  transform.position.x;
        Instantiate(targeter_prefab,
            new Vector3((from_x + to_x) / 2f, 2.0f, 0.0f),
            rot);
        Vector3 direction = target.transform.position - targeter_prefab.transform.position;
        targeter_prefab.transform.localScale= new Vector3(direction.magnitude/2f,2f,1);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (ally)
        {
            enemies = GameObject.Find("Enemies");
        }
        else
        {
            enemies = GameObject.Find("Allies");
        }
        make_choice();
        Debug.Log(gameObject.name + " with base "+base_dmg+" and rand addition " + rand_dmg + 
                  "\nWill target "+enemies.name);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
