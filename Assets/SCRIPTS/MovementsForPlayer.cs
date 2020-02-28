using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerAnim{
    walk,
    attack,
    interact
}
public class MovementsForPlayer : MonoBehaviour
{
    //public static MovementsForPlayer instance;
    
    private Stats health;
    //create instance for enum
    public PlayerAnim CurrentAnim;
    public float speed;
    private Rigidbody2D rb;
    //how much the player's position needs to change
    private Vector3 pos;
    private Animator animator;
    //public string pw;
   /* protected override void Update()
    {
        
    }*/
    void Start()
    {
        CurrentAnim = PlayerAnim.walk;
        animator = GetComponent<Animator>();
        rb= GetComponent<Rigidbody2D>();
        //fixing the boxes they work at the same time if u don't move at start
        //starts down because charcter at start always facing front
        animator.SetFloat("MoveX", 0);
        animator.SetFloat("MoveY", -1);
        
    }

    // Update is called once per frame
    void Update()
    {//resets how much the player has changed
        pos = Vector3.zero;
        //if the player is clicking buttons
        pos.x = Input.GetAxisRaw("Horizontal");
        pos.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("attack") && CurrentAnim!= PlayerAnim.attack){
            StartCoroutine(AttackCoroutine());
        }
        //Debug.Log(pos);
        //dependent on one another
       else if(CurrentAnim == PlayerAnim.walk){
        AnimationMovement();}

        
    }

    private IEnumerator AttackCoroutine(){
        animator.SetBool("Attack", true);
        CurrentAnim=PlayerAnim.attack;
        //a delay one frame
        yield return null;
        animator.SetBool("Attack",false);
        yield return new WaitForSeconds(.25f);
        CurrentAnim = PlayerAnim.walk;

        
    }
    void AnimationMovement()
    {
                if(pos != Vector3.zero){
            MoveChar();
            animator.SetFloat("MoveX", pos.x);
            animator.SetFloat("MoveY", pos.y);
            //this part where if i remove my finger the animation stays for a while
            animator.SetBool("Moving", true);
        }else{
            animator.SetBool("Moving", false);
        }
        
    }
    //able to move the character from other places in a seperate method its easier
    void MoveChar(){
        pos.Normalize();
        //call the rigidbody of the char
        rb.MovePosition(transform.position + pos * speed * Time.deltaTime);
        

    }
}
