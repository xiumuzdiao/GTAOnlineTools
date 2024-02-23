using GTA5OnlineTools.Utils;

using GTA5Shared.Helper;
using GTA5Core.GTA.Stats;

namespace GTA5OnlineTools.Windows;

/// <summary>
/// GTAHaxWindow.xaml 的交互逻辑
/// </summary>
public partial class GTAHaxWindow
{
    public GTAHaxWindow()
    {
        InitializeComponent();
    }

    private void Window_GTAHax_Loaded(object sender, RoutedEventArgs e)
    {
        TextBox_PreviewGTAHax.Text = "INT32\n";

        // STAT列表
        foreach (var item in StatData.StatClasses)
        {
            ListBox_GTAHaxClass.Items.Add(item.Name);
        }
        ListBox_GTAHaxClass.SelectedIndex = 0;
    }

    private void Window_GTAHax_Closing(object sender, CancelEventArgs e)
    {

    }

    private void AppendTextBox(string statName, int value)
    {
        TextBox_PreviewGTAHax.AppendText($"${statName}\n");
        TextBox_PreviewGTAHax.AppendText($"{value}\n");
    }

    private void ListBox_GTAHaxClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ListBox_GTAHaxClass.SelectedItem is string statClassName)
        {
            var result = StatData.StatClasses.Find(t => t.Name == statClassName);
            if (result == null)
                return;

            TextBox_PreviewGTAHax.Clear();
            TextBox_PreviewGTAHax.AppendText("INT32\n");

            for (var i = 0; i < result.StatInfos.Count; i++)
            {
                var hash = result.StatInfos[i].Hash;
                var value = result.StatInfos[i].Value;

                AppendTextBox(hash, value);
            }
        }
    }

    private void Button_ImportGTAHax_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        var stat = TextBox_PreviewGTAHax.Text;
        if (string.IsNullOrWhiteSpace(stat))
        {
            NotifierHelper.Show(NotifierType.Warning, "stat代码不能为空，操作取消");
            return;
        }

        HackUtil.ImportGTAHax(TextBox_PreviewGTAHax.Text);
    }
}
