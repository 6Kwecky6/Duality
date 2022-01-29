using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attack_button : MonoBehaviour
{
    private Button button; 
    // Start is called before the first frame update
    void Start()
    {
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
    }
}
