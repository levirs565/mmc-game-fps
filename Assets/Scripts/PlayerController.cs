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
        if (!mOnGround) return;
        if (Input.GetButtonDown("Jump"))
        {
            mRigidBody.AddForce(new Vector3(0, 250f, 0));
            return;
        }

        float newSpeed = 0;
     
        newSpeed = Input.GetAxis("Vertical") * 5f;

        mLastSpeed = Mathf.Lerp(mLastSpeed, newSpeed, Time.deltaTime * 2f);
        mAnimator.SetFloat("Speed", mLastSpeed);
        mAnimator.SetFloat("MotionSpeed", 1f);

        transform.position += transform.forward * mLastSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            mOnGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            mOnGround = false;
        }
    }
}
