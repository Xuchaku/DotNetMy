using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;


class BinTree
{
    public Petal root;
    public int depth = 0;
    public BinTree()
    {
        root = null;
    }

    public void remove(Petal curPetal)
    {
        if (curPetal.left == null && curPetal.right == null)
        {
            Petal parentPetal = curPetal.parent;
            if (curPetal == parentPetal.left)
            {
                parentPetal.left = null;
            }
            if (curPetal == parentPetal.right)
            {
                parentPetal.right = null;
            }
        }

        if ((curPetal.left == null && curPetal.right != null) || (curPetal.left != null && curPetal.right == null))
        {
            if (curPetal.parent.left == curPetal)
            {
                if(curPetal.left != null)
                    curPetal.parent.left = curPetal.left;
                else
                    curPetal.parent.left = curPetal.right;
            }
            if (curPetal.parent.right == curPetal)
            {
                if(curPetal.right != null)
                    curPetal.parent.right = curPetal.right;
                else
                    curPetal.parent.right = curPetal.left;
            }
        }

        if (curPetal.left != null && curPetal.right != null)
        {
            if (curPetal.right != null && curPetal.right.left != null)
            {
                 
                 Petal leftTree = curPetal.left;
                 Petal start = curPetal.right.left;
                 while (start.left != null)
                 {
                     start = start.left;
                 }

                 start.parent.left = null;
                 Petal rightTree = curPetal.right;
                 start.left = leftTree;
                 start.right = rightTree;
                 if (curPetal.parent.left == curPetal)
                 {
                     curPetal.parent.left = start;
                 }
                 else
                 {
                     curPetal.parent.right = start;
                 }
                 return;

            }
            if (curPetal.right != null && curPetal.right.left == null)
            {
                Console.Write("HERE");
                Petal leftChild = curPetal.left;
                Petal rightChild = curPetal.right;
                rightChild.left = leftChild;
                if (curPetal.parent.left == curPetal)
                {
                    curPetal.parent.left = rightChild;
                }
                else
                {
                    curPetal.parent.right = rightChild;
                }

            }

            
        }
    }
    public Petal search(int val)
    {
        
        Petal currentPetal = root;
        while (currentPetal != null)
        {
            if (currentPetal.data == val)
                return currentPetal;
            else if (val > currentPetal.data)
            {
                currentPetal = currentPetal.right;
            }
            else
            {
                currentPetal = currentPetal.left;
            }
        }
        return null;

    }
    public void Show2(int level, Petal[] curPetals)
    {
        
        if (level == 0)
        {
            if (root != null)
            {
                int cnt = 0;
                Console.Write("    " + root.data);
                Console.Write("\n");
                Petal[] pts = new Petal[(level + 1)*2];
                pts[0] = root.left;
                pts[1] = root.right;
                Show2(level + 1, pts);
            }
        }
        else
        {
            for (int i = 0; i < curPetals.Length; i++)
            {
                if(i == (curPetals.Length/2))
                    Console.Write("    ");
                if (curPetals[i] != null)
                {
                    Console.Write(" " + curPetals[i].data);
                }
                else
                {
                    Console.Write(" *");
                }
            }

            Console.Write("\n");
            int j = 0;
            int cntNull = 0;
            Petal[] pts = new Petal[(int)(Math.Pow(2, (level + 1)))];
            for (int i = 0; i < curPetals.Length; i++)
            {
                if (curPetals[i] == null)
                {
                    cntNull++;
                    pts[j] = null;
                    pts[j+1] = null;
                }
                else
                {
                    pts[j] = curPetals[i].left;
                    pts[j+1] = curPetals[i].right;

                }

                j += 2;
            }

            if (cntNull == curPetals.Length)
                return;
            else
            {
                Show2(level+1, pts);
            }

        }
    }
    
    public void Add(int d)
    {
        if (root != null)
        {
            Petal newPetal = new Petal(d);
            Petal currentPetal = root;
            while (currentPetal != null)
            {   
                if (newPetal.data > currentPetal.data)
                {
                    if(currentPetal.right != null)
                        currentPetal = currentPetal.right;
                    else { 
                        currentPetal.right = newPetal;
                        newPetal.parent = currentPetal;
                        break;
                    }
                }
                if (newPetal.data < currentPetal.data)
                {
                    if (currentPetal.left != null)
                        currentPetal = currentPetal.left;
                    else { 
                        currentPetal.left = newPetal;
                        newPetal.parent = currentPetal;
                        break;
                    }
                }
            }
        }
        else
        {
            root = new Petal(d);
        }
    }
}

class Petal
{
    public Petal left;
    public Petal right;
    public Petal parent;
    public int data;
    public Petal(int d)
    {
        data = d;
        right = null;
        left = null;
        parent = null;
    }
}
class Node
{
    public int data;
    public Node next = null;

    public Node(int d)
    {
        data = d;
    }
}
class LST
{
    public Node head;
    public int sizeLst = 0;
    public LST()
    {
        head = null;
    }

    public void Add(int data)
    {
        if (head != null)
        {
            Node currentNode = head;
            while (currentNode.next != null)
            {
                currentNode = currentNode.next;
            }

            currentNode.next = new Node(data);
            sizeLst++;
        }
        else
        {
            head = new Node(data);
            sizeLst++;
        }
    }

    public void Remove(int index)
    {
        if(index > 0 && index <= sizeLst)
        {
            Node currentNode = head;
            if (index == 1)
            {
                head = currentNode.next;
            }
            else
            {
                Node prevNode = head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.next;
                }
                
                for (int i = 1; i < index - 1; i++)
                {
                    prevNode = prevNode.next;
                }

                prevNode.next = currentNode;
            }

        }
        else
        {
            throw new Exception("Индекс должен быть положительным и быть не большим размера списка");
        }
    }
    public void Show()
    {
        Node currentNode = head;
        while (currentNode != null)
        {
            Console.Write(currentNode.data + "->");
            currentNode = currentNode.next;
        }
    }

    public void Reverse()
    {
        if (head != null && sizeLst > 1)
        {
            Node currentNode = head;
            Node prevNode = null;
            Node nextNode = currentNode.next;
            while (nextNode != null)
            {
                currentNode.next = prevNode;
                prevNode = currentNode;
                currentNode = nextNode;
                nextNode = currentNode.next;
            }

            currentNode.next = prevNode;
            head = currentNode;
        }
    }


}
namespace DotNetMy
{
    class Program
    {
        static void sortA(int[] arr)
        {
            int tmp;
            for (int i = 1; i < arr.Length; i++)
            {
                tmp = arr[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (arr[j] < tmp)
                        break;
                    else
                    {
                        arr[j + 1] = arr[j];
                        arr[j] = tmp;
                    }
                }
            }

           
        }
        static void Main(string[] args)
        { 
            LST myLst = new LST();
            //добавление в список
            myLst.Add(1);
            myLst.Add(2);
            myLst.Add(3);
            myLst.Add(2);
            //вывод на экран
            myLst.Show();
            Console.WriteLine("\n");
            //удаление из списка по индексу(начало с 1)
            myLst.Remove(2);
            myLst.Show();
            Console.WriteLine("\n");
            //реверс
            myLst.Reverse();
            //myLst.Add(88);
            myLst.Show();
            Console.WriteLine("\n");

            BinTree Tree = new BinTree();
            //добавление в бинарное дерево
            /*
            Tree.Add(10);
            Tree.Add(7);
            Tree.Add(12);
            Tree.Add(6);
            Tree.Add(9);
            Tree.Add(11);
            Tree.Add(14);
            Tree.Add(3);
            Tree.Add(4);
            Tree.Add(8);*/

            Tree.Add(10);
            Tree.Add(3);
            Tree.Add(12);
            Tree.Add(11);
            Tree.Add(14);
            Tree.Add(2);
            Tree.Add(1);
            Tree.Add(6);
            Tree.Add(8);
            Tree.Add(5);

            /* Tree.Add(14);
             Tree.Add(9);
             Tree.Add(19);
             Tree.Add(1);
             Tree.Add(10);
             Tree.Add(12);
             Tree.Add(8);*/


            //показ дерева
            Tree.Show2(0, null);

            //поиск по значению, возвращает узел
            Petal p = Tree.search(12);
            if(p != null)
                Console.Write("Найдено:"+p.data);
            else
                Console.Write("Нет узла с заданным значением");
            //удаление узла
            Tree.remove(p);
            Console.Write("\n");
            Tree.Show2(0, null);



            //сортировка вставками
            int[] A = new int[10] {5, 3, 2, 7, 1, -4, 0, 2, 3, 2};
            sortA(A);
            Console.Write("\n");
            for(int i = 0;i<A.Length;i++)
                Console.Write(A[i]+" ");

            Console.ReadKey();
        }
    }
    


}
