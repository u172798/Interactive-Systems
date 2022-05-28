using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpController : MonoBehaviour
{
    public GameObject wood_label;

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
        if (targetObj.gameObject.tag == "Player1" && GameController.axe_p1_status)
        {
            Instantiate(wood_label, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (targetObj.gameObject.tag == "Player2" && GameController.axe_p2_status)
        {
            Instantiate(wood_label, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
