using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{
    //boolean variables
    bool redplayer; bool blueplayer; bool follow;

    //axe transform
    private Transform transform;

    //players transform
    public Transform red; public Transform blue;

    // Start is called before the first frame update
    void Start()
    {
        redplayer = true; blueplayer = true; follow = false;
        transform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            if (redplayer)
            {
                transform.position = red.position;
            }

            if (blueplayer)
            {
                transform.position = blue.position;
            }
        }

        //destroy axe in case there are no more obstacles
        if (GameController.tools_status)
        {
            GameController.player1_status = false;
            GameController.player2_status = false;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider targetObj)
    {
        if (targetObj.gameObject.tag == "Player1" && redplayer && !GameController.player1_status && !GameController.pickaxe_p1_status && !GameController.axe_p2_status)
        {
            blueplayer = false; follow = true; GameController.player1_status = true; GameController.axe_p1_status = true;
        }

        if (targetObj.gameObject.tag == "Player2" && blueplayer && !GameController.player2_status && !GameController.pickaxe_p2_status && !GameController.axe_p1_status)
        {
            redplayer = false; follow = true; GameController.player2_status = true; GameController.axe_p2_status = true;
        }

        if (targetObj.gameObject.tag == "Stump")
        {
            Destroy(targetObj.gameObject);
        }
    }
}
