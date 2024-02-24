using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{

    public List<Transform> patrolPoints;
    public PlayerController player;
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    public float ViweAngle;

    void Start()
    {
        InitComponentLinks();
        PickNewTargetPoint();
    }
    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void PickNewTargetPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance == 0)
            {
                PickNewTargetPoint();
            }
        }
        
    }

    private void Update()
    {
        NoticePlayerUpdate();

        ChaseUpdate();

        PatrolUpdate();

    }

    // Update is called once per frame
    void NoticePlayerUpdate()
    {


        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < ViweAngle)
        {


            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }


            }
        }
    }

    void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
}
