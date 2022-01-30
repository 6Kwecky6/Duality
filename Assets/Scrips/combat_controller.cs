using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combat_controller : MonoBehaviour
{

    private int enemy_count;

    private int ally_count;

    private List<int> allies;
    private List<int> enemies;
    // Start is called before the first frame update
    void Start()
    {
        enemy_count = 3;
        ally_count = 3;
    }

    private void initTeams()
    {
        for (int i = 0; i < ally_count; i++)
        {
            
        }
    }

    public void killEnemy()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
