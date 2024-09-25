using System.Collections.Generic;

namespace BehaviorTree
{
    public class Selector_Dil : Node_Dil
    {
        public Selector_Dil() : base() { }
        public Selector_Dil(List<Node_Dil> children) : base(children) { }

        public override NodeState Evaluate()
        {
            foreach (Node_Dil node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS;
                        return state;
                    case NodeState.RUNNING:
                        state = NodeState.RUNNING;
                        return state;
                    default:
                        continue;
                }
            }

            state = NodeState.FAILURE;
            return state;
        }

    }

}