using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media.Imaging;
using FontFamily = System.Drawing.FontFamily;
using Microsoft.Office.Interop.Excel;
using System.Windows.Controls;

namespace EasyLuckyNumber
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : System.Windows.Window
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
            fontFamilyInput.SelectionChanged += (s, e) =>
            {
                ComboBox cb = s as ComboBox;
                fontFamily = (string) cb.SelectedItem;
            };

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

                if (fontFamily.Equals("") == false)
                {
                    fontFamily = fontFamilyInput.Text;
                    System.Windows.Media.FontFamily mfont = new System.Windows.Media.FontFamily(fontFamily);
                    MainWindow.Instance.displayNumber.FontFamily = mfont;
                }

                MainWindow.Instance.displayNumber.FontSize = int.Parse(fontSize);
                

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
                    Microsoft.Office.Interop.Excel.Application xlApp;
                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                    Microsoft.Office.Interop.Excel.Range range;

                    string str;
                    int rCnt;
                    int cCnt;
                    int rw = 0;
                    int cl = 0;

                    xlApp = new Microsoft.Office.Interop.Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Open(filePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    range = xlWorkSheet.UsedRange;
                    rw = range.Rows.Count;
                    cl = range.Columns.Count;

                    List<string> dataColumn = new List<string>();
                    for (rCnt = 1; rCnt <= rw; rCnt++)
                    {
                        for (cCnt = 1; cCnt <= 1; cCnt++)
                        {
                            str = (string) (range.Cells[rCnt, cCnt] as Microsoft.Office.Interop.Excel.Range).Value2.ToString() + "";
                            dataColumn.Add(str);
                        }
                    }

                    xlWorkBook.Close(true, null, null);
                    xlApp.Quit();

                    Marshal.ReleaseComObject(xlWorkSheet);
                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(xlApp);

                    List<int> data = dataColumn.Select(x => int.Parse(x)).ToList();

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
