using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace yılanoyunu
{
     class yilanoyunu
    {
        yilanparcalari[] yilanparcasi;
        int buyukluk;
        yonu yonum;
        public yilanoyunu()
        {
            yilanparcasi = new yilanparcalari[3];
            buyukluk = 3;
            yilanparcasi[0] = new yilanparcalari(150, 150);
            yilanparcasi[1] = new yilanparcalari(160, 150);
            yilanparcasi[2] = new yilanparcalari(170, 150);
        }
        public void yilanilerle(yonu yon)
        {
            yonum = yon;
            if (yon.yon_x == 0 && yon.yon_y == 0)
            {

            }
            else
            {
                if (yon != null)
                {
                    for (int i = yilanparcasi.Length - 1; i > 0; i--)
                    {
                        yilanparcasi[i] = new yilanparcalari(yilanparcasi[i - 1].parca_x, yilanparcasi[i - 1].parca_y);
                    }
                    yilanparcasi[0] = new yilanparcalari(yilanparcasi[0].parca_x + yon.yon_x, yilanparcasi[0].parca_y + yon.yon_y);
                }// parçalar beraber gidicekler. 
            }
        }
        public void yilanboyu()
        {
            Array.Resize(ref yilanparcasi, yilanparcasi.Length + 1);
            yilanparcasi[yilanparcasi.Length - 1] = new yilanparcalari(yilanparcasi[yilanparcasi.Length - 2].parca_x-yonum.yon_x,yilanparcasi[yilanparcasi.Length - 2].parca_y - yonum.yon_y);
            buyukluk++;
        }
        public Point pozisyon(int numara)
        {
            return new Point(yilanparcasi[numara].parca_x, yilanparcasi[numara].parca_y);
        }
    }
        class yilanparcalari
        {
            public int parca_x;
            public int parca_y;
            
            public readonly int size_x;
            public readonly int size_y;
            public yilanparcalari(int x,int y) 
            {
                parca_x=x;
                parca_y=y;
                size_x = 10;
                size_y = 10;
            }
        }
        class yonu
        {
            public readonly int yon_x;
            public readonly int yon_y;
            public yonu(int x, int y) 
            {
                yon_x=x; 
                yon_y=y;
            }
        

    }
}
