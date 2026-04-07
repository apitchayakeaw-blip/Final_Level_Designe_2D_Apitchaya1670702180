using UnityEngine;

public class Player_Monster : Player
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHealth = 5;
        health = maxHealth;
    }

    // Update is called once per frame
    protected override void Update()
    {
       
        base.Update();
    }
}
