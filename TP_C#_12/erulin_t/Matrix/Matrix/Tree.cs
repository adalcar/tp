using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Tree<T>
    {
        public Node<T> node;
        public delegate int CompType(T a, T b);
        CompType c;
        private delegate bool binfunc(ref Node<T> n, T val);
        public delegate void mapfunction(ref T elt);


        public Tree(CompType comp, T value)
        {
            c = comp;
            node = new Node<T>(value);
        }
        public void add_right_son(T val)
        {
            node.Fils_droit = new Tree<T>(c, val);
        }
        public void add_left_son(T val)
        {
            node.Fils_gauche = new Tree<T>(c, val);
        }

        public void depth_first_transversal(mapfunction m)
        {

            m(ref this.node.val);
            if (node.Fils_gauche != null)
                node.Fils_gauche.depth_first_transversal(m);
            if (node.Fils_droit != null)
                node.Fils_droit.depth_first_transversal(m);
        }
        public void breadth_first_transversal(mapfunction m)
        {
            Queue<Tree<T>> parcours= new Queue<Tree<T>>();

            parcours.Enqueue(this);
            do
            {
                Tree<T> t = parcours.Dequeue();
                m(ref t.node.val);
                if (t.node.Fils_gauche != null)
                    parcours.Enqueue(t.node.Fils_gauche);
                if (t.node.Fils_droit != null)
                    parcours.Enqueue(t.node.Fils_droit);
            }
            while (parcours.Count != 0);
        }
        private bool binary_traversal(ref Node<T> node, T val, binfunc null_case, binfunc equal_case)
        {
            if (null_case(ref node, val))
                return false;
            if (equal_case(ref node, val))
                return true;
            if (c(val, node.val)<0)
                node = node.Fils_gauche.node;
            else
                node = node.Fils_droit.node;

            return binary_traversal(ref node, val, null_case, equal_case);
        }


    }


    class Node<T>
    {
        public T val;
        public Tree<T> Fils_gauche, Fils_droit;
        public Node(T val)
        {
            this.val = val;
            Fils_droit = null;
            Fils_gauche = null;
        }
    }
}
