using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuecoController : MonoBehaviour
{
    public GameObject fixed_rail;

    private bool player1_touching;
    private bool player2_touching;
    public AudioSource placeAudio;

    // Start is called before the first frame update
    void Start()
    {
        player1_touching = false;
        player2_touching = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1_touching && player2_touching)
        {
            player1_touching = false;
            player2_touching = false;
            Instantiate(fixed_rail, this.transform.position, this.transform.rotation);
            GameController.craftedrail_player1_status = false; GameController.craftedrail_player2_status = false;
            GameController.destroy_material = true;
            placeAudio.Play();
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider targetObj)
    {
        if (targetObj.gameObject.tag == "Player1" && GameController.craftedrail_player1_status)
        {
            player1_touching = true;
        }

        if (targetObj.gameObject.tag == "Player2" && GameController.craftedrail_player2_status)
        {
            player2_touching = true;
        }
    }
}
