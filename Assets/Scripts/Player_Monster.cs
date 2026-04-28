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

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }    


    // Update is called once per frame
    protected override void Update()
    {      
        base.Update();

        CheckMaleeTimer();

        if (Input.GetButtonDown("Fire1"))
        {
            OnAttack();
           
            
        }

        

    }

    void OnAttack()
    {
        if(!IsAttack)
        {
            Malee.SetActive(true);
            atktimer = 0f;
            IsAttack = true;
            //animator.SetBool("isAttack", IsAttack);
            animator.SetTrigger("attack");
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

                //animator.SetBool("isAttack", false); 
                
            }
        }
    }
}
