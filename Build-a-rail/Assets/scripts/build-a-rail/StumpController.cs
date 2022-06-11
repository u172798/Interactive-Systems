using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpController : MonoBehaviour
{
    public GameObject wood_label;
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
        if (targetObj.gameObject.tag == "Player1" && GameController.axe_p1_status)
        {
            GameController.axe_animate = true;
            StartCoroutine(PlayWaitDestroy());
        }

        if (targetObj.gameObject.tag == "Player2" && GameController.axe_p2_status)
        {
            GameController.axe_animate = true;
            StartCoroutine(PlayWaitDestroy());
        }
    }

    private IEnumerator PlayWaitDestroy()
    {
        //particles.Emit(2);
        yield return new WaitForSeconds(2);
        Instantiate(wood_label, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
