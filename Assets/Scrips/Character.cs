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

    public void take_damage(int dmg)
    {
        hp -= dmg;
        clean();
        if (hp <= 0)
        {
            Destroy(this);
        }
        else
        {
            
            make_choice();
        }
    }
    void clean()
    {
        Destroy(targeter_prefab);
        Debug.Log(name + " has deselected their target");
    }
    void make_choice()
    {
        //Choose damage
        rand_dmg = Random.Range(0, max_rand_dmg);
        target = enemies.transform.GetChild(Random.Range(0, enemies.transform.childCount)).gameObject;
        Debug.Log(gameObject.name + " targets " + target.name);
        
        //Create rotation of the arrows
        Quaternion rot = Quaternion.identity;
        if (!ally)
        {
            rot = Quaternion.Euler(0,180,0);
        }
        
        //Scale the target arrows
        Vector3 to = target.transform.position;
        Vector3 from =  transform.position;
        float mid_x = (from.x + to.x)/2f;
        //float scale_target_x = 
        targeter_prefab.transform.localScale = new Vector3((to.x - from.x)/8f, 2.0f, 1f);
        
        
        Instantiate(targeter_prefab,
            new Vector3(mid_x, 2.0f, 0.0f),
            rot);
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
