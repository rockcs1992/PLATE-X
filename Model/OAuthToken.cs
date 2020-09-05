using System;
namespace Model
{
    [Serializable]
    public partial class OAuthToken
    {
         public OAuthToken()
         {}
        //access_token	网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同
        //expires_in	access_token接口调用凭证超时时间，单位（秒）
        //refresh_token	用户刷新access_token
        //openid	用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID
        //scope	用户授权的作用域，使用逗号（,）分隔
        public string _access_token;
        public int _expires_in;
        public string _refresh_token;
        public string _openid;
        public string _scope;
        public int _errcode;
        public string _errmsg;
        public string access_token
        {
            set { _access_token = value; }
            get { return _access_token; }
        }
        public int expires_in
        {
            set { _expires_in = value; }
            get { return _expires_in; }
        }

        public string refresh_token
        {
            set { _refresh_token = value; }
            get { return _refresh_token; }
        }
        public string openid
        {
            set { _openid = value; }
            get { return _openid; }
        }
        public string scope
        {
            set { _scope = value; }
            get { return _scope; }
        }
        public int errcode
        {
            set { _errcode = value; }
            get { return _errcode; }
        }
        public string errmsg
        {
            set { _errmsg = value; }
            get { return _errmsg; }
        }
    }
}
