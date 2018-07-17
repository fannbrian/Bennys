using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using HutongGames.PlayMaker;

namespace Bennys.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Character)]
    public class SeatingAction : BasePatrolAction
    {
        FsmGameObject player;
        Rigidbody rb;

        public override void OnEnter()
        {
            base.OnEnter();

            var tables = GameObject.FindGameObjectsWithTag("Table");
            var closestTable = tables[0];
            var closestDistance = 9999999999999f;

            foreach(var table in tables)
            {
                var distance = Vector3.Distance(table.transform.position, Owner.transform.position);

                if (distance < closestDistance)
                {
                    closestTable = table;
                    closestDistance = distance;
                }
            }

            _agent.SetDestination(closestTable.transform.position);
            player = Fsm.Variables.GetFsmGameObject("Player");
            rb = player.Value.GetComponent<Rigidbody>();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            var ownerPos = Owner.transform.position;
            var playerPos = player.Value.transform.position;
            var distance = Vector3.Distance(ownerPos, playerPos);

            if (distance > 1f)
            {
                var heading = playerPos - ownerPos;
                rb.MovePosition(ownerPos + heading * (1f / distance));
            }

            if (IsStopped)
            {
                Finish();
            }
        }
    }
}
