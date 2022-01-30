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

    public int base_dmg = 20;
    public int max_rand_dmg = 4;
    public int rand_dmg;

    public GameObject target;
    private GameObject enemies;

    public GameObject targeter_prefab;
    public GameObject target_arrow;

    public void take_damage(int dmg)
    {
        hp -= dmg;
        
        Debug.Log(name + " now has " + hp + " hp.");
        clean();
        if (hp <= 0)
        {
            Debug.Log(name + " has been defeated");
            Destroy(gameObject);
        }
        else
        {
            
            make_choice();
        }
    }
    void clean()
    {
        Destroy(target_arrow);
        Debug.Log(name + " has deselected their target");
    }

    void find_enemies()
    {
        if (ally)
        {
            enemies = GameObject.Find("Enemies");
        }
        else
        {
            enemies = GameObject.Find("Allies");
        }
    }
    void make_choice()
    {
        //Assess enemies
        find_enemies();
        
        //Choose damage
        rand_dmg = Random.Range(0, max_rand_dmg);
        target = enemies.transform.GetChild(Random.Range(0, enemies.transform.childCount)).gameObject;
        Debug.Log(gameObject.name + " targets " + target.name);
        
        //Create rotation of the arrows
        /*Quaternion rot = Quaternion.identity;
        if (!ally)
        {
            rot = Quaternion.Euler(0,180,0);
        }*/
        
        //Scale the target arrows
        Vector3 to = target.transform.position;
        Vector3 from =  transform.position;
        float mid_x = (from.x + to.x)/2f;
        //float scale_target_x = 
        if (!ally)
        { 
            targeter_prefab.transform.localScale = new Vector3((to.x - from.x)/4.5f, -2.0f, 1f);
        }
        else
        {
            targeter_prefab.transform.localScale = new Vector3((to.x - from.x)/4.9f, 2.0f, 1f);

        }
        
        
        
        float start_x;
        float start_y;
        

        if (!ally)
        {
        start_y= -2f;
        start_x = mid_x-0.1f;
        }
        else
        {
        start_y= 3f;
        start_x = mid_x+0.5f;
        
        }
        target_arrow = Instantiate(targeter_prefab,
        new Vector3(start_x, start_y, 0.0f),
        Quaternion.identity);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        find_enemies();
        make_choice();
        Debug.Log(gameObject.name + " with base "+base_dmg+" and rand addition " + rand_dmg + 
                  "\nWill target "+enemies.name);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
