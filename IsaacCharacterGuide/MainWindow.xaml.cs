using System.Drawing;
using System.IO;
using System;
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

namespace IsaacCharacterGuide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Characters>charactersList = new List<Characters>();
        List<Starter> StarterItemList = new List<Starter>();
        List<Stat> StarterStatList = new List<Stat>();
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            foreach (var item in charactersList)
            {
                CharacterPicker.Items.Add(item.Name);
            }
            CharacterPicker.SelectedIndex = 0;
            FillReleaseDate();
        }

        private void LoadData()
        {
            
            using (StreamReader sr = new(@"../../../src/StarterItem.txt", Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    StarterItemList.Add(new Starter(sr.ReadLine()));
                }
            }

            using (StreamReader sr2 = new(@"../../../src/StarterStats.txt", Encoding.UTF8))
            {
                while (!sr2.EndOfStream)
                {
                    StarterStatList.Add(new Stat(sr2.ReadLine()));
                }
            }

           
            using (StreamReader sr3 = new(@"../../../src/Characters.txt", Encoding.UTF8))
            {
                while (!sr3.EndOfStream)
                {
                    charactersList.Add(new Characters(sr3.ReadLine(), StarterItemList,StarterStatList));
                }
            }
        }
        private void CharacterPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReleaseDateLbl.Content = string.Empty;
            FillReleaseDate();
            FillStarterStat();
            FillStarterItem();
            ImageCh();
        }

        private void FillReleaseDate()
        {
            
            var Release = charactersList.Where(x=>x.Name.Equals(CharacterPicker.SelectedItem)).Single();
            ReleaseDateLbl.Content = Release.ReleaseDate.ToString();
        }
        private void FillStarterStat()
        {
            StatsDataGrid.Items.Clear();
            var stats = charactersList.Where(x => x.Name.Equals(CharacterPicker.SelectedItem)).Single().StarterStat;
            foreach (var item in stats)
            {
                StatsDataGrid.Items.Add(item);
            }
        }
        private void FillStarterItem()
        {
            StarterItemsDataGrid.Items.Clear();
            var items = charactersList.Where(x => x.Name.Equals(CharacterPicker.SelectedItem)).Single().StarterItem;
            foreach (var item in items)
            {
                StarterItemsDataGrid.Items.Add(item);
            }
        }
        private void ImageCh()
        {
            var CharacterName = charactersList.Where(cs => cs.Name.Equals(CharacterPicker.SelectedItem)).Single().Name.ToString() + ".jpg";
            var ItemName = charactersList.Where(cs => cs.Name.Equals(CharacterPicker.SelectedItem)).Single().StarterItem.Select(x => x.Name).FirstOrDefault() + ".jpg";
            string path = Directory.GetCurrentDirectory().ToString().Replace("\\bin\\Debug\\net8.0-windows", "");
            CharacterI.Source = new BitmapImage(new Uri($@"{path}\ChImages\{CharacterName}"));
            ItemI.Source = new BitmapImage(new Uri($@"{path}\ItImages\{ItemName}"));
        }

    }
}