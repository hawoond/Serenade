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

        public UcControlSet()
        {
            InitializeComponent();
            // 타일 리스트 초기화
            SetTileList();
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
        public void SetTileList()
        {
            for (int i = 0; i < 255; i++)
            {
                // 임시 전체 색상 적용
                Color testColor = Color.FromRgb(0, 100, byte.Parse(i.ToString()));

                UcTile ucTile = new UcTile();
                ucTile.isTileType = false;
                ucTile.lbName = testColor.ToString();
                ucTile.colorTileImage = testColor;

                wpTileList.Children.Add(ucTile);
            }

        }
    }
}
