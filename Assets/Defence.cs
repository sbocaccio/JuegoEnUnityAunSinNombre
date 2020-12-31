using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class Defence : MonoBehaviour
{


    [SerializeField]
    private GameObject playerObject;
    bool DefenseMode = false;
    Player player_script;
    [SerializeField]
    private Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        player_script = playerObject.GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("Defence_activated");
            DefenseMode = true;
           // Debug.Log("Apreto X");
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            animator.SetTrigger("Defence_desactivated");
            DefenseMode = false;
           // Debug.Log("No apreto X");
        }
        //Defence_activated
    }
    public bool defenseActivated(){
        return DefenseMode;
    }
}
