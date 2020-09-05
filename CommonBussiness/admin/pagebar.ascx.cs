using System;
using System.Text;

namespace CommonBussiness.admin
{
    public partial class pagebar : System.Web.UI.UserControl
    {
        protected string strHtml = string.Empty;
        protected string StartPage = string.Empty;           //首页
        protected string EndPage = string.Empty;             //尾页
        protected string PreviousPage = string.Empty;        //上一页
        protected string NextPage = string.Empty;            //下一页
        protected string DataInfo = string.Empty;
        private int num;
        /// <summary>
        /// 总记录数
        /// </summary>
        public int Num
        {
            get { return num; }
            set { num = value; }
        }
        private int currentPageIndex;
        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPageIndex
        {
            get { return currentPageIndex; }
            set { currentPageIndex = value; }
        }
        private int currentPageCount;
        /// <summary>
        /// 总页数
        /// </summary>
        public int CurrentPageCount
        {
            get { return currentPageCount; }
            set { currentPageCount = value; }
        }
        private int isShowSEPage = 1;
        /// <summary>
        /// 是否显示首尾页[默认显示]
        /// </summary>
        public int ShowSEPage
        {
            get { return isShowSEPage; }
            set { isShowSEPage = value; }
        }
        private int showNumPage = 1;
        /// <summary>
        /// 是否显示数字页[默认显示]
        /// </summary>
        public int ShowNumPage
        {
            get { return showNumPage; }
            set { showNumPage = value; }
        }
        private int btnCount = 8;
        /// <summary>
        /// 页面最多显示多少数字页码[必须为>0的偶数，默认8个]
        /// </summary>
        public int BtnCount
        {
            get { return btnCount; }
            set { btnCount = value; }
        }
        private string staticUrl;
        /// <summary>
        /// 开启伪静态
        /// </summary>
        public string StaticUrl
        {
            get { return staticUrl; }
            set { staticUrl = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (currentPageCount == 1)                       //如果只有1页，没有必要显示数字页码
            {
                return;
            }
            int start = currentPageIndex - (btnCount / 2);     //当前页码.页面显示8个数字页码。
            if (start < 1)
            {
                start = 1;
            }
            int end = start + (btnCount - 1);                //计算终止位置
            if (end > currentPageCount)                      //如果该条件成立，为了保证页面上还是显示8个数字页码，必须调整起始位置。
            {
                end = currentPageCount;
                start = end - (btnCount - 1) > 0 ? end - (btnCount - 1) : 1;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = start; i <= end; i++)
            {
                if (i == currentPageIndex)                   //如果循环出的数字与当前页码相等。
                {
                    sb.Append(string.Format("<a href='javascript:;' style='background: #38769f;color: #fff;'>{0}</a>", i));
                }
                else
                {
                    if (string.IsNullOrEmpty(staticUrl))
                    {
                        sb.Append(string.Format("<a href='?p={0}'>{0}</a>", i));
                    }
                    else
                    {
                        sb.Append(string.Format("<a href='" + staticUrl + "{0}'>{0}</a>", i));
                    }
                }
            }
            if (showNumPage == 0)
            {
                sb.Clear();
            }
            if (isShowSEPage != 0)
            {
                if (string.IsNullOrEmpty(staticUrl))
                {
                    StartPage = "<a  href='?page=1'>首页</a>";
                    EndPage = "<a href='?p=" + currentPageCount + "'>尾页</a>";
                }
                else
                {
                    StartPage = "<a disabled='disabled' href='" + staticUrl + "1'>首页</a>";
                    EndPage = "<a disabled='disabled' href='" + staticUrl + currentPageCount + "'>尾页</a>";
                }
            }
            if (num != 0)
            {
                DataInfo = "<span>共" + currentPageCount + "页 / " + num + "条</span>";
            }
            if (string.IsNullOrEmpty(staticUrl))
            {
                PreviousPage = "<a class='prevpage wow fadeInLeft' href='?page=" + (currentPageIndex - 1) + "'>上一页</a>";
                NextPage = "<a class='nextpage wow fadeInRight' href='?page=" + (currentPageIndex + 1) + "'>下一页</a>";
            }
            else
            {
                if (staticUrl.IndexOf("?") > 0)
                {
                    PreviousPage = "<a disabled='disabled' href=\"" + staticUrl + (currentPageIndex - 1) + "\">上一页</a>";
                    NextPage = "<a disabled='disabled' href=\"" + staticUrl + (currentPageIndex + 1) + "\">下一页</a>";
                }
                else
                {
                    PreviousPage = "<a class=\"prev\" href=\"/" + staticUrl + "-" + (currentPageIndex - 1) + "\"><img src=\"/images/icons09.png\" class=\"default\" ><img src=\"/images/icons09_01.png\" class=\"hover\"><span>上一页</span></a>";
                    NextPage = "<a class=\"next\" href=\"/" + staticUrl + "-" + (currentPageIndex + 1) + "\"><span>下一页</span><img src=\"/images/icons08.png\" class=\"default\"><img src=\"/images/icons08_01.png\" class=\"hover\"></a>";
                }
            }
            if (currentPageIndex == 1 || currentPageIndex == 0)
            {
                PreviousPage = "<a href=\"javascript:;\">上一页</a>";
            }
            else if (currentPageIndex == currentPageCount)
            {
                NextPage = "<a href=\"javascript:;\">下一页</a>";
            }

            strHtml = DataInfo + StartPage + PreviousPage + sb.ToString() + NextPage + EndPage;
        }
    }
}