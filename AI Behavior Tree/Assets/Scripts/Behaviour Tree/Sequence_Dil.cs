using System.Collections.Generic;

namespace BehaviorTree
{
    public class Sequence_Dil : Node_Dil
    {
        public Sequence_Dil() : base() { }
        public Sequence_Dil(List<Node_Dil> children) : base(children) { }

        public override NodeState Evaluate()
        {
            bool anyChildIsRunning = false;

            foreach (Node_Dil node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.RUNNING:
                        anyChildIsRunning = true;
                        continue;
                    default:
                        state = NodeState.SUCCESS;
                        return state;
                }
            }

            state = anyChildIsRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return state;
        }

    }

}