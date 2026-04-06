using UnityEngine;

public class PlayersSwap : MonoBehaviour
{
    public Player player;
    public Player playerMon;
    public bool player1Active = true;

    public Camera camera1;
    public Camera camera2;

    // Update is called once per frame

    private void Start()
    {
        camera1.gameObject.SetActive(true);
        camera2.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            SwitchPlayer();
            camera1.gameObject.SetActive(!camera1.gameObject.activeSelf);
            camera2.gameObject.SetActive(!camera1.gameObject.activeSelf);
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
