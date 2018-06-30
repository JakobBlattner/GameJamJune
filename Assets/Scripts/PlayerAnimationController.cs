using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _body;
    private const string ParameterIsWalking = "IsWalking";

    // Use this for initialization
    void Start ()
	{
	    _animator = GetComponent<Animator>();
	    _body = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    var isWalking = _body.velocity != Vector2.zero;
	    _animator.SetBool(ParameterIsWalking, isWalking);
	}
}
