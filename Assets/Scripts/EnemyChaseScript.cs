using UnityEngine;
//We add this library so we can use the navmeshagent component
using UnityEngine.AI;

public class EnemyChaseScript : MonoBehaviour
{
    //The agent component on this game object that handles navigation
    public NavMeshAgent agent;
    //The target that this agent is trying to reach
    public Transform target;


    // Update is called once per frame
    void Update()
    {
        //Tell the agent to set its new destination to be the target position
        agent.SetDestination(target.position);
    }
}
