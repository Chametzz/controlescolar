using controlescolar;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
public static class HandOfGod
{
    public static Dictionary<string, object> ExecuteSubmit(object sender)
    {
        if (sender is DependencyObject ob)
        {
            DependencyObject form = ob;
            while (form is FrameworkElement fe && $"{fe.Tag}" != "Form")
            {
                form = GetParent(fe);
            }
            return GetEntries(form);
        } 
        else
        {
            return new Dictionary<string, object>();
        }
    }
    public static DependencyObject GetParent(DependencyObject ob)
    {
        return LogicalTreeHelper.GetParent(ob);
    }
    public static DependencyObject[] GetChilds(DependencyObject ob)
    {
        if (ob == null) return new DependencyObject[0];
        
        int count = VisualTreeHelper.GetChildrenCount(ob);
        if (count == 0) return new DependencyObject[0];

        DependencyObject[] children = new DependencyObject[count];
        for (int i = 0; i < count; i++)
        {
            children[i] = VisualTreeHelper.GetChild(ob, i);
        }
        return children;
    }
    public static List<DependencyObject> GetTagsWidgets(DependencyObject ob)
    {
        List<DependencyObject> result = new List<DependencyObject>();
        if (ob is FrameworkElement fe && fe.Tag!= null)
        {
            result.Add(ob);
        }

        foreach (var child in GetChilds(ob))
        {
            result.AddRange(GetTagsWidgets(child));
        }
        return result;
    }

    public static Dictionary<string, object> GetEntries(DependencyObject ob)
    {
        List<DependencyObject> sample = GetTagsWidgets(ob);
        Dictionary<string, object> data = new Dictionary<string, object>();
        foreach (var entry in sample)
        {
            if (entry is TextBox tb)
                data.Add($"{tb.Tag}", tb.Text);
            else if (entry is PasswordBox pb)
                data.Add($"{pb.Tag}", pb.Password);
            else if (entry is ComboBox cb)
                data.Add($"{cb.Tag}", cb.SelectedItem);
            else if (entry is CheckBox chk)
                data.Add($"{chk.Tag}", chk.IsChecked);
            else if (entry is RadioButton rb)
                data.Add($"{rb.Tag}", rb.IsChecked);
        }
        return data;
    }
}