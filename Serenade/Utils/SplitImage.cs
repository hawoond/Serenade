using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Serenade.Utils
{
    public class SplitImage
    {
        /// <summary>
        /// 비트맵의 전체 픽셀을 Color Array로 반환한다.
        /// </summary>
        public System.Drawing.Color[,] GetBitmapPixel(Bitmap bitmap)
        {
            if (bitmap == null)
                return null;

            System.Drawing.Color[,] pixel = new System.Drawing.Color[bitmap.Width, bitmap.Height];
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    pixel[i, j] = bitmap.GetPixel(i, j);
                }
            }
            return pixel;
        }

        /// <summary>
        /// 입력받은 Color Array에서 지정된 넓이, 높이, 위치 만큼 가로로 분할하여 비트맵을 반환한다.
        /// </summary>
        public List<Bitmap> GetDivisionBitmap(System.Drawing.Color[,] pixel, int width, int height)
        {
            List<Bitmap> arrBitmap = new List<Bitmap>();

            // 세로 타일 수
            for (int j = 0; j < pixel.GetLength(1) / height; j++)
            {
                // 가로 타일 수
                for (int i = 0; i < pixel.GetLength(0) / width; i++)
                {
                    Bitmap bitmap = new Bitmap(width, height);
                    // 타일 하나 만들기
                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            int left = x + width * i;
                            int top = y + height * j;
                            bitmap.SetPixel(x, y, pixel[left, top]);
                        }
                    }
                    // 만든거 담기
                    arrBitmap.Add(bitmap);
                }
            }

            return arrBitmap;
        }
    }
}
