using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace BehaviorTree
{
    public enum NodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }

    public class Node_Dil
    {
        protected NodeState state;

        public Node_Dil parent;
        protected List<Node_Dil> children = new List<Node_Dil>();

        private Dictionary<string, object> _dataContext = new Dictionary<string, object>();

        public Node_Dil()
        {
            parent = null;
        }
        public Node_Dil(List<Node_Dil> children)
        {
            foreach (Node_Dil child in children)
                _Attach(child);
        }

        private void _Attach(Node_Dil node)
        {
            node.parent = this;
            children.Add(node);
        }

        public virtual NodeState Evaluate() => NodeState.FAILURE;

        public void SetData(string key, object value)
        {
            _dataContext[key] = value;
        }

        public object GetData(string key)
        {
            object value = null;
            if (_dataContext.TryGetValue(key, out value))
                return value;

            Node_Dil node = parent;
            while (node != null)
            {
                value = node.GetData(key);
                if (value != null)
                    return value;
                node = node.parent;
            }
            return null;
        }

        public bool ClearData(string key)
        {
            if (_dataContext.ContainsKey(key))
            {
                _dataContext.Remove(key);
                return true;
            }

            Node_Dil node = parent;
            while (node != null)
            {
                bool cleared = node.ClearData(key);
                if (cleared)
                    return true;
                node = node.parent;
            }
            return false;
        }
    }

}