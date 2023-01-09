using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace Features.Core.Scripts.EnemyScripts
{
    public class Enemy2Movement : EnemyMovement
    {
        
        private NavMeshAgent _agent;
        
        void Start()
        {
            _agent = gameObject.GetComponent<NavMeshAgent>();
            _agent.updateUpAxis = false;
            _agent.updateRotation = false;
        }

        void Update()
        {
            
        }

        public override void Move(Transform target)
        {
            _agent.isStopped = false;
            _agent.SetDestination(target.position);
        }
        
        public void PauseMovement()
        {
            StartCoroutine(Pause());
        }
        
        IEnumerator Pause()
        {
            _agent.isStopped = true;
            yield return new WaitForSeconds(2);
            _agent.isStopped = false;
        }
    }
}
