namespace DirectorySearchTreeViev
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            ListDirectory(treeView1,"E:\\Test");
            
        }
       

        void ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo, path));
            
        }

        TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo, string path)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);

            foreach (var directory in directoryInfo.GetDirectories())
            {
                var temp = CreateDirectoryNode(directory, path);
                temp.ImageIndex = 1;
                
                directoryNode.Nodes.Add(temp);
                
            }
            foreach (string file in Directory.GetFiles(path))
            {
                var temp = new TreeNode(file);
                temp.ImageIndex = 0;
                directoryNode.Nodes.Add(temp);
            }
            return directoryNode;
        }


        
    }
}




//var directoryNode = new TreeNode(directoryInfo.Name);
//comboBox1.Text = treeView1.ImageList.ToString();
//foreach (var directory in directoryInfo.GetDirectories())
//{
//    directoryNode.Nodes.Add(CreateDirectoryNode(directory));
//}
//foreach (var file in directoryInfo.GetFiles())
//{
//    directoryNode.Nodes.Add(new TreeNode(file.Name));
//    //directoryInfo.
//}
//return directoryNode;