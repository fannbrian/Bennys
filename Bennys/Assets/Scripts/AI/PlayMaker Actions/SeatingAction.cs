using UnityEngine;
using HutongGames.PlayMaker;

namespace Bennys.PlayMaker.Actions
{
    /// <summary>
    /// Custom PlayMaker Action for dragging player to the closest table.
    /// 
    /// Brian Fann
    /// 7/16/18
    /// </summary>
    [ActionCategory(ActionCategory.Character)]
    public class SeatingAction : BasePatrolAction
    {
        FsmGameObject player;
        Rigidbody rb;

        bool _hasSlave;

        public override void OnEnter()
        {
            base.OnEnter();

            PlayerHide.s.UnHideImmediate();

            // Set AI destination to closest table
            var table = ObjectManager.s.FindClosestObjectWithTag(Owner, "Table");
            _agent.SetDestination(table.transform.position);
            
            player = Fsm.Variables.GetFsmGameObject("Player");
            rb = player.Value.GetComponent<Rigidbody>();
            var collider = player.Value.GetComponent<Collider>();

            // Set flags
            PlayerManager.s.IsGrabbed = true;
            _hasSlave = false;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            var ownerPos = Owner.transform.position;
            var playerPos = player.Value.transform.position;
            var distance = Vector3.Distance(ownerPos, playerPos);

            // Clamp player to maintain a 1 unit distance from server.
            if (distance > 1f)
            {
                var heading = playerPos - ownerPos;
                rb.MovePosition(ownerPos + heading * (1f / distance));
            }

            // Call closest server to bring food.
            if (IsStopped && !_hasSlave)
            {
                _hasSlave = true;

                var slaveServer = ObjectManager.s.FindClosestObjectWithTag(Owner, "Npc");
                Fsm.SendEventToFsmOnGameObject(slaveServer, "", "onEnslave");
            }
        }
    }
}
