using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Caching;
using System.Web;
 
/// <summary>
/// 缓存数据
/// </summary>
  public  class DoCache
    {
      /// <summary>
      /// 将对象放入缓存
      /// </summary>
      /// <param name="cachekey"></param>
      /// <param name="obj"></param>
      public static void AddCache(string cachekey, object obj)
      {

          if (Global_Upload.UseCache)
          {
              if (obj != null)
              {
                  Cache c = HttpRuntime.Cache;
                  c.Insert(cachekey, obj, null, DateTime.Now.AddMinutes(ConfigHelper.GetConfigInt("CacheTime")), Cache.NoSlidingExpiration);

              }
          }
      }

      /// <summary>
      /// 返回缓存数据 
      /// </summary>
      /// <param name="cachekey"></param>
      /// <returns></returns>
      public static object GetCache(string cachekey)
      {
          if (Global_Upload.UseCache)
          {
              Cache c = HttpRuntime.Cache;

              if (c[cachekey] != null)
                  return c[cachekey];
              return null;
          }
          else
              return null;
        

      }


      /// <summary>
      /// 将对象放入缓存(加入文件)
      /// </summary>
      /// <param name="cachekey"></param>
      /// <param name="obj"></param>
      public static void AddCacheChangeInfo(string cachekey, object obj)
      {
          string filename = HttpContext.Current.Server.MapPath("~/cache/changeinfo/index.txt");
          Cache c = HttpRuntime.Cache;
          c.Insert(cachekey, obj,new CacheDependency(filename), DateTime.Now.AddMinutes(ConfigHelper.GetConfigInt("CacheTime")), Cache.NoSlidingExpiration);
      }

      /// <summary>
      /// 返回缓存数据 
      /// </summary>
      /// <param name="cachekey"></param>
      /// <returns></returns>
      public static object GetCacheChangeInfo(string cachekey)
      {
          Cache c = HttpRuntime.Cache;

          if (c[cachekey] != null)
              return c[cachekey];
          return null;

      }


      
    }
 
