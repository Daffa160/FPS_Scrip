using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;
    PlayerLocomotion playerLocomotion;
    //parameter id di animator
    int vertical;
    int horizontal;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        vertical = Animator.StringToHash("vertical");
        horizontal = Animator.StringToHash("horizontal");
    }

    public void UpadateAnimatorValue(float horizontalMovement, float verticalMovemen, bool lagiLari)
    {
        //animation snapping

        float snappHorizontal;
        float snappVertical;

        #region Snapped Horizontal
        if (horizontalMovement > 0 && horizontalMovement < 0.55f)
        {
            snappHorizontal = 0.5f;
        }
        else if (horizontalMovement > 0.55f)
        {
            snappHorizontal = 1f;
        }
        else if (horizontalMovement < 0 && horizontalMovement > -0.55f)
        {
            snappHorizontal = -0.5f;
        }
        else if (horizontalMovement < -0.55f)
        {
            snappHorizontal = -1f;
        }
        else
        {
            snappHorizontal = 0;
        }
        #endregion
        #region Snapped Vertical
        if (verticalMovemen > 0 && verticalMovemen < 0.55f)
        {
            snappVertical = 0.5f;
        }
        else if (verticalMovemen > 0.55f)
        {
            snappVertical = 1f;
        }
        else if (verticalMovemen < 0 && verticalMovemen > -0.55f)
        {
            snappVertical = -0.5f;
        }
        else if (verticalMovemen < -0.55f)
        {
            snappVertical = -1f;
        }
        else
        {
            snappVertical = 0;
        }
        #endregion

        if (playerLocomotion.percepatan > 0)
        {
            snappHorizontal = horizontalMovement;
            snappVertical = playerLocomotion.percepatan;
        }

        if (lagiLari)
        {
            snappHorizontal = horizontalMovement;
            snappVertical = 2;
        }
        

        animator.SetFloat(horizontal, snappHorizontal, 0.1f, Time.deltaTime);
        animator.SetFloat(vertical, snappVertical, 0.1f, Time.deltaTime);
    }
}
