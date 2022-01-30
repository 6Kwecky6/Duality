using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attack_button : MonoBehaviour
{
    private Button button; 
    private GameObject allies;
    private GameObject enemies;
    
    // Start is called before the first frame update
    void Start()
    {
        allies = GameObject.Find("Allies");
        enemies = GameObject.Find("Enemies");
        button = GetComponent<Button>();
        button.onClick.AddListener(AttackClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AttackClicked()
    {
        Debug.Log("Attack button has been pressed");
        for (int i = 0; i < allies.transform.childCount;i++)
        {
            GameObject child = enemies.transform.GetChild(i).gameObject;
            Character character_script = child.GetComponent<Character>();
            int base_dmg = character_script.base_dmg;
            int rand_dmg = character_script.rand_dmg;

            GameObject child_target = character_script.target;
            Character target_char_script = child_target.GetComponent<Character>();
            target_char_script.take_damage(base_dmg+rand_dmg);


        }
        
    }
}
