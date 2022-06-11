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
        //restart values at each level
        GameController.player1_status = false;
        GameController.player2_status = false;

        GameController.axe_p1_status = false;
        GameController.axe_p2_status = false;
        GameController.pickaxe_p1_status = false;
        GameController.pickaxe_p2_status = false;

        GameController.axe_animate = false;
        GameController.pickaxe_animate = false;

        GameController.wood_player1_status = false;
        GameController.wood_player2_status = false;
        GameController.iron_player1_status = false;
        GameController.iron_player2_status = false;

        GameController.craftedrail_player1_status = false;
        GameController.craftedrail_player2_status = false;

        GameController.wood_on_anvil = false;
        GameController.iron_on_anvil = false;

        GameController.tools_status = false;

        GameController.destroy_material = false;
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
        if (SceneManager.GetActiveScene().name == "IntSysTemplate")
        {
            train.SetTrigger("MoveTrain1");
        }

        if (SceneManager.GetActiveScene().name == "IntSysTemplate2")
        {
            train.SetTrigger("MoveTrain2");
        }

        if (!trainMovement.isPlaying)
        {
            trainMovement.Play();
        }

        yield return new WaitForSeconds(18);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
