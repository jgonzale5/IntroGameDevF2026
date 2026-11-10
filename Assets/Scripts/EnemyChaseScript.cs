using UnityEngine;
//We add this library so we can use the navmeshagent component
using UnityEngine.AI;
//Add the generic library so we have access to lists
using System.Collections.Generic;

public class EnemyChaseScript : MonoBehaviour
{
    //We declare the possible states that the enemy can be in as an EnemyState type
    public enum EnemyState { Chasing, Patrolling};
    //We define a variable of the EnemyState type to hold what the current state is
    public EnemyState currentState;

    [Header("Patrolling")]
    //We define a list of transforms for the nodes and give it an initial value
    public List<Transform> patrolNodes = new List<Transform>();
    //An integer to keep track of the current node
    public int currentNode = 0;
    //How close does this enemy have to be to the node for it to be considered "there"
    public float arrivalRange = 0.5f;

    [Header("Navigation")]
    //The agent component on this game object that handles navigation
    public NavMeshAgent agent;
    //The target that this agent is trying to reach
    public Transform target;


    // Update is called once per frame
    void Update()
    {
        //If this enemy is in the chasing state, their target is the player position
        if (currentState == EnemyState.Chasing)
        {
            //Tell the agent to set its new destination to be the target position
            agent.SetDestination(target.position);
        }
        else if (currentState == EnemyState.Patrolling) 
        {
            //Tell the agent to set its destination to be the current selected node in the patrol list
            agent.SetDestination(patrolNodes[currentNode].position);

            if (HasArrived(patrolNodes[currentNode].position))
            {
                //We increase the current node by one so the next one is the objective
                //currentNode = currentNode + 1;
                //currentNode += 1;
                //currentNode++;

                //This means:   V Increase the integer that keeps track of the node by one
                //                              V Get the remainder of dividing it by
                //                                   V The number of elements in the list
                currentNode = (currentNode + 1) % patrolNodes.Count;
            }
        }
    }

    //This function tells us if this object is close enough to the destination to be considered "there"
    bool HasArrived(Vector3 destination)
    {
        //Get the distance between the position of this object, and the vector (coordinates) given
        float distance = Vector3.Distance(this.transform.position, destination);

        //If the distance is shorter than the arrival range, we've arrived there, so we return true
        if (distance <= arrivalRange)
            return true;
        else
            return false;
    }
}
