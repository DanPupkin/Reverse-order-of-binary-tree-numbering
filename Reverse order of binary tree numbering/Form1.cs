using System.Runtime.InteropServices;
using System.Security.AccessControl;
using static Reverse_order_of_binary_tree_numbering.Tree;

namespace Reverse_order_of_binary_tree_numbering
{
    public partial class Form1 : Form
    {
        List<NodeButton> Nodes = new List<NodeButton>();
        NodeStack Nodes_stack = new NodeStack();


        public Form1()
        {
            
            InitializeComponent();
          
            panel1.Click += panel1_click;
            this.Load += Form1_Load;
            // textBox1.TextChanged+= textBox1_TextChanged;
            panel1.Paint += panel1_Paint;
            draw_button.Click += draw_button_Click;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        }

        

        private void Clear_Click(object sender, EventArgs e)
        {
            int len = Nodes_stack.nodes.Length;
            Nodes_stack.nodes = new NodeButton[len];

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            Tree tree = new Tree();
            
            List <Tree.Node> nodes = new List<Tree.Node>();
            foreach(NodeButton b in Nodes)
            {
                nodes.Add(b.node);
            }
            tree.node = Nodes[0].node;
            string s = "";
            string c = "";
            int node_counter = 1;
           tree.GetPostorder(Nodes[0].node, ref s, ref c, ref panel1, ref node_counter);
            s += "\n";
            MessageBox.Show(s+c);
            
            //foreach (NodeButton b in Nodes)
            //{
            //    b.Text = b.node.Value.ToString() +"-"+ b.node.coun.ToString();
            //}
            
            Console.WriteLine(Table[0,0].Value);
            for (int column = 1; column < Table.Rows.Count; column++) { 

            
               Table[column, column].Value = "~";
            }
            
            Table.Columns.RemoveAt(Table.Columns.Count-1);
        

        }
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (draw_box.Checked)
            {
                
                Graphics gr = e.Graphics;
               
                Pen pen = new Pen(Color.Blue, 3);
                foreach (NodeButton b in Nodes)
                {
                    b.ForeColor = b.node.TextColor;

                    Console.WriteLine($"пожилой тест{b.node.coun}");
                    b.Text = b.node.Value.ToString() +"-"+ b.node.coun.ToString();
                    Point p0 = new Point(b.Location.X - panel1.Location.X + 32, b.Location.Y);
                    
                    if (b.node.Left != null)
                    {
                        Point p1 = new Point(b.node.Left.Position.X - panel1.Location.X+32, b.node.Left.Position.Y);
                        gr.DrawLine(pen, p0, p1);
                    }
                    if (b.node.Right != null)
                    {
                        Point p1 = new Point(b.node.Right.Position.X - panel1.Location.X+32, b.node.Right.Position.Y);
                        gr.DrawLine(pen, p0, p1);
                    }

                }
            
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            AllocConsole();
            
        }
        //инициализация консоли для отладки
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        
        int i = 0;
        int counter = 0;
        int Table_counter = 1;

        private void panel1_click(object sender, EventArgs e)
        {
            
            Console.WriteLine(textBox1.Text);
            //создание кнопки по клику
            Random rnd = new Random();
            Image backgroundImage = Image.FromFile("images/26aa.png");

            if (i < 100) {
                Color foreColor = Color.Red;
                Tree.Node Node = new Tree.Node(ref foreColor) { Value = i };
                NodeButton a = new NodeButton() { ForeColor = foreColor, panel = this.panel1, Text = $"{i}", Location = new Point(MousePosition.X - this.Location.X - backgroundImage.Width / 2, MousePosition.Y - this.Location.Y - backgroundImage.Height), BackgroundImage = backgroundImage, Size = backgroundImage.Size, node = Node};
                Nodes.Add(a) ;
                i++;
            }
            foreach (var x in Nodes)
            {
                if (!Controls.Contains(x))
                {
                    
                    x.Font = new Font("Microsoft Sans Serif", 16);
                    x.node.Position = x.Location;
                    x.Click += NodeButton_Click;
                    Controls.Add(x);
                    x.BringToFront();
                    Table.Rows.Add(x.node.Value.ToString());
                    var sub_col = new DataGridViewTextBoxColumn();
                    Table.Columns.Add(sub_col);
                    Table[Table_counter, 0].Value = Table[0, Table_counter].Value; Table_counter++;


                }
            }

        }
        private void NodeButton_Click(object sender, EventArgs e)
        {
            
            NodeButton sub_button = (NodeButton)sender;
            Console.WriteLine(sub_button.node.Left);
            panel1.Refresh();
            if(Nodes_connection_switch.Checked)
            {
                Nodes_stack.Push(sub_button, ref Table);

            }

        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!(textBox1 is null)) { 
            counter = Convert.ToInt32(textBox1.Text);
            }
        }
        private void draw_lines_Click(object sender, PaintEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
        private void draw_button_Click (object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        

        private void Form1_Load_1(object sender, EventArgs e)
        {
            
            var col = new DataGridViewTextBoxColumn();
            var col2 = new DataGridViewTextBoxColumn();
            

            Table.Columns.Add(col);
            Table.Columns.Add(col2);
            Table.Rows.Add("~");
        }
    }
}