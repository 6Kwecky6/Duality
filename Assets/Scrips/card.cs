using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class card : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Card created");
    }
    void OnMouseEnter()
    {
        print("Mouse hover over "+gameObject.name);
        gameObject.transform.position += transform.up;

    }
    void OnMouseExit()
    {
        print("Mouse is no longer on card"+gameObject.name);
        gameObject.transform.position -= transform.up;
        
    }
}
