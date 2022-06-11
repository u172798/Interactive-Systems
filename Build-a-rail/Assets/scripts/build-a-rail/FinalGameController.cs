using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGameController : MonoBehaviour
{
    public Animator train;
    public AudioSource trainMovement;

    // Start is called before the first frame update
    void Start()
    {
        train.SetTrigger("MoveTrain3");
        trainMovement.Play();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ShutDown());
    }

    private IEnumerator ShutDown()
    {
        yield return new WaitForSeconds(20);
        Application.Quit();
    }
}
