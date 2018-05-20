using Serenade.UDT;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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

        public void Init()
        {
            this.isTileType = false;
            this.colorTileImage = new Color();
            this.sEnvironmentalProperty = string.Empty;
            this.nTileLocationX = 0;
            this.nTileLocationY = 0;
        }

        /// <summary>
        /// 타일, 공간 구분 
        /// false : 아이템, true : 타일 </summary>
        /// </summary>
        private bool isTileType;
        public bool IsTileType
        {
            get
            {
                return isTileType;
            }
            set
            {
                isTileType = value;
                if (isTileType)
                {
                    lbTileName.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.Padding = new Thickness(5, 5, 5, 5);
                    lbTileName.Visibility = Visibility.Visible;
                }
                
            }
        }

        ///// <summary>
        ///// 타일 이름 설정
        ///// </summary>
        private string lbName;
        public string LbName
        {
            get
            {
                return lbName;
            }
            set
            {
                lbName = value;
                lbTileName.Content = lbName;
            }
        }


        // 타일 환경 속성
        public string sEnvironmentalProperty
        {
            get;
            set;
        }

        // 타일 환경 속성, 일단 색상으로..
        private Color colorTileImage;
        public Color ColorTileImage
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
            if (isTileType)
            {
                if (nTileLocationX != 0 && nTileLocationY != 0)
                {
                    getLocation(nTileLocationX, nTileLocationY);
                }
            }
            else
            {
                InfoMaster.Instance().SelectedColor = this.colorTileImage;
            }
        }

        // 또 뭐가 필요하지..
    }
}
