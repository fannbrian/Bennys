using HutongGames.PlayMaker;

namespace Bennys.PlayMaker.Actions
{
    /// <summary>
    /// Handles logic for closest server bringing food to player.
    /// 
    /// Brian Fann
    /// 7/21/18
    /// </summary>
    [ActionCategory(ActionCategory.Character)]
    public class EnslaveAction : BasePatrolAction
    {
        public override void OnEnter()
        {
            base.OnEnter();

            // Go to closest table to player.
            var player = PlayerManager.s.player;
            var table = ObjectManager.s.FindClosestObjectWithTag(player, "Table");

            _agent.SetDestination(table.transform.position);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (IsStopped)
            {
                Finish();
            }
        }

        public override void OnExit()
        {
            base.OnExit();

            // Release the patrol server from waiting.
            var servers = ObjectManager.s.GetGameObjectsWithTag("Npc");

            foreach (var server in servers)
            {
                Fsm.SendEventToFsmOnGameObject(server, "", "onServed");
            }

            // Reduce/increase resources.
            PlayerHunger.s.Hunger += PlayerManager.s.HungerAddedWhenServed;
            PlayerMoney.s.Money -= PlayerManager.s.MoneyLostWhenServed;

            // Allow player to move freely.
            PlayerManager.s.ReleasePlayer();
        }
    }
}