using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDK2VC.M2V.Xml
{
    public class BTree<T>
    {
        public BTree()
        {
            nodes = new List<BTree<T>>();
        }

        public BTree(T data)
        {
            this.Data = data;
            nodes = new List<BTree<T>>();
        }

        private BTree<T> parent;
        /// <summary>
        /// 父结点
        /// </summary>
        public BTree<T> Parent
        {
            get { return parent; }
        }
        /// <summary>
        /// 结点数据
        /// </summary>
        public T Data { get; set; }

        private List<BTree<T>> nodes;
        /// <summary>
        /// 子结点
        /// </summary>
        public List<BTree<T>> Nodes
        {
            get { return nodes; }
        }
        /// <summary>
        /// 添加结点
        /// </summary>
        /// <param name="node">结点</param>
        public void AddNode(BTree<T> node)
        {
            if (!nodes.Contains(node))
            {
                node.parent = this;
                nodes.Add(node);
            }
        }
        /// <summary>
        /// 添加结点
        /// </summary>
        /// <param name="nodes">结点集合</param>
        public void AddNode(List<BTree<T>> nodes)
        {
            foreach (var node in nodes)
            {
                if (!nodes.Contains(node))
                {
                    node.parent = this;
                    nodes.Add(node);
                }
            }
        }
        /// <summary>
        /// 移除结点
        /// </summary>
        /// <param name="node"></param>
        public void Remove(BTree<T> node)
        {
            if (nodes.Contains(node))
                nodes.Remove(node);
        }
        /// <summary>
        /// 清空结点集合
        /// </summary>
        public void RemoveAll()
        {
            nodes.Clear();
        }
    }
    public class Node
    {
        public Node(string name,String parentname, bool isdir)
        {
            this.Name = name;
            this.ParentName = parentname;
            this.IsFile = isdir;
        }
        /// <summary>
        /// 当前名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 上级名称
        /// </summary>
        public String ParentName { get; set; }
        /// <summary>
        /// 是否是文件
        /// </summary>
        public bool IsFile { get; set; }
    }
}
