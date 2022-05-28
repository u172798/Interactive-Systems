using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour
{
    public GameObject iron_label;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider targetObj)
    {
        if (targetObj.gameObject.tag == "Player1" && GameController.pickaxe_p1_status)
        {
            Instantiate(iron_label, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (targetObj.gameObject.tag == "Player2" && GameController.pickaxe_p2_status)
        {
            Instantiate(iron_label, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
