using System;
using System.Threading;


namespace LevelSectionBox
{
    public class ClassRequest
    {
        private cSectionbox m_request = new cSectionbox(0,0,false,0,true);
        public cSectionbox Take()
        {
            return (cSectionbox)Interlocked.Exchange(ref m_request, new cSectionbox(0,0,false,0,true));
        }

        public void Make(cSectionbox request)
        {
            Interlocked.Exchange(ref m_request, request);
        }

        public void MakeCOPY(cSectionbox request)
        {
            Interlocked.Exchange(ref m_request, request);
        }
    }

    public class cSectionbox
    {

        public double dCeil { get; set; }
        public double dFloor { get; set; }
        public bool bSelect { get; set; }
        public double dWY { get; set; }
        public bool bZ { get; set; }

        public cSectionbox(double dCeil, double dFloor, bool bSelect,double dWY, bool bZ) //带参数的构造函数
        {
            this.dCeil = dCeil;
            this.dFloor = dFloor;
            this.bSelect = bSelect;
            this.dWY = dWY;
            this.bZ=bZ;
        }
    }
}
