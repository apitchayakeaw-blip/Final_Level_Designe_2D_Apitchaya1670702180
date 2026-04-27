using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Monster : Player

{
    public GameObject Malee;
    bool IsAttack = false;
    float atkDuratiom = 0.3f;
    float atktimer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb.gravityScale = gravityMultiplier;
        maxHealth = 5;
        health = maxHealth;
    }

    // Update is called once per frame
    protected override void Update()
    {
       
        base.Update();

        CheckMaleeTimer();

        if (Input.GetMouseButton(0))
        {
            OnAttack();
        }
       
    }

    void OnAttack()
    {
        if(!IsAttack)
        {
            Malee.SetActive(true);
            IsAttack = true;
        }
    }

    void CheckMaleeTimer()
    {
        if (IsAttack)
        {
            atktimer += Time.deltaTime;
            if (atktimer >= atkDuratiom )
            {
                atktimer = 0;  
                IsAttack = false;
                Malee.SetActive (false);
            }
        }
    }
}
