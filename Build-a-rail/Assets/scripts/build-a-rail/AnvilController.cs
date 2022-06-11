using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilController : MonoBehaviour
{
    private int n_iron;
    private int n_woods;

    public int total_iron;
    public int total_woods;

    private bool player1_wood_touching;
    private bool player2_wood_touching;
    private bool player1_iron_touching;
    private bool player2_iron_touching;

    public AudioSource anvilAudio;

    // Start is called before the first frame update
    void Start()
    {
        n_iron = 0; n_woods = 0;
        player1_wood_touching = false;
        player2_wood_touching = false;
        player1_iron_touching = false;
        player2_iron_touching = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (n_woods == total_woods)
        {
            GameController.wood_on_anvil = true;
        }

        if (n_iron == total_iron)
        {
            GameController.iron_on_anvil = true;
        }

        if(player1_wood_touching && player2_wood_touching)
        {
            n_woods++;
            player1_wood_touching = false;
            player2_wood_touching = false;
            GameController.wood_player1_status = false; GameController.wood_player2_status = false;
            GameController.destroy_material = true;
            anvilAudio.Play();
        }

        if (player1_iron_touching && player2_iron_touching)
        {
            n_iron++;
            player1_iron_touching = false;
            player2_iron_touching = false;
            GameController.iron_player1_status = false; GameController.iron_player2_status = false;
            GameController.destroy_material = true;
            anvilAudio.Play();
        }
    }

    void OnTriggerEnter(Collider targetObj)
    {
        if (targetObj.gameObject.tag == "Player1" && GameController.wood_player1_status)
        {
            player1_wood_touching = true;
        }

        if (targetObj.gameObject.tag == "Player2" && GameController.wood_player2_status)
        {
            player2_wood_touching = true;
        }

        if (targetObj.gameObject.tag == "Player1" && GameController.iron_player1_status)
        {
            player1_iron_touching = true;
        }

        if (targetObj.gameObject.tag == "Player2" && GameController.iron_player2_status)
        {
            player2_iron_touching = true;
        }
    }
}
