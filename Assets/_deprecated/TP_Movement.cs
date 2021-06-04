using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TP_Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f, gravity = -9.18f, groundDistance = 0.4f, sprintingMult, crouchMult, crouchingHeight = 1.25f, standingHeight;
    public Transform cam, groundCheck;
    public LayerMask groundMask;
    public float turnSmooth = 0.1f;
    float turnsmoothvelocity;
    Vector3 velocity;
    bool isOnGround;
    public bool isSprinting = false, isCrouched = false, isF3 = false, isF5 = false, isEscape = false;
    public GameObject quitWidget, debugWindow, quickUI;
    public Vault rVault;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEscape == false)
        {
            if (Input.GetButtonUp("Jump"))
            {
                rVault.spaceHold = false;
            }

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
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothvelocity, turnSmooth);

                transform.rotation = Quaternion.Euler(0f, angle, 0f);

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
            isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isOnGround && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);


        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isEscape == false && isF3 == false && isF5 == false)
            {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    quitWidget.SetActive(true);
                    isEscape = true;
            }            
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            if (isEscape == false && isF3 == false && isF5 == false)
            {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    debugWindow.SetActive(true);
                    isF5 = true;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                debugWindow.SetActive(false);
                isF5 = false;
            }

           
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            if (isEscape == false && isF3 == false && isF5 == false)
            { 
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    quickUI.SetActive(true);
                    isF3 = true;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                quickUI.SetActive(false);
                isF3 = false;
            }
        }
    }
}