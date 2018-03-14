using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Collections;

namespace TFSTreeView
{
    public partial class Form1 : Form
    {
        private const string tfsServer = "http://tfstta.int.thomson.com:8080/tfs";
        private static TfsTeamProjectCollection teamProjectCollection = null;

        public Form1()
        {
            InitializeComponent();
            PopulateTreeWithTfsInfo();
        }
        public void PopulateTreeWithTfsInfo()
        {
            try
            {
                if (teamProjectCollection == null)
                {
                    teamProjectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(tfsServer));
                }

                
                WorkItemStore temp = teamProjectCollection.GetService<WorkItemStore>();
                
                foreach (Project proj in temp.Projects)
                {
                    if (proj.Name.ToLower() == "fwswdevcommon")
                    {
                        tfsTreeViewControl.Nodes.Add(proj.Name);
                        enumerateValues(proj.QueryHierarchy as QueryFolder, tfsTreeViewControl.Nodes[0]);
                    }
                }

             }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
            }
        }
       
        private void enumerateValues(QueryFolder items, TreeNode parentnode)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    // Try a 'safe' cast of the current value.
                    // If the cast fails, childEnumerator will be null.
                    var childEnumerator = item;

                    if (childEnumerator is QueryFolder)
                    {
                        TreeNode childNode = parentnode.Nodes.Add(item.Name);

                        enumerateValues(childEnumerator as QueryFolder, childNode);
                    }
                    else if(childEnumerator is QueryItem)
                    {
                        TreeNode childNode = parentnode.Nodes.Add(item.Name.ToString());
                    }
                }
            }
        }

        private void tfsTreeViewControl_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string str = e.Node.FullPath;
        }
    }
}
