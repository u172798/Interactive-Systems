using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialDrag : MonoBehaviour
{
    bool player1_dragging; bool player2_dragging;

    //material transform
    private Transform transform;

    //players transform
    Transform red; Transform blue;

    // Start is called before the first frame update
    void Start()
    {
        player1_dragging = false; player2_dragging = false;

        transform = this.GetComponent<Transform>();

        red = GameObject.FindWithTag("Player1").GetComponent<Transform>();
        blue = GameObject.FindWithTag("Player2").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(red.position, blue.position);

        bool condition = GameController.player1_status && GameController.player2_status && GameController.tools_status;

        if (distance >= 30.0f)
        {
            player1_dragging = false; player2_dragging = false;
            GameController.player1_status = false; GameController.player2_status = false;

            GameController.wood_player1_status = false; GameController.wood_player2_status = false;
            GameController.iron_player1_status = false; GameController.iron_player2_status = false;
            GameController.craftedrail_player1_status = false; GameController.craftedrail_player2_status = false;
        }

        if (player1_dragging && player2_dragging && condition)
        {
            transform.position = red.position + (blue.position - red.position) / 2;

            if (GameController.destroy_material)
            {
                GameController.player1_status = false; GameController.player2_status = false;
                GameController.destroy_material = false;
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider targetObj)
    {
        if (targetObj.gameObject.tag == "Player1" && !GameController.player1_status)
        {
            player1_dragging = true;
            GameController.player1_status = true;

            if (this.gameObject.tag == "WoodLabel")
            {
                GameController.wood_player1_status = true;
            }

            if (this.gameObject.tag == "IronLabel")
            {
                GameController.iron_player1_status = true;
            }

            if (this.gameObject.tag == "CraftedRail")
            {
                GameController.craftedrail_player1_status = true;
            }
        }

        if (targetObj.gameObject.tag == "Player2" && !GameController.player2_status)
        {
            player2_dragging = true;
            GameController.player2_status = true;

            if (this.gameObject.tag == "WoodLabel")
            {
                GameController.wood_player2_status = true;
            }

            if (this.gameObject.tag == "IronLabel")
            {
                GameController.iron_player2_status = true;
            }

            if (this.gameObject.tag == "CraftedRail")
            {
                GameController.craftedrail_player2_status = true;
            }
        }
    }
}
