using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UnQLiteExplorer.Models;

namespace UnQLiteExplorer.Views
{
    internal static class ViewExtensions
    {
        public static Boolean IsDatastoreAlreadyLoaded(this TreeViewItem root, Datastore ds)
        {
            foreach (TreeViewItem item in root.Items)
            {
                Datastore tag = item.Tag as Datastore;
                if (tag != null)
                {
                    if (tag.FullName.InvariantCultureIgnoreCaseEquals(ds.FullName))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static TreeViewItem Append(this TreeViewItem parent, Datastore ds)
        {
            if (parent != null && ds != null)
            {
                if (parent.IsDatastoreAlreadyLoaded(ds))
                {
                    return null;
                }

                TreeViewItem child = new TreeViewItem();
                child.Tag = ds;
                child.Header = new StackPanel
                {
                    Orientation = System.Windows.Controls.Orientation.Horizontal,
                    Children = 
                    {
                        new Image
                        {
                            Source = Utils.ImageSourceFromUri("../Images/datastore16.png"),
                            Style = Utils.GetGenericStyle("FixedImage16")
                        },
                        new Label
                        {
                            Content = ds.Name
                        }
                    }
                };
                parent.Items.Add(child);
                parent.UpdateLayout();
                child.IsSelected = true;
                return child;
            }

            return null;
        }

        public static void Bold(this TreeViewItem item)
        {
            if (item != null)
            {
                StackPanel sp = item.Header as StackPanel;
                Label label = sp.Children[1] as Label;
                label.FontWeight = FontWeights.SemiBold;
            }
        }

        public static void UnBold(this TreeViewItem item)
        {
            if (item != null)
            {
                StackPanel sp = item.Header as StackPanel;
                Label label = sp.Children[1] as Label;
                label.FontWeight = FontWeights.Normal;
            }
        }

        public static void TurnOnDisconnectIcon(this TreeViewItem item)
        {
            if (item != null)
            {
                StackPanel sp = item.Header as StackPanel;
                Image image = sp.Children[0] as Image;
                image.Source = Utils.ImageSourceFromUri("../Images/disconnect16.png");

                Label label = sp.Children[1] as Label;
                String content = label.Content as String;
                if (!content.EndsWith("(disconnected)"))
                {
                    content += " (disconnected)";
                }

                label.Content = content;
            }
        }

        public static void TurnOnConnectIcon(this TreeViewItem item)
        {
            if (item != null)
            {
                StackPanel sp = item.Header as StackPanel;
                Image image = sp.Children[0] as Image;
                image.Source = Utils.ImageSourceFromUri("../Images/datastore16.png");

                Label label = sp.Children[1] as Label;
                String content = label.Content as String;
                if (content.Contains("(disconnected)"))
                {
                    content = content.TrimEnd(new char[] { '(', 
                        'd' ,'i', 's', 'c', 'o', 'n', 
                        'n', 'e', 'c', 't', 'e', 'd', ')' });
                    content = content.Trim();
                }
                
                label.Content = content;
            }
        }
    }
}
