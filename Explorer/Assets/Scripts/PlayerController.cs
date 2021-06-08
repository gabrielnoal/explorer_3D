using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public GameManager gm;

    public float _baseSpeed = 10.0f;
    float _gravidade = 9.8f;

    //Referência usada para a câmera filha do jogador
    GameObject playerCamera;
    //Utilizada para poder travar a rotação no angulo que quisermos.
    float cameraRotation;

    private bool isLetterUIOpen = false;
    public Text LetterTextUI;
    public GameObject LetterContentUI;
    private float timestamp = 0f;
    public float InputRate = 0.25f;
    public bool playerCanMove = true;



    CharacterController characterController;

    void Start()
    {
        gm = GameManager.GetInstance();

        characterController = GetComponent<CharacterController>();
        playerCamera = GameObject.Find("Main Camera");
        cameraRotation = 0.0f;
    }

    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Tratando movimentação do mouse
        float mouse_dX = Input.GetAxis("Mouse X");
        float mouse_dY = Input.GetAxis("Mouse Y");

        //Tratando a rotação da câmera
        cameraRotation -= mouse_dY;
        Mathf.Clamp(cameraRotation, -75.0f, 75.0f);

        //Verificando se é preciso aplicar a gravidade
        float y = 0;
        if (!characterController.isGrounded)
        {
            y = -_gravidade;
        }

        Vector3 direction = transform.right * x + transform.up * y + transform.forward * z;
        characterController.Move(direction * Time.deltaTime * (playerCanMove ? _baseSpeed : 0.0f));
        if (playerCanMove)
        {
            transform.Rotate(Vector3.up, mouse_dX);
            playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);
        }
    }


    void OpenLetterContent()
    {
        if (Input.GetKeyDown("space") && Time.time > timestamp)
        {

            if (gm.inventoryItems.Count > 0 && gm.inventoryItems[gm.selectedItem] != null)
            {
                if (gm.inventoryItems[gm.selectedItem].name.Contains("Letter"))
                {
                    // GameObject LetterContentUI = GameObject.Find("LettersContent");
                    if (this.isLetterUIOpen)
                    {
                        LetterContentUI.SetActive(false);
                        this.isLetterUIOpen = false;
                    }
                    else
                    {
                        LetterTextUI.text = gm.inventoryItems[gm.selectedItem].letterText;
                        LetterContentUI.SetActive(true);
                        this.isLetterUIOpen = true;
                    }
                }
            }

            timestamp = Time.time + InputRate;

        }
    }


    void Update()
    {
        MovePlayer();
        OpenLetterContent();
    }
}
