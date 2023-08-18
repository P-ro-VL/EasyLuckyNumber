using IronXL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FontFamily = System.Drawing.FontFamily;

namespace EasyLuckyNumber
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public static string dataPath = "";
        public static string backgroundURLPath = "";
        public static string fontFamily = "";
        public static string fontSize = "200";

        public Dictionary<string, FontFamily> loadedFonts = new Dictionary<string, FontFamily>();

        public Settings()
        {
            InitializeComponent();

            dataFilePath.Text = dataPath;
            backgroundPath.Text = backgroundURLPath;
            fontSizeInput.Text = fontSize + "";

            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            
            foreach (var font in installedFontCollection.Families)
            {
                fontFamilyInput.Items.Add(font.Name);
                loadedFonts.Add(font.Name, font);
            }

            fontFamilyInput.SelectedItem = fontFamily;

            dataFileButton.Click += (s, e) =>
            {
                selectDataFile();
            };

            backgroundFile.Click += (s, e) =>
            {
                selectBackgroundFile();
            };

            finishButton.Click += (s, e) =>
            {
                fontSize = fontSizeInput.Text;

                if(fontFamilyInput.SelectedItem != null)
                    fontFamily = fontFamilyInput.Text;

                MainWindow.Instance.displayNumber.FontSize = int.Parse(fontSize);
                System.Windows.Media.FontFamily mfont = new System.Windows.Media.FontFamily(fontFamily);
                MainWindow.Instance.displayNumber.FontFamily = mfont;

                Hide();
            };

            exitButton.MouseDown += (s, e) =>
            {
                Hide();
            };

        }

        private void selectBackgroundFile()
        {
            OpenFileDialog fileSelector = new OpenFileDialog();
            fileSelector.Filter = "Image Files (*.*)|*.*"; ;
            if (fileSelector.ShowDialog() == true)
            {
                string filePath = fileSelector.FileName;

                try
                {
                    BitmapImage image = new BitmapImage(new Uri(filePath));
                    MainWindow.Instance.background.Source = image;

                    backgroundPath.Text = filePath;
                    MessageBox.Show("Thay đổi hình nền thành công!");

                    backgroundURLPath = filePath;

                }catch (Exception ex)
                {
                    MessageBox.Show("Unable to load background image! \n" + ex.ToString());
                }
            }
        }

        private void selectDataFile()
        {
            OpenFileDialog fileSelector = new OpenFileDialog();
            fileSelector.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*"; ;
            if(fileSelector.ShowDialog() == true)
            {
                string filePath = fileSelector.FileName;

                try
                {
                    WorkBook workBook = WorkBook.Load(filePath);
                    WorkSheet workSheet = workBook.WorkSheets[0];
                    RangeColumn dataColumn = workSheet.GetColumn("A");
                    List<int> data = dataColumn.Select(x => x.Int32Value).ToList();

                    MainWindow.data = data;

                    MessageBox.Show("Tải dữ liệu thành công!\nĐã tải: " + data.Count + " bản ghi.");
                
                    dataFilePath.Text = filePath;
                    dataPath = filePath;
                } catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error has occured while trying to load data from "
                        + filePath + "!\n" + ex.ToString());
                }
            }
        }

    }
}
