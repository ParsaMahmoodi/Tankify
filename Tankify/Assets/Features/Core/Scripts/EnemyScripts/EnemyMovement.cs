using System;
using UnityEngine;
using UnityEngine.AI;

namespace Features.Core.Scripts.EnemyScripts
{
    public class EnemyMovement : MonoBehaviour
    {

        private NavMeshAgent _agent;

        void Start()
        {
            _agent = gameObject.GetComponent<NavMeshAgent>();
            _agent.updateUpAxis = false;
            _agent.updateRotation = false;
        }

        private void Update()
        {
            
        }

        public void Move(Transform target)
        {
            _agent.isStopped = false;
            _agent.SetDestination(target.position);
        }

        public void Stop()
        {
            _agent.isStopped = true;
        }

    }
}
