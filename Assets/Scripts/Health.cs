using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int MaxHealth;

    public Sprite enthyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

    public Player_Monster Player_Monster;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        health = Player_Monster.health;
        MaxHealth = Player_Monster.health;
        
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
               hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = enthyHeart;
            }
            
            if (i <MaxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
