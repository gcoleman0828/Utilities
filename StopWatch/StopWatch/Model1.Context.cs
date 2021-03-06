﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StopWatch
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class dashEntities : DbContext
    {
        public dashEntities()
            : base("name=dashEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Query> Queries { get; set; }
        public DbSet<URL> URLs { get; set; }
        public DbSet<UserAnalytic> UserAnalytics { get; set; }
    
        public virtual int AddQueryString(Nullable<System.Guid> uRLID, string queryString)
        {
            var uRLIDParameter = uRLID.HasValue ?
                new ObjectParameter("URLID", uRLID) :
                new ObjectParameter("URLID", typeof(System.Guid));
    
            var queryStringParameter = queryString != null ?
                new ObjectParameter("QueryString", queryString) :
                new ObjectParameter("QueryString", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddQueryString", uRLIDParameter, queryStringParameter);
        }
    
        public virtual ObjectResult<URL> AddURL(Nullable<System.Guid> analyticsID, string uRL)
        {
            var analyticsIDParameter = analyticsID.HasValue ?
                new ObjectParameter("AnalyticsID", analyticsID) :
                new ObjectParameter("AnalyticsID", typeof(System.Guid));
    
            var uRLParameter = uRL != null ?
                new ObjectParameter("URL", uRL) :
                new ObjectParameter("URL", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<URL>("AddURL", analyticsIDParameter, uRLParameter);
        }
    
        public virtual ObjectResult<URL> AddURL(Nullable<System.Guid> analyticsID, string uRL, MergeOption mergeOption)
        {
            var analyticsIDParameter = analyticsID.HasValue ?
                new ObjectParameter("AnalyticsID", analyticsID) :
                new ObjectParameter("AnalyticsID", typeof(System.Guid));
    
            var uRLParameter = uRL != null ?
                new ObjectParameter("URL", uRL) :
                new ObjectParameter("URL", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<URL>("AddURL", mergeOption, analyticsIDParameter, uRLParameter);
        }
    
        public virtual ObjectResult<UserAnalytic> AddUserAnalytics(Nullable<System.Guid> userGUID, string method, string area, string controller, string action, Nullable<bool> favorites, string userName)
        {
            var userGUIDParameter = userGUID.HasValue ?
                new ObjectParameter("UserGUID", userGUID) :
                new ObjectParameter("UserGUID", typeof(System.Guid));
    
            var methodParameter = method != null ?
                new ObjectParameter("Method", method) :
                new ObjectParameter("Method", typeof(string));
    
            var areaParameter = area != null ?
                new ObjectParameter("Area", area) :
                new ObjectParameter("Area", typeof(string));
    
            var controllerParameter = controller != null ?
                new ObjectParameter("Controller", controller) :
                new ObjectParameter("Controller", typeof(string));
    
            var actionParameter = action != null ?
                new ObjectParameter("Action", action) :
                new ObjectParameter("Action", typeof(string));
    
            var favoritesParameter = favorites.HasValue ?
                new ObjectParameter("Favorites", favorites) :
                new ObjectParameter("Favorites", typeof(bool));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UserAnalytic>("AddUserAnalytics", userGUIDParameter, methodParameter, areaParameter, controllerParameter, actionParameter, favoritesParameter, userNameParameter);
        }
    
        public virtual ObjectResult<UserAnalytic> AddUserAnalytics(Nullable<System.Guid> userGUID, string method, string area, string controller, string action, Nullable<bool> favorites, string userName, MergeOption mergeOption)
        {
            var userGUIDParameter = userGUID.HasValue ?
                new ObjectParameter("UserGUID", userGUID) :
                new ObjectParameter("UserGUID", typeof(System.Guid));
    
            var methodParameter = method != null ?
                new ObjectParameter("Method", method) :
                new ObjectParameter("Method", typeof(string));
    
            var areaParameter = area != null ?
                new ObjectParameter("Area", area) :
                new ObjectParameter("Area", typeof(string));
    
            var controllerParameter = controller != null ?
                new ObjectParameter("Controller", controller) :
                new ObjectParameter("Controller", typeof(string));
    
            var actionParameter = action != null ?
                new ObjectParameter("Action", action) :
                new ObjectParameter("Action", typeof(string));
    
            var favoritesParameter = favorites.HasValue ?
                new ObjectParameter("Favorites", favorites) :
                new ObjectParameter("Favorites", typeof(bool));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UserAnalytic>("AddUserAnalytics", mergeOption, userGUIDParameter, methodParameter, areaParameter, controllerParameter, actionParameter, favoritesParameter, userNameParameter);
        }
    
        public virtual ObjectResult<GetURLByID_Result> GetURLByID(Nullable<System.Guid> uRLID)
        {
            var uRLIDParameter = uRLID.HasValue ?
                new ObjectParameter("URLID", uRLID) :
                new ObjectParameter("URLID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetURLByID_Result>("GetURLByID", uRLIDParameter);
        }
    
        public virtual ObjectResult<GetUserAnalyticsByID_Result> GetUserAnalyticsByID(Nullable<System.Guid> analyticsID)
        {
            var analyticsIDParameter = analyticsID.HasValue ?
                new ObjectParameter("AnalyticsID", analyticsID) :
                new ObjectParameter("AnalyticsID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUserAnalyticsByID_Result>("GetUserAnalyticsByID", analyticsIDParameter);
        }
    
        public virtual int AddAllAnalytics(Nullable<System.Guid> userGUID, string method, string area, string controller, string action, Nullable<bool> favorites, string userName, string uRL, string queryString)
        {
            var userGUIDParameter = userGUID.HasValue ?
                new ObjectParameter("UserGUID", userGUID) :
                new ObjectParameter("UserGUID", typeof(System.Guid));
    
            var methodParameter = method != null ?
                new ObjectParameter("Method", method) :
                new ObjectParameter("Method", typeof(string));
    
            var areaParameter = area != null ?
                new ObjectParameter("Area", area) :
                new ObjectParameter("Area", typeof(string));
    
            var controllerParameter = controller != null ?
                new ObjectParameter("Controller", controller) :
                new ObjectParameter("Controller", typeof(string));
    
            var actionParameter = action != null ?
                new ObjectParameter("Action", action) :
                new ObjectParameter("Action", typeof(string));
    
            var favoritesParameter = favorites.HasValue ?
                new ObjectParameter("Favorites", favorites) :
                new ObjectParameter("Favorites", typeof(bool));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var uRLParameter = uRL != null ?
                new ObjectParameter("URL", uRL) :
                new ObjectParameter("URL", typeof(string));
    
            var queryStringParameter = queryString != null ?
                new ObjectParameter("QueryString", queryString) :
                new ObjectParameter("QueryString", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddAllAnalytics", userGUIDParameter, methodParameter, areaParameter, controllerParameter, actionParameter, favoritesParameter, userNameParameter, uRLParameter, queryStringParameter);
        }
    }
}
