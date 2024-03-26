using UnityEngine;

public class AIController : MonoBehaviour
{
    public Transform aiBase;
    public GameObject redFlag;
    public float moveSpeed = 1f;

    private bool carryingFlag = false;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (!carryingFlag)
        {

            transform.position = Vector3.MoveTowards(transform.position, redFlag.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {

            transform.position = Vector3.MoveTowards(transform.position, aiBase.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, aiBase.position) < 0.1f)
            {
                Debug.Log("AI reached base with flag!");
                carryingFlag = false;
                gameManager.AIScored();
                redFlag.transform.SetParent(null);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == redFlag && !carryingFlag)
        {

            carryingFlag = true;
            redFlag.transform.SetParent(transform);
            redFlag.transform.localPosition = Vector3.up;
        }
    }
}
