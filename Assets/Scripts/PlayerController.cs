using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    private GameManager gameManager;
    private GameObject playerFlag;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }


        playerFlag = GameObject.FindGameObjectWithTag("PlayerFlag");
        if (playerFlag == null)
        {
            Debug.LogError("Player flag not found in the scene!");
        }
    }

    private void Update()
    {
        if (gameManager != null && !gameManager.IsGameActive())
        {
            PlayerMovement();


            if (Input.GetKeyDown(KeyCode.Space))
            {
                PickUpFlag();
            }
        }
    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AIFlag"))
        {
            gameManager.PlayerScored();
        }
    }

    private void PickUpFlag()
    {
        if (playerFlag != null)
        {

            float distanceToFlag = Vector3.Distance(transform.position, playerFlag.transform.position);
            if (distanceToFlag <= 2f)
            {

                playerFlag.transform.SetParent(transform);
                playerFlag.transform.localPosition = Vector3.up;
            }
            else
            {
                Debug.Log("Too far from the flag to pick up!");
            }
        }
    }
}