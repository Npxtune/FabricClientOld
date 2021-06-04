using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f, groundDistance = 0.4f, gravity = -30f, sprintingMult, crouchMult, crouchingHeight, standingHeight;
    public Transform groundCheck, cam;
    public float turnSmooth = 0.1f;
    public LayerMask groundMask;
    public GameObject quitWidget, quickUI, debugWindow;
    public bool isUI = false, isSprinting = false, isCrouched = false;

    Vector3 velocity;
    bool isOnGround;

    // Update is called once per frame
    void Update()
    {
        if (isUI == false)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    isSprinting = true;
                }
                else
                {
                    isSprinting = false;
                }

                if (Input.GetKey(KeyCode.LeftControl))
                {
                    isCrouched = true;
                }
                else
                {
                    isCrouched = false;
                }

                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

                Vector3 mDirect = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                if (isSprinting == true && isCrouched == false)
                {
                    controller.Move(mDirect.normalized * speed * sprintingMult * Time.deltaTime);
                }
                else
                {
                    controller.Move(mDirect.normalized * speed * Time.deltaTime);
                }

                if (isCrouched == true && isSprinting == false)
                {
                    controller.Move(mDirect.normalized * speed * crouchMult * Time.deltaTime);
                    controller.height = crouchingHeight;
                }
                else
                {
                    controller.Move(mDirect.normalized * speed * Time.deltaTime);
                    controller.height = standingHeight;
                }
            }
        }
        isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isOnGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isUI == false)
            {
                GameObject.Find("Camera").SendMessage("enableUI", true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                quitWidget.SetActive(true);
                isUI = true;
            }
        }
        /*
        if (Input.GetKeyDown(KeyCode.F3))
        {
            if (isEscape == false && isF3 == false && isF5 == false)
            {
                GameObject.Find("Camera").SendMessage("enableUI", true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                quickUI.SetActive(true);
                isF3 = true;
                isUI = true;
            }
            else
            {
                GameObject.Find("Camera").SendMessage("enableUI", false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                quickUI.SetActive(false);
                isF3 = false;
                isUI = false;
            }
        }*/
    }
}