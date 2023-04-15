using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_order_of_binary_tree_numbering
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
                if (nodes[0].node.Left == null && !nodes[1].node.HaveParent) { 
                nodes[0].node.Left = nodes[1].node;
                    nodes[1].node.HaveParent = true;
                    Table[nodes[0].node.Value+1, nodes[1].node.Value + 1].Value = 1;
                    Table[nodes[1].node.Value + 1, nodes[0].node.Value + 1].Value = 1;

                    Console.WriteLine("Left");
                }
                else if(nodes[0].node.Right == null && !nodes[1].node.HaveParent)
                {
                    nodes[0].node.Right = nodes[1].node;
                    nodes[1].node.HaveParent = true;
                    Table[nodes[0].node.Value + 1, nodes[1].node.Value+1].Value = 1;
                    Table[nodes[1].node.Value + 1, nodes[0].node.Value + 1].Value = 1;

                    Console.WriteLine("Right");
                }
                else
                {
                    Console.WriteLine("Все связи это ноды заполнены");
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
        public int Count = 0;
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Point Position { get; set; }
            public bool HaveParent = false;
            public Color TextColor;
        public Node (ref Color clr)
            {
                TextColor= clr;
            }
        }
        public Node node { get; set; }
        private void Postorder(Node node, ref string s, ref string b, ref Panel panel)
        {



            if (node != null)
            {
                node.TextColor = Color.Green;
               

                s += "    обходим левое поддерево" + "\n";
                Postorder(node.Left, ref s, ref b, ref panel);
                


                s += "    обходим правое поддерево" + "\n";
                Postorder(node.Right, ref s, ref b, ref panel);


                s += "    получили значение " + node.Value.ToString() + "\n";

                //s += node.Value.ToString() + " ";
                b += node.Value.ToString() + " ";

                

            }
            else { s += "    значение отсутствует - null" + "\n"; panel.Refresh(); }
            }
        public void GetPostorder(Node node, ref string s, ref string b, ref Panel panel)
        {
            this.Postorder(node,ref s, ref b, ref panel);
        }
    }
}
