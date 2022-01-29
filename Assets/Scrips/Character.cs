using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool ally;
    
    private int hp = 100;

    public int base_dmg = 1;
    public int max_rand_dmg = 4;
    public int rand_dmg;

    public GameObject target;
    private GameObject enemies;

    void make_choice()
    {
        rand_dmg = Random.Range(0, max_rand_dmg);
        target = enemies.transform.GetChild(Random.Range(0, enemies.transform.childCount)).gameObject;
        Debug.Log(gameObject.name + " targets " + target.name);
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
