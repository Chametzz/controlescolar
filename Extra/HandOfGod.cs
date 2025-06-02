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
using System.Reflection;
using System.Text.RegularExpressions;
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
    public static List<FrameworkElement> GetTagsWidgets(DependencyObject ob)
    {
        List<FrameworkElement> result = new List<FrameworkElement>();
        if (ob is FrameworkElement fe && fe.Tag != null)
        {
            result.Add(fe);
        }

        foreach (var child in GetChilds(ob))
        {
            result.AddRange(GetTagsWidgets(child));
        }
        return result;
    }

    public static void SetTags(DependencyObject ob, Dictionary<string, object?> dict, string nuller = "")
    {
        var data = GetTagsWidgets(ob);
        Console.WriteLine($"{ob} | data: {data.Count}");
        foreach (var element in data)
        {
            string? tag = element.Tag?.ToString();
            if (element is TextBlock tb && tag != null)
            {
                Console.WriteLine($"SET {tb}");
                string newText = tag;
                foreach (var k in HandOfGod.GetStringKeys(tag))
                {
                    if (dict.ContainsKey(k))
                    {
                        Console.WriteLine(dict[k]);
                        string set = dict[k]?.ToString() ?? nuller;
                        newText = newText.Replace("{" + k + "}", set);
                    }
                    else
                    {
                        newText = newText.Replace("{" + k + "}", nuller);
                    }
                }
                Console.WriteLine(newText);
                tb.Text = newText;
            }
            else if (tag != null && dict.TryGetValue(tag, out var value))
            {
                FillElement(element, value, nuller);
            }
        }
    }

    public static void SetTags(DependencyObject ob, object item, string nuller = "")
    {
        var dict = new Dictionary<string, object?>();
        if (item == null) return;
        PropertyInfo[] props = item.GetType().GetProperties();
        foreach (var prop in props)
        {
            if (prop.CanRead)
            {
                dict[prop.Name] = prop.GetValue(item);
            }
        }
        SetTags(ob, dict, nuller);
    }

    public static void FillElement(DependencyObject ob, object? filler, string nuller = "")
    {
        string set = filler?.ToString() ?? nuller;
        if (ob is TextBlock tblock)
        {
            tblock.Text = set;
        }
        else if (ob is TextBox tbox)
        {
            tbox.Text = set;
        }
        else if (ob is ComboBox cb)
        {
            foreach (var item in cb.Items)
            {
                if (item is ComboBoxItem cbi && cbi.Content?.ToString() == set)
                {
                    cb.SelectedItem = cbi;
                    break;
                }
            }
        }
    }

    public static Dictionary<string, object> GetEntries(DependencyObject ob)
    {
        List<FrameworkElement> sample = GetTagsWidgets(ob);
        Dictionary<string, object> data = new Dictionary<string, object>();
        foreach (var entry in sample)
        {
            if (entry is TextBox tb)
                data.Add($"{tb.Tag}", tb.Text);
            else if (entry is PasswordBox pb)
                data.Add($"{pb.Tag}", pb.Password);
            else if (entry is ComboBox cb)
                if (cb.SelectedItem is ComboBoxItem cbi)
                {
                    data.Add($"{cb.Tag}", cbi.Content);
                }
                else
                {
                    data.Add($"{cb.Tag}", "");
                }
            /*else if (entry is CheckBox chk)
                data.Add($"{chk.Tag}", chk.IsChecked);
            else if (entry is RadioButton rb)
                data.Add($"{rb.Tag}", rb.IsChecked);*/
        }
        return data;
    }

    public static List<string> GetStringKeys(string text)
    {
        var keys = new List<string>();
        var matches = Regex.Matches(text, @"\{(.*?)\}");
        foreach (Match match in matches)
        {
            keys.Add(match.Groups[1].Value);
        }
        return keys;
    }
}