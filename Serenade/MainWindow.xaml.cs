using System;
using System.Collections.Generic;
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
using Serenade.Controls;

namespace Serenade
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        List<UcTile> arrUcTile = new List<UcTile>();

        public MainWindow()
        {
            InitializeComponent();

            this.ucControlSet.addTile += ucControlSet_addTile;
            this.ucControlSet.areaSetting += ucControlSet_areaSetting;

        }

        /// <summary>
        /// 전체 영역 설정 이벤트
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void ucControlSet_areaSetting(int x, int y)
        {
            TileClear();

            int nPadding = 1;
            int nTileSize = 30;

            // 타일 전체 영역 계산
            int nWidthTileSize = ((nPadding * 2) + nTileSize) * x;
            int nHeightTileSize = ((nPadding * 2) + nTileSize) * y;

            this.wpTileArea.Width = nWidthTileSize;
            this.wpTileArea.Height = nHeightTileSize;

            // 임시 전체 색상 적용
            Color testColor = Color.FromRgb(255, 0, 255);


            int nTileLocationX = 1;
            int nTileLocationY = 1;

            // 타일 색상 및 좌표값 입력
            for (int i = 0; i < x * y; i++)
            {
                UcTile ucTile = new UcTile();
                ucTile.getLocation += UcTile_getLocation;
                ucTile.nTileLocationX = nTileLocationX;
                ucTile.nTileLocationY = nTileLocationY;

                // 좌표 입력 1,1 부터 시작
                if (nTileLocationX < x)
                {
                    nTileLocationX++;
                }
                else
                {
                    nTileLocationX = 1;
                    nTileLocationY++;
                }

               
                ucTile.colorTileImage = testColor;
                this.wpTileArea.Children.Add(ucTile);
                arrUcTile.Add(ucTile);

                //if (nTileLocationX == 0)
                //{
                //    nTileLocationX++;
                //}
            }

            // 좌표 별 색상 변환 테스트
            Color testColor2 = Color.FromRgb(0, 0, 0);

            for (int i = 0; i < this.wpTileArea.Children.Count; i++)
            {
                if (((UcTile)this.wpTileArea.Children[i]).nTileLocationX.Equals(3))
                {
                    ((UcTile)this.wpTileArea.Children[i]).colorTileImage = testColor2;
                }
            }
        }

        private void UcTile_getLocation(int x, int y)
        {
            this.ucControlSet.SetLocation(x, y);
        }

        private void ucControlSet_addTile()
        {
            Color testColor = Color.FromRgb(255, 0, 255);

            UcTile ucTile = new UcTile();
            ucTile.colorTileImage = testColor;
            this.wpTileArea.Children.Add(ucTile);
        }

        private void TileClear()
        {
            wpTileArea.Children.Clear();
            arrUcTile.Clear();
        }
    }
}
