using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg
{   
   

    public class AnimatorScript : MonoBehaviour
    {
        public Animator anim;
        public PlayerAnimationState playerAnimationState;
        public void OnAnimatorMove()
        {   
            if(!anim)
	   			return;

            if (anim.GetCurrentAnimatorStateInfo(1).IsName(playerAnimationState.animPlaying))
            {
                transform.parent.position = anim.rootPosition;
	   		    transform.parent.rotation = anim.rootRotation;
            }
        }
    }
}

