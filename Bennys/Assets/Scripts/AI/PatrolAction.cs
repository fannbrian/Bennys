using UnityEngine.AI;
using UnityEngine;
using HutongGames.PlayMaker;

public class PatrolAction : FsmStateAction {
    private PlayMakerFSM _fsm;
    private PatrolPath _path;
    private NavMeshAgent _agent;
    private int _currentDestinationIndex;
    private int _deltaIndex;

    public override void OnEnter()
    {
        // Cache components
        _fsm = Fsm.FsmComponent;
        _path = Owner.GetComponent<PatrolPath>();
        _agent = Owner.GetComponent<NavMeshAgent>();

        // Set destination to first point.
        _agent.SetDestination(_path.points[_currentDestinationIndex]);
    }

    public override void OnUpdate()
    {
        var detectionAngle = _fsm.FsmVariables.GetFsmFloat("DetectionAngle");

        if (LineOfSightHelper.IsObjectVisible(Owner, _agent.velocity.normalized, detectionAngle.Value, PlayerManager.s.player))
        {
            Fsm.SendEventToFsmOnGameObject(Owner, "", "playerFound");
        }

        // End early if owner hasnt reached destination.
        if (_agent.pathPending) return;
        if (_agent.remainingDistance > _agent.stoppingDistance) return;
        if (_agent.hasPath && _agent.velocity.sqrMagnitude != 0f) return;

        // If path is circular, set index to next index (if at end of array, loops back to index 0)
        // E.g. 0 -> 1 -> 2 -> 0 -> 1 -> 2
        if (_path.IsCircular)
        {
            _currentDestinationIndex = ++_currentDestinationIndex % _path.points.Length;
        }
        // If path is not circular, index will decrement after reaching end until it reaches index 0.
        // E.g, 0 -> 1 -> 2 -> 1 -> 2 -> 0
        else
        {
            if (_currentDestinationIndex == 0)
            {
                _deltaIndex = 1;
            }
            else if (_currentDestinationIndex == _path.points.Length)
            {
                _deltaIndex = -1;
            }

            _currentDestinationIndex += _deltaIndex;
        }

        // Set NavMesh destination to the next index.
        _agent.SetDestination(_path.points[_currentDestinationIndex]);
    }
}
