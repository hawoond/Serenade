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

    public delegate void GetLocation(int x, int y); //좌표 알림 이벤트 델리게이트
    /// <summary>
    /// UcTile.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UcTile : UserControl
    {
        public event GetLocation getLocation;
        public UcTile()
        {
            InitializeComponent();

        }

        // 타일, 공간 구분
        // false : 공간, true : 타일
        public bool isTileType
        {
            get;
            set;
        }

        // 타일 환경 속성
        public string sEnvironmentalProperty
        {
            get;
            set;
        }

        // 타일 환경 속성, 일단 색상으로..
        public Color colorTileImage
        {
            get
            {
                Color cValue;
                cValue = (this.grTile.Background as SolidColorBrush).Color;
                return cValue;
            }
            set
            {
                this.grTile.Background = new SolidColorBrush(value);

            }
        }

        // 타일 위치 X좌표
        public int nTileLocationX
        {
            get;
            set;
        }

        // 타일 위치 Y좌표
        public int nTileLocationY
        {
            get;
            set;
        }

        // 마우스 다운 이벤트
        private void grTile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            getLocation(nTileLocationX, nTileLocationY);
        }

        // 또 뭐가 필요하지..
    }
}
