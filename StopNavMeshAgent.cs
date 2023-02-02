using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class StopNavMeshAgent : MonoBehaviour
{
    private NavMeshAgent Agent;
    private Animator Anima;
    float DefaultSpeed = 0;
    void Start()
    {
        Agent = this.GetComponent<NavMeshAgent>();
        Anima = this.GetComponent<Animator>();
        DefaultSpeed = Agent.speed;
        Debug.Log("S= " + DefaultSpeed);
    }

    public void StopAgent()
    {
        Agent.speed = 0;
        Anima.enabled = false;
    }
    public void PlayAgent()
    {
        Agent.speed = DefaultSpeed;
        Anima.enabled = true;
    }
}
