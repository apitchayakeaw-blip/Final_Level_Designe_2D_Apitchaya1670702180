using UnityEngine;

public class PlayersSwap : MonoBehaviour
{
    public Player player;
    public Player playerMon;
    public bool player1Active = true;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            SwitchPlayer();
        }
    }

    public void SwitchPlayer()
    {
        if (player1Active)
        {
            player.enabled = false;
            playerMon.enabled = true;
            player1Active = false;
        }
        else
        {
            player.enabled = true;
            playerMon.enabled = false;
            player1Active = true;
        }
    }
}
