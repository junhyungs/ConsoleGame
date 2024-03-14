namespace _2024_03_14
{
    internal class Program
    {
        /*
         ===================================================================
         트리
         계층적인 자료를 나타내는 자주사용하는 자료구조 (비선형 구조)
         
         부모 노드가 여러 자식노드들을 가질 수 있는 1대 다 구조
         
         [구성요소]
         부모 : 루트 노드 방향으로 직접 연결된 노드
         자식 : 루트 노드 반대방향으로 직접 연결된 노드
         뿌리(root) : 부모노드가 없는 최상위 노드, 트리의 깊이 0에 하나만 존재한다
         가지(branch) : 부모노드와 자식노드가 모두 있는 노드, 트리 중간에 존재
         잎 : 자식 노드가 없는 노드, 트리의 끝에 존재
         길이 : 출발 노드에서 도착 노드까지 거치는 수
         깊이 : 루트 노드부터의 길이
         차수 : 자식 노드의 갯수

         자식 노드의 갯수가 정해져 있다면 배열로.. 정해지지 않았다면 리스트로 구현하는게 일반적이다

         [이진트리]
         부모 노드가 자식 노드를 최대 2개 까지만 가질 수 있는 트리
         일반적으로 이진트리로 구현한다.
         
         비선형적인 자료구조이기 때문에 순서에 대해 규칙이 있어야함
         트리를 순회하는 방법은 전위, 중위, 후위 순회가 있다.
         전위 : 노드 -> 왼쪽 -> 오른쪽
         중위 : 왼쪽 -> 노드 -> 오른쪽
         후위 : 왼쪽 -> 오른쪽 -> 노드
         ===================================================================
         */
        /*                                        
                                     [A]        
                                   /     \
                                 [B]      [C]
                                /  \        \
                              [D]   [E]     [F]
         전위 순회 : A -> B -> D -> E -> C -> F
         중위 순회 : D -> B -> E -> A -> C -> F
         후위 순회 : D -> E -> B -> F -> C -> A
         */
        /*
         재귀 함수 : 자기 자신을 호출한다
         재귀 함수를 사용하기 위해선 종료조건이 반드시 필요하다. 
         void Print()
         {
             Print();
         } 
         */

        public class BinaryNode<T>
        {
            public T item;
            public BinaryNode<T> parent;
            public BinaryNode<T> left;
            public BinaryNode<T> right;

            public BinaryNode(T item)
            {
                this.item = item;
            }
        }
        public class BinaryTree<T>
        {
            private BinaryNode<T> root;

            //루트노드 받아서 초기화
            public BinaryTree(BinaryNode<T> root)
            {
                this.root=root;
            } 

            //전위
            public void PreOrder(BinaryNode<T> node)
            {
                if(node != null)
                {
                    Console.Write(node.item +  " -> ");
                    PreOrder(node.left);
                    PreOrder(node.right);
                }
            }
            public void InOrder(BinaryNode<T> node)
            {
                if (node != null)
                {
                    InOrder(node.left);
                    Console.WriteLine(node.item+" -> ");
                    InOrder(node.right);
                }
            }

            //후위
            public void PostOrder(BinaryNode<T> node)
            {
                if(node != null)
                {
                    PostOrder(node.left);
                    PostOrder(node.right);
                    Console.Write(node.item+" ->  ");

                }
            }
        }
        static void Main(string[] args)
        {
            BinaryNode<char> root = new BinaryNode<char>('A');
            root.left = new BinaryNode<char>('B');
            root.right = new BinaryNode<char>('C');
            root.left.left = new BinaryNode<char>('D');
            root.left.right = new BinaryNode<char>('E');
            root.right.left = new BinaryNode<char>('F');
            root.right.right = new BinaryNode<char>('G');

            BinaryTree<char> tree = new BinaryTree<char>(root);

            Console.WriteLine("전위 순회");
            tree.PreOrder(root);
        }
    }
}
