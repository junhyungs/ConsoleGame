using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _2024_03_14
{
    internal class CBST
    {
        /*
         이진탐색트리(BinarySearchTree)

         이진속성, 탐색속성을 적용한 트리
         이진 탐색을 통한 탐색영역을 절반으로 줄여가며 탐색가능
         이진 : 부모 노드는 최대 2개의 자식 노드를 가질 수 있다.
         탐색 : 자신의 노드보다 작으면 왼쪽 크면 오른쪽
         
         [구현]
         
         [탐색]
         루트노드부터 시작하여 탐색하는 값과 비교한다.
         작은경우 왼쪽 자식노드로 크다면 오른쪽으로 감.
         1.23과 17을 비교 17 < 23 왼쪽으로 진행 (왼쪽으로 진행하면 오른쪽은 진행되지않는다 -> 절반으로 줄여가며 탐색하므로 탐색 속도가 빠르다)
         2.17과 11을 비교 17 > 11 오른쪽으로 진행 (오른쪽으로 진행하면 왼쪽은 진행되지 않는다 -> 절반으로 줄여가며 탐색하므로 탐색 속도가 빠르다)
         3.19와 17을 비교 17 < 19 왼쪽으로 진행
         4.17과 17을 비교 17 == 17 같으면 탐색완료
        //            23
        //      ┌──────┴──────┐
        //      11            38
        //   ┌──┴──┐       ┌──┴──┐
        //   3     19      31    65
        //   └─┐ ┌─┴─┐   ┌─┘     └─┐
        //     6 17  22  24        87
        =========================================================================================
        [삽입] 탐색과 비슷
        35를 삽입
        루트 노드부터 시작해서 삽입하는 값과 비교
        작으면 왼쪽자식으로 크면 오른쪽 자식으로 이동한다.
        1. 23과 35를 비교 35 > 23 오른쪽으로 진행
        2. 38과 35를 비교 35 < 38 왼쪽으로 진행
        3. 31과 35를 비교 35 > 31 오른쪽으로 진행
        4. 자리가 비었으면 삽입
        //            23
        //      ┌──────┴──────┐
        //      11            38
        //   ┌──┴──┐       ┌──┴──┐
        //   3     19      31    65
        //   └─┐ ┌─┴─┐   ┌─┘     └─┐
        //     6 17  22  24        87
        =========================================================================================
        [삭제]
        1. 자식이 0개인 경우 : 부모 노드의 자식노드를 null로 바꿔준다.
        //            23
        //      ┌──────┴──────┐
        //      11            38
        //   ┌──┴──┐       ┌──┴──┐
        //   3     19      31    65
        //   └─┐ ┌─┴─┐   ┌─┘     └─┐
        //     6 17  22  24        
        2. 자식이 1개인 경우 : 삭제하는 노드의 부모와 자식을 연결하고 삭제
        38을 삭제 (23과 38의 자식을 연결한다)
        //            23                        
        //      ┌──────┴──────┐
        //      11            38
        //   ┌──┴──┐       ┌──┴──┐
        //   3     19      31    
        //   └─┐ ┌─┴─┐   ┌─┘     
        //     6 17  22  24        
        //            23
        //      ┌──────┴──────┐
        //      11            31
        //   ┌──┴──┐       ┌──┴─
        //   3     19      24    
        //   └─┐ ┌─┴─┐   
        //     6 17  22    
        3. 자식이 2개인 경우 : 삭제하는 노드를 기준으로 오른쪽 자식 중 가장 작은값 노드와 교체 후 삭제
        ex) 38을 삭제
        
        //            23
        //      ┌──────┴──────┐
        //      11            38
        //   ┌──┴──┐       ┌──┴──┐
        //   3     19      31    40
        //   └─┐ ┌─┴─┐   ┌─┘     
        //     6 17  22  24        
        38의 오른쪽 자식 중 가장 작은값 40과 바꾸고 삭제
        //            23
        //      ┌──────┴──────┐
        //      11            40
        //   ┌──┴──┐       ┌──┴──┐
        //   3     19      31    
        //   └─┐ ┌─┴─┐   ┌─┘     
        //     6 17  22  24        
         */
        public class BinarySearchTree<T> where T: IComparable<T>
        {
            //노드를 나타내는 클래스
            private class Node
            {
                public T item;
                public Node parent;
                public Node left;
                public Node right;

                //노드 생성자
                public Node(T item, Node parent, Node left, Node right)
                {
                    this.item = item;
                    this.parent = parent;
                    this.left = left;
                    this.right = right;
                }
            }
            private Node root;
            public BinarySearchTree()
            {
                this.root = null; //처음 노드는 아무것도 없으니까 null로 초기화
            }
            public bool Add(T item)
            {
                if(root == null) //루트 노드가 없으면 생성해서 넣는다
                {
                    Node newNode = new Node(item, null, null, null);
                    root = newNode;
                    return true;
                }
                Node current = root;

                while(current != null)
                {
                    if(item.CompareTo(current.item) < 0)
                    {
                        if(current.left == null)
                        {
                            Node newNode = new Node(item, null, null, null);
                            current.left = newNode;
                            newNode.parent = current;
                            break;
                        }
                        current = current.left;
                    }
                    else if(item.CompareTo(current.item) > 0)
                    {
                        if(current.right == null)
                        {
                            Node newNode = new Node(item, null, null, null);
                            current.right = newNode;
                            newNode.parent = current;
                            break;
                        }
                        current = current.right;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }// end of Add
            public bool Remove(T item)
            {
                Node findNode = FindNode(item);
                if (findNode != null)
                {
                    EraseNode(findNode);
                    return true;
                }
                else
                    return false;
            }
            public bool Contains(T item)
            {
                Node findNode = FindNode(item);
                return findNode != null ? true: false;

            }
            public void Clear()
            {
                root = null;
            }
           
            private Node FindNode(T item)
            {
                if (root == null)
                    return null;

                Node current = root;
                while(current != null)
                {
                    if (item.CompareTo(current.item) < 0)
                    {//현재 노드의 값보다 작다면 왼쪽으로 이동
                        current = current.left;
                    }
                    else if (item.CompareTo(current.item) > 0)
                    {
                        current = current.right;
                    }
                    else
                        return current;
                }
                return null;
            }
            private void EraseNode(Node node)
            {
                if(node.left == null && node.right == null)
                {
                    Node parent = node.parent;

                    if(parent == null)
                    {
                        root = null;
                    }
                    else if(parent.left == node)
                    {
                        parent.left = null;
                    }
                    else if(parent.right == node)
                    {
                        parent.right = null;
                    }
                }
                else if(node.left != null || node.right != null)
                {
                    Node parent = node.parent;
                    Node child = node.left != null? node.left : node.right; 

                    if(parent == null)
                    {
                        root = child;
                        child.parent = null;
                    }
                    else if(parent.left == node)
                    {
                        parent.left = child;
                        child.parent = parent;
                    }
                    else if(parent.right == node)
                    {
                        parent.right = child;
                        child.parent = parent;  
                    }
                }
                else
                {
                    Node nextNode = node.right;
                    while(nextNode.left != null)
                    {
                        nextNode = nextNode.left;
                    }
                    node.item = nextNode.item;
                    EraseNode(nextNode);
                }
            }
        }
        

        static void Main(string[] args)
        {
            BinarySearchTree<int>bst = new BinarySearchTree<int>();
            bst.Add(50);
            bst.Add(30);
            bst.Add(70);
            bst.Add(20);
            bst.Add(40);
            bst.Add(60);
            bst.Add(80);

            int a = 10;
            int b = 20;

            int c = b.CompareTo(a);
            // 현재 수CompareTo( 비교할 수 )
            // 현재수가 비교할 수 보다 크다면 양수 1 반환
            // 같다면 0 작으면 -1을 반환한다.
            Console.WriteLine(c);   

            //과제
            //
        }


    }
}
