using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameObjectController : MonoBehaviour
{
    public Transform stumps;
    public Transform rocks;
    public GameObject craftrails;
    public GameObject huecos;

    public Animator train;

    public AudioSource trainMovement;

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

        //move the train if there are no more huecos
        if (huecos.transform.childCount == 0)
        {
            StartCoroutine(PlayAndChangeScene());
        }

        if (GameController.wood_on_anvil && GameController.iron_on_anvil)
        {
            craftrails.active = true;
            huecos.active = true;
        }
    }

    private IEnumerator PlayAndChangeScene()
    {
        train.SetTrigger("MoveTrain");
        trainMovement.Play();
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
