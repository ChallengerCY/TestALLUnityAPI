using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleClass : MonoBehaviour 
{
    public Animation anim;

    public AnimationClip animationClip;

    public bool isPlaying;

    public Bounds animBounds;

    public bool playAutomatically;

    public WrapMode mode;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();

        foreach (AnimationState state in anim)
        {
            state.speed = 0.5F;
        }

        ///When turned on, animations will be executed in the physics loop. 
        ///This is only useful in conjunction with kinematic rigidbodies.
        anim.animatePhysics = true;

        ///	The default animation.
        ///	
        //Debug.Log(anim.clip.name);
       // animationClip = anim.clip;

        ///Controls culling of this Animation component.
        anim.cullingType = AnimationCullingType.AlwaysAnimate;

        ///	Is an animation currently being played?
        isPlaying = anim.isPlaying;

        anim.playAutomatically = false;
        //anim["Example"].speed = 2.0f;

        anim.wrapMode = WrapMode.Clamp;

       // anim.AddClip(anim.GetClip("Test"),"Test");
      //  anim.AddClip(anim.GetClip("Test"), "Test",0,10,true);

    }

    public void Update()
    {
       Debug.Log(anim.localBounds);

      
    }

    
}
