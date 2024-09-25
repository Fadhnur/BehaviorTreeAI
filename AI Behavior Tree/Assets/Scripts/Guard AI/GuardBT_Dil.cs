using System.Collections.Generic;
using BehaviorTree;

public class GuardBT_Dil : Tree_Dil
{
    public UnityEngine.Transform[] waypoints;

    public static float speed = 2f;
    public static float fovRange = 6f;
    public static float attackRange = 3f;

    protected override Node_Dil SetupTree()
    {
        Node_Dil root = new Selector_Dil(new List<Node_Dil>
        {
            //new Sequence(new List<Node_Dil>
            //{
            //    new CheckEnemyInAttackRange(transform),
            //    new TaskAttack(transform),
            //}),
            new Sequence_Dil(new List<Node_Dil>
            {
                new CheckEnemyInFOVRange_Dil(transform),
                new TaskGoToTarget_Dil(transform),
            }),
            new TaskPatrol_Dil(transform, waypoints),
        });

        return root;
    }
}