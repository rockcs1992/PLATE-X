using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Web.UI;

namespace Common
{
    /// <summary>
    /// 生成Image Verification Code
    /// </summary>
    public class Verify
    {
        #region 私有变量属性
        public enum CharacterType { Letter, Number, Admixture, Chinese}

        private int _codelength = 4;
        private Color _backgroudcolor = Color.White;
        private int _bmpwidth = 95;
        private int _bmpheigth = 21;
        private bool _border = true;
        private CharacterType _chartype = CharacterType.Admixture;
        private string[] _admixturechar = { "2", "3", "4", "5", "6", "8", "9", 
                                    "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", 
                                    "L", "M", "N", "P", "R", "S", "T", "W", "X", "Y",
                                    "a", "b", "c", "d", "e", "f", "g", "h", "j", "k", 
                                    "l", "m", "n", "p", "r", "s", "t", "w", "x", "y" };
        private string[] _letterchar = {"A", "B", "C", "D", "E", "F", "G", "H", "J", "K", 
                                    "L", "M", "N", "P", "R", "S", "T", "W", "X", "Y",
                                    "a", "b", "c", "d", "e", "f", "g", "h", "j", "k", 
                                    "l", "m", "n", "p", "r", "s", "t", "w", "x", "y" };
        private string[] _numberchar = {"1", "2", "3", "4", "5", "6", "8", "9", "0" };
        //private string _chinesechar = "的一是在不了有和人这中大为上个国我以要他时来用们生到作地于出就分对成会可主发年动同工也能下过子说产种面而方后多定行学法所民得经十三之进着等部度家电力里如水化高自二理起小物现实加量都两体制机当使点从业本去把性好应开它合还因由其些然前外天政四日那社义事平形相全表间样与关各重新线内数正心反你明看原又么利比或但质气第向道命此变条只没结解问意建月公无系军很情者最立代想已通并提直题党程展五果料象员革位入常文总次品式活设及管特件长求老头基资边流路级少图山统接知较将组见计别她手角期根论运农指几九区强放决西被干做必战先回则任取据处队南给色光门即保治北造百规热领七海口东导器压志世金增争济阶油思术极交受联什认六共权收证改清己美再采转更单风切打白教速花带安场身车例真务具万每目至达走积示议声报斗完类八离华名确才科张信马节话米整空$况今集温传土许步群广石记需段研界拉林律叫且究观越织装影算低持音众书布复容儿须际商非验连断深难近矿千周委素技备半办青省列习响约支般史感劳便团往酸历市克何除消构府称太准精值号率族维划选标写存候毛亲快效斯院查江型眼王按格养易置派层片始却专状育厂京识适属圆包火住调满县局照参红细引听该铁价严";
        private Color[] _colors = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, 
                                    Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
        private string[] _fonts = { "Times New Roman", "MS Mincho", "Book Antiqua", "Gungsuh", 
                                    "Arial", "Georgia", "PMingLiU", "Impact" };
        /// <summary>
        /// 随机码长度(默认值为4)
        /// </summary>
        public int CodeLength
        {
            get { return this._codelength; }
            set { this._codelength = value; }
        }

        /// <summary>
        /// Graphics背景色(默认为白色)
        /// </summary>
        public Color BackGroudColor
        {
            get { return this._backgroudcolor; }
            set { this._backgroudcolor = value; }
        }

        /// <summary>
        /// 随机码图片宽度(默认值80)
        /// </summary>
        public int BmpWidth
        {
            get { return this._bmpwidth; }
            set { this._bmpwidth = value; }
        }
        
        /// <summary>
        /// 随机码图片高度(默认值21)
        /// </summary>
        public int BmpHeigth
        {
            get { return this._bmpheigth; }
            set { this._bmpheigth = value; }
        }
        
        /// <summary>
        /// 是否画边框(默认值false)
        /// </summary>
        public bool Border
        {
            get { return this._border; }
            set { this._border = value; }
        }
        
        /// <summary>
        /// 字符集(默认值是字幕和数字混合体)
        /// </summary>
        public CharacterType CharType
        {
            get { return this._chartype; }
            set { this._chartype = value; }
        }
        
        /// <summary>
        /// 混合随机字符
        /// </summary>
        private string[] AdmixtureChar
        {
            get { return this._admixturechar; }
            set { this._letterchar = value;}
        }
        
        /// <summary>
        /// 字母随机字符
        /// </summary>
        private string[] LetterChar
        {
            get { return this._letterchar; }
            set { this._letterchar = value; }
        }
        
        /// <summary>
        /// 数字随机字符
        /// </summary>
        private string[] NumberChar
        {
            get { return this._numberchar; }
            set { this._numberchar = value; }
        }
        
        /// <summary>
        /// 随机颜色
        /// </summary>
        private Color[] Colors
        {
            get { return this._colors; }
            set { this._colors = value; }    
        }
        
        /// <summary>
        /// 随机字体
        /// </summary>
        private string[] Fonts
        {
            get { return this._fonts; }
            set { this._fonts = value; }
        }

        #endregion

        #region  构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public Verify() { }

        #endregion

        #region Image Verification Code方法函数
        /// <summary>
        /// 创建随机码
        /// </summary>
        /// <returns>string</returns>
        public string CreateCode()
        {
            string CodeNumber = string.Empty;
            Random rdm = new Random();
            for (int i = 0; i < CodeLength; i++)
            {
                //判断字符集
                switch (CharType)
                {
                    case CharacterType.Admixture:
                        CodeNumber += AdmixtureChar[rdm.Next(AdmixtureChar.Length)];
                        break;
                    case CharacterType.Letter:
                        CodeNumber += LetterChar[rdm.Next(LetterChar.Length)];
                        break;
                    case CharacterType.Number:
                        CodeNumber += NumberChar[rdm.Next(NumberChar.Length)];
                        break;
                }
            }
            return CodeNumber;
        }
        
        /// <summary>
        /// 创建随机码输出
        /// </summary>
        /// <param name="codeNumber">动态随机码</param>
        /// <param name="page">当前页面</param>
        public void CreateVerifyCode(string codeNumber, Page page)
        {
            MemoryStream ms = new MemoryStream();
            Bitmap bmpImage = CreateImage(codeNumber);
            try
            {
                bmpImage.Save(ms, ImageFormat.Jpeg);
                page.Response.ClearContent();
                page.Response.ContentType = "image/Jpeg";
                page.Response.BinaryWrite(ms.GetBuffer());
            }
            finally
            {
                ms.Dispose();
                bmpImage.Dispose();
            }
        }

        /// <summary>
        /// 创建随机码图片(私有函数)
        /// </summary>
        /// <param name="codeNumber">动态随机码</param>
        /// <returns>Bitmap</returns>
        private Bitmap CreateImage(string codeNumber)
        {
            Bitmap bmp = new Bitmap(BmpWidth, BmpHeigth);
            Graphics grh = Graphics.FromImage(bmp);
            Random rdm = new Random();
            grh.Clear(BackGroudColor);     
            Color penColor = Colors[rdm.Next(Colors.Length)];  //随机产生颜色
            Pen pen = new Pen(penColor);
                   
            for (int i = 0; i < CodeLength*5; i++)
            {
                int x = rdm.Next(bmp.Width);
                int y = rdm.Next(bmp.Height);
                grh.DrawRectangle(pen, x, y, 1, 1);   //画一个矩形方框
            }

            for (int i = 0; i < CodeLength; i++)
            {
                int sWidth = i*(BmpWidth / CodeLength) + 1;   //根据宽度和长度设定随机码在画板中的显示位置
                int sHeigth = BmpHeigth / 2 - 10;
                Brush brh = new SolidBrush(Colors[rdm.Next(Colors.Length)]);
                Font fnt = new Font(Fonts[rdm.Next(Fonts.Length)], 14, FontStyle.Regular);
                grh.DrawString(codeNumber[i].ToString(), fnt, brh, sWidth, sHeigth);  
            }
            if (Border)  //是否有边框
            {
                grh.DrawRectangle(pen, 0, 0, bmp.Width - 1, bmp.Height - 1); //为随机码添加一个边框
            }
            grh.Dispose();
            return bmp;
        }
        #endregion 
    }
}
