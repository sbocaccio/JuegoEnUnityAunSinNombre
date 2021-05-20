using System.Collections;
using System.Collections.Generic;
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
            ActivateDefense();
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            DesActivateDefense();
        }
    }

    void ActivateDefense()
    {
        animator.SetTrigger("Defence_activated");
        DefenseMode = true;
        animator.ResetTrigger("Defence_desactivated");
    }

    void DesActivateDefense()
    {
        animator.ResetTrigger("Defence_activated");
        animator.SetTrigger("Defence_desactivated");
        DefenseMode = false;
    }
    public bool defenseActivated(){
        return DefenseMode;
    }
 

}
