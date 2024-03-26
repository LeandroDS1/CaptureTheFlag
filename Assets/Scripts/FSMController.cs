using UnityEngine;

public class FSMController : MonoBehaviour
{
    private enum State
    {
        Idle,
        SearchingForFlag,
        CarryingFlag,
        ReturningToBase
    }

    private State currentState = State.Idle;
    private GameObject targetFlag;
    private bool carryingFlag = false;

    public bool CarryingFlag
    {
        get { return carryingFlag; }
    }

    public void SetTargetFlag(GameObject flag)
    {
        targetFlag = flag;
    }

    public void UpdateFSM()
    {
        switch (currentState)
        {
            case State.Idle:
                if (targetFlag != null)
                {

                    float distanceToFlag = Vector3.Distance(transform.position, targetFlag.transform.position);
                    if (distanceToFlag <= 2f)
                    {
                        TransitionToState(State.CarryingFlag);
                        carryingFlag = true;
                    }
                }
                break;

            case State.SearchingForFlag:

                break;

            case State.CarryingFlag:


            case State.ReturningToBase:

                break;
        }
    }

    private void TransitionToState(State nextState)
    {
        currentState = nextState;
    }
}
