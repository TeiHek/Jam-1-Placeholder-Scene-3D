using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public float internalAngle = 0f;    // Values: [0, 360), used in (future) sprite directionality
    private int rotGroup;               // Used to determine what anim should be visible
    public Animator animator;
    public string[] anims = { "Forward_Idle", "Front_Angle", "Side_Idle", "Back_Angle_Idle", "Rear_Idle", "Back_Angle_Idle", "Side_Idle", "Front_Angle" };
    private bool flipped = false;
    // Start is called before the first frame update
    void Start()
    {
        internalAngle = Mathf.Abs(internalAngle % 360);
    }

    // Update is called once per frame
    void Update()
    {
        float relAngle = ((transform.eulerAngles.y + internalAngle) % 360);
        //rotGroup = (int) (relAngle / 22.5) ;

        // temporarily hardcoded, gave up on doing math
        // also not great coding practices, but hey, it's a prototype
        if (relAngle < 22.5 || relAngle >= 337.5)
        {
            flop();
            animator.Play("Forward_Idle");
        }
        else if (relAngle < 67.5)
        {
            flip();
            animator.Play("Front_Angle");
        }
        else if (relAngle < 112.5)
        {
            flip();
            animator.Play("Side_Idle");
        }
        else if (relAngle < 157.5)
        {
            flip();
            animator.Play("Back_Angle_Idle");
        }
        else if (relAngle < 202.5)
        {
            animator.Play("Rear_Idle");
            flop();
        }
        else if (relAngle < 247.5)
            animator.Play("Back_Angle_Idle");
        else if (relAngle < 292.5)
            animator.Play("Side_Idle");
        else if (relAngle < 337.5)
            animator.Play("Front_Angle");
    }
    void flip()
    {
        if (!flipped)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            flipped = true;
        }
    }
    void flop()
    {
        if (flipped)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            flipped = false;
        }
    }
}
