using System;
using System.Configuration;
using System.IO;
using System.Web;

namespace Data
{

    public abstract class DBBase
    {
        static bool? _EnableDataContextLogging;
        static string _ConnStr;

        protected virtual NorthwindDataContext DataContext
        {
            get
            {
                NorthwindDataContext context = new NorthwindDataContext();
                if (this.EnableDataContextLogging.Value == true)
                {
                    context.Log = HttpContext.Current.Response.Output;
                }
                context.Connection.ConnectionString = this.ConnStr;
                return context;
            }
        }

        protected virtual bool? EnableDataContextLogging
        {
            get
            {
                if (_EnableDataContextLogging == null)
                {
                    string val = ConfigurationManager.AppSettings["EnableDataContextLogging"];
                    _EnableDataContextLogging = bool.Parse(val);
                }
                return _EnableDataContextLogging;
            }
        }

        protected virtual string ConnStr
        {
            get
            {
                if (_ConnStr == null)
                {
                    _ConnStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                }
                return _ConnStr;
            }
        }
    }
}
