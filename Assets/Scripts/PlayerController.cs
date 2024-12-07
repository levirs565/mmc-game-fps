using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator mAnimator;
    private float mLastSpeed = 0;
    private Rigidbody mRigidBody;
    private bool mOnGround = false;

    void Start()
    {
        mAnimator = GetComponentInChildren<Animator>();
        mRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (mOnGround && Input.GetButtonDown("Jump"))
        {
            mRigidBody.AddForce(new Vector3(0, 10000f, 0));
            mAnimator.SetBool("Jump", true);
            return;
        }

        float newSpeed = 0;
    
        newSpeed = Input.GetAxis("Vertical") * 5f;

        mLastSpeed = mOnGround ? Mathf.Lerp(mLastSpeed, newSpeed, Time.deltaTime * 2f) : 0;
        mAnimator.SetFloat("Speed", mLastSpeed);
        mAnimator.SetFloat("MotionSpeed", 1f);

        transform.position += transform.forward * mLastSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            mOnGround = true;
            mAnimator.SetBool("Grounded", true);
            mAnimator.SetBool("Jump", false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            mOnGround = false;
            mAnimator.SetBool("Grounded", false);
        }
    }
}
