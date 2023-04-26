using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace order_of_binary_tree_numbering
{
    public class NodeStack
    {
        
        int stack_depth = 2;
        int count;
        
        
        public NodeButton[] nodes { get; set; }
        public NodeStack(int depth=2) 
        { 
            stack_depth = depth;
            nodes = new NodeButton[depth];
        }
        //хранит 2 последних нажатых кнопки связывает их
        public void Push(NodeButton node, ref DataGridView Table)
        {
            
            if (count == nodes.Length)
            {
                Console.WriteLine("нарезка свиней");

                nodes[0] = nodes[1];
                
                nodes[1] = node;
                if (!nodes[1].node.HaveParent)
                {
                    nodes[0].node.Childrens.Add(nodes[1].node);
                   // nodes[1].node.HaveParent = true;
                    Table[nodes[0].node.Value + 1, nodes[1].node.Value + 1].Value = 1;
                    Table[nodes[1].node.Value + 1, nodes[0].node.Value + 1].Value = 1;
                }
                    
                
                
                nodes = new NodeButton[stack_depth];
                count = 0;
                //throw new InvalidOperationException("Переполнение стека кнопок");
            }
            else
            {
                nodes[count++] = node;
                nodes[count++] = node;
                Console.WriteLine("Add node");
            }
            
            
        }


    }
    public class NodeButton : Button
    {

        public Tree.Node node { get; set; }
        

        Point DownPoint;
        bool IsDragMode;
        public Panel panel;
        
        

        //убрать постоянное выделение
        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }
        //закругление кнопки
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(grPath);
            
            base.OnPaint(e);
        }
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            DownPoint = mevent.Location;
            IsDragMode = true;
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            IsDragMode = false;
            base.OnMouseUp(mevent);
        }

        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            if (IsDragMode)
            {
               //перемещение кнопки
                Point p = mevent.Location;
                Point dp = new Point(p.X - DownPoint.X, p.Y - DownPoint.Y);
                Location = new Point(Location.X + dp.X, Location.Y + dp.Y);
                
                Console.WriteLine($"{Location.X}, {Location.Y} двигается");
                //проверка на выход за панель
                if (Location.X < panel.Location.X)
                {
                    Location = new Point(panel.Location.X, Location.Y);
                    
                    IsDragMode = false;
                }
                if (Location.Y < panel.Location.Y)
                {
                    Location = new Point(Location.X, panel.Location.Y);
                    IsDragMode = false;
                }
                if (Location.X+this.Width > panel.Location.X+panel.Width)
                {
                    Location = new Point(panel.Location.X+panel.Width- this.Width, Location.Y);
                    IsDragMode = false;
                }
                if (Location.Y+this.Height > panel.Location.Y+panel.Height)
                {
                    Location = new Point(Location.X, panel.Location.Y + panel.Height - this.Height) ;
                    IsDragMode = false;
                }
                node.Position = Location;
            }

            base.OnMouseMove(mevent);
        }
        public void ToFront()
        {
            this.BringToFront();
        }

    }
    public class Tree
    {
        public class Node { 
        public int Value { get; set; }
        

        //список вершин, смежных данной
        public List<Node> Childrens { get; set; } = new List<Node>();
        

        public bool Used { get; set; } = false;

        //позиция вершины на экране
        public Point Position { get; set; }
        // вспомогательный флаг, для создания дерева
        public bool HaveParent = false;
        public Color TextColor;
        public int count;
        public Node (ref Color clr)
            {
                TextColor= clr;
            }
        }
        public Node node { get; set; }

        //обход в ширину слева-направо
        //для бинарного дерева этот алгоритм очень простой
        //суть алгоритма- проходить по смежным вершинам - нумеруются в порядке посещения(вершины 1 ранга), затем заходить в пронумерованные, нумеровать смежные им вершины, пока  не кончатся вершины 1 ранга
        // после идти по вершинам 2 ранга т.е. смежным только что пронумерованным
        //текст из Е-курсов для общего случая:
        //        Итак, на первом этапе нумеруется исходная вершина.Затем
        //открываются и нумеруются все инцидентные ей ребра, а также
        //нумеруются все вершины 1-го ранга в порядке их посещения.
        //На втором этапе делаются поочередно шаги из вершин 1-го ранга в
        //смежные им вершины, находящиеся на расстоянии одного ребра.При
        //этом соблюдаются следующие правила:
        //- если из рассматриваемой вершины есть непройденное ребро,
        //ведущее в непронумерованную вершину, то ребро открывается и
        //нумеруется, вершина тоже нумеруется;
        //        Дискретная математика 4
        //- если непройденное ребро ведет в уже пронумерованную вершину, то
        //ребро открывается, нумеруется и закрывается;
        //- если из вершины нет больше непройденных ребер, то
        //осуществляется переход на другую вершину того же ранга;
        //- если из вершины нет открытых ребер, то закрывается ведущее к ней
        //ребро;
        //- если все вершины 1-го ранга рассмотрены, то переходим к вершинам
        //2-го ранга.
        //Эта последовательность действий справедлива для вершины любого
        //ранга с небольшой поправкой к четвертому условию для ранга r > 1.
        //Если из вершины нет открытых ребер, то закрывается вся цепочка,
        //ведущая в нее: либо до вершины, из которой есть открытые ребра,
        //либо до начальной вершины.
        //По окончании работы алгоритма обхода в ширину все вершины графа
        //будут пронумерованы, все ребра пронумерованы и закрыты.
        //Обход в ширину дает кратчайшую траекторию до искомой вершины.


        //Деревом называется связный граф без циклов. 
        //Ориентированным деревом называется связный ациклический орграф,
        //в котором только одна вершина, называемая корнем, не имеет
        //входящих ребер, а все остальные вершины имеют по одному
        //входящему ребру.
        //Ориентированным бинарным деревом называется дерево,
        //обладающее следующими свойствами:
        //есть ровно одна вершина, не имеющая ни одного входящего ребра,
        //она называется корнем;
        //каждая вершина, кроме корня, имеет не более одного входящего и не
        //более двух исходящих ребер;
        //каждая вершина достижима из корня
        private void Across(Node node, ref string s, ref string b, ref int counter)
        {
            
            var queue = new Queue<Tree.Node>();
            //queue - FIFO очередь (первый вошел-первый вышел)
            //queue.Enqueue - добавляет элемент в очередь
            //queue.Dequeue - возвращает элемент и удаляет его из очереди
            //queue.Peek - последниц элемент в очереди
            //*Параметры*
            //node - корень, с которого начинается обход
            //s и b - вспомогательные строки, куда записывается ход работы алгоритма
            //counter - счетчик нумерации
            //FIFO очередь гарантирует, что пока не будут пройдены все вершины 1 ранга, алгоритм не коснется вершин 2 ранга.
            //в "" кавычках буду писать то, как выглядит очередь
            //например, ты начинаешь в вершине А, кладешь ее в очередь "А", у нее есть смежные Б и В, по алгоритму они кладутся в очередь. "АБВ", А убирается "БВ", алгоритм идет в Б
            // кладет ее смежные вершины, "БВГДЕ", в конце Б убирается "ВГДЕ"
            queue.Enqueue(node);
            while (queue.Count != 0) // пока очередь не пуста
            {
                //идем по всем смежным ребрам
                foreach (Tree.Node sub_node in queue.Peek().Childrens) { 
                    //если вершина существует, и не использовалась ранее
                if (sub_node != null&& !sub_node.Used)
                {
                     s += "    заносим в очередь значение " + sub_node.Value.ToString() + " смежной вершины" + Environment.NewLine;
                    queue.Enqueue(sub_node);
                     sub_node.Used = true;
                }
                }

                //извлечь из очереди информационное поле последнего элемента
                s += "    извлекаем значение из очереди: " + queue.Peek().Value.ToString() + Environment.NewLine;
                 b += queue.Peek().Value.ToString() + " "; 
                queue.Peek().TextColor = Color.Green;
                //даем вершине номер и увеличиваем счетчик
                queue.Peek().count = counter;
                counter++;
                //удаляем "отработанную" вершину, движемся дальше по очереди в цикле
                queue.Dequeue();
            }

        }
        
        //вспомогательная функция-прослойка, чтобы соблюдать MVC
        public void GetAcross(Node node, ref string s, ref string b, ref int counter)
        {
            this.Across(node, ref s, ref b, ref counter);
        }
    }
}
