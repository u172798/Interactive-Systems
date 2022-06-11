using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour
{
    public GameObject iron_label;
    //private ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        //particles = this.gameObject.GetComponent<ParticleSystem>(); ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider targetObj)
    {
        if (targetObj.gameObject.tag == "Player1" && GameController.pickaxe_p1_status)
        {
            GameController.pickaxe_animate = true;
            StartCoroutine(PlayWaitDestroy());
        }

        if (targetObj.gameObject.tag == "Player2" && GameController.pickaxe_p2_status)
        {
            GameController.pickaxe_animate = true;
            StartCoroutine(PlayWaitDestroy());
        }
    }

    private IEnumerator PlayWaitDestroy()
    {
        //particles.Emit(2);
        yield return new WaitForSeconds(2);
        Instantiate(iron_label, this.transform.position, this.transform.rotation * Quaternion.Inverse(Quaternion.Euler(-90f, 0f, 0f)));
        Destroy(this.gameObject);
    }
}
