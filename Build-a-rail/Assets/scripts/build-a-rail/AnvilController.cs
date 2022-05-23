using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilController : MonoBehaviour
{
    public Transform stumps;
    public Transform rocks;
    public GameObject craftrails;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //delete tools if there is no more rocks or stumps
        if ((stumps.childCount == 0) && (rocks.childCount == 0))
        {
            GameController.tools_status = true;
        }

        if (GameController.wood_on_anvil && GameController.iron_on_anvil)
        {
            craftrails.active = true;
        }
    }

    void OnTriggerEnter(Collider targetObj)
    {
        if (targetObj.gameObject.tag == "WoodLabel")
        {
            GameController.wood_on_anvil = true;
            Destroy(targetObj.gameObject);
        }

        if (targetObj.gameObject.tag == "IronLabel")
        {
            GameController.iron_on_anvil = true;
            Destroy(targetObj.gameObject);
        }
    }
}
