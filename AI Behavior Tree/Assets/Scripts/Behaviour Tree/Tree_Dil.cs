using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class Tree_Dil : MonoBehaviour
    {

        private Node_Dil _root = null;

        protected void Start()
        {
            _root = SetupTree();
        }

        private void Update()
        {
            if (_root != null)
                _root.Evaluate();
        }

        protected abstract Node_Dil SetupTree();

    }

}