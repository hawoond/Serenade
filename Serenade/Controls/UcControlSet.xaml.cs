using Serenade.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Serenade.Controls
{
    public delegate void AddTile();
    public delegate void AreaSetting(int x, int y);

    /// <summary>
    /// UcButtonTest.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UcControlSet : UserControl
    {
        // 타일 추가 이벤트 선언, 테스트 용
        public event AddTile addTile;
        // 전체 영역 세팅 이벤트
        public event AreaSetting areaSetting;

        private string folderName = @"C:\Users\wjkim\Source\Repos\Serenade\Serenade\Resource";
        public UcControlSet()
        {
            InitializeComponent();
            // 타일 리스트 초기화

            List<string> arrTilePath = new List<string>(TilePath(folderName));
            for (int i = 0; i < arrTilePath.Count; i++)
            {
                SetTileList(arrTilePath[i]);
            }
        }

        public List<string> TilePath(string sFolderName)
        {
            List<string> arrResult = new List<string>();

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(sFolderName);
            foreach (System.IO.FileInfo File in di.GetFiles())
            {
                if (File.Extension.ToLower().CompareTo(".png") == 0)
                {
                    arrResult.Add(File.FullName);
                }
            }
            return arrResult;
        }

        /// <summary>
        /// 테스트용
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addTile();
        }

        /// <summary>
        /// 전체 영역 설정 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((null != tbInputX.Text && null != tbInputY.Text)
                && (0 != tbInputX.Text.Length && 0 != tbInputY.Text.Length))
            {
                areaSetting(int.Parse(tbInputX.Text), int.Parse(tbInputY.Text));
            }
        }

        /// <summary>
        /// 선택된 타일의 좌표 보여주기
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetLocation(int x, int y)
        {
            lbInputX.Content = (x - 1).ToString();
            lbInputY.Content = (y - 1).ToString();
        }

        /// <summary>
        /// 타일 리스트 세팅
        /// </summary>
        public void SetTileList(string sResourcePath)
        {
            //  sResourcePath = @"C:\Users\wjkim\Source\Repos\Serenade\Serenade\Resource\Residential.png";
            SplitImage splitImage = new SplitImage();
            Bitmap resource = new Bitmap(sResourcePath);
            System.Drawing.Color[,] color = splitImage.GetBitmapPixel(resource);
            List<Bitmap> resourceSplit = splitImage.GetDivisionBitmap(color, 16, 16);

            WrapPanel wpTileGroup = new WrapPanel();

            wpTileGroup.Orientation = Orientation.Horizontal;
            wpTileGroup.Width = color.GetLength(0);
            wpTileGroup.Height = color.GetLength(1);

            wpTileGroup.Margin = new Thickness(5);

            for (int i = 0; i < resourceSplit.Count; i++)
            {
                //// 임시 전체 색상 적용
                //Color testColor = Color.FromRgb(0, 100, byte.Parse(20.ToString()));

                //UcTile ucTile = new UcTile();

                //ucTile.LbName = testColor.ToString();
                //ucTile.ColorTileImage = testColor;
                //ucTile.IsTileType = false;
                //wpTileList.Children.Add(ucTile);
                UcTile ucTile = new UcTile();
                ucTile.BitmapTileImage = resourceSplit[i];
                wpTileGroup.Children.Add(ucTile);
            }
            wpTileList.Children.Add(wpTileGroup);
        }
    }
}
