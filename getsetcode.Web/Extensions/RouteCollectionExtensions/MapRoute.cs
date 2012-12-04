using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics.CodeAnalysis;
using System.Collections.ObjectModel;
using System.Web.Routing;
using System.Web.Mvc;

namespace getsetcode.Web.Extensions.RouteCollectionExtensions
{
    /// <summary>
    /// http://erraticdev.blogspot.co.uk/2011/03/removing-route-values-from-linksurls-in.html
    /// </summary>
    public static class RouteCollectionExtensions
    {
        /// <summary>
        /// Maps the specified URL route and sets route value names to remove and default route values.
        /// </summary>
        /// <param name="routes">A collection of routes for the application.</param>
        /// <param name="name">The name of the route to map.</param>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="routeValueNames">Comma separated string with route value names that should be removed when route generates URLs.</param>
        /// <param name="defaults">An object that contains default route values.</param>
        /// <returns>A reference to the mapped <see cref="RouteWithExclusions"/> object instance.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "2#")]
        public static Route MapRoute(this RouteCollection routes, string name, string url, string routeValueNames, object defaults)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            Route item = new RouteWithExclusions(url, new MvcRouteHandler(), routeValueNames)
            {
                Defaults = new RouteValueDictionary(defaults),
                DataTokens = new RouteValueDictionary()
            };
            routes.Add(name, item);
            return item;
        }

        /// <summary>
        /// Maps the specified URL route and sets route value names to remove, default route values and constraints.
        /// </summary>
        /// <param name="routes">A collection of routes for the application.</param>
        /// <param name="name">The name of the route to map.</param>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="routeValueNames">Comma separated string with route value names that should be removed when route generates URLs.</param>
        /// <param name="defaults">An object that contains default route values.</param>
        /// <param name="constraints">A set of expressions that specify values for the url parameter.</param>
        /// <returns>A reference to the mapped <see cref="RouteWithExclusions"/> object instance.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "2#")]
        public static Route MapRoute(this RouteCollection routes, string name, string url, string routeValueNames, object defaults, object constraints)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            Route item = new RouteWithExclusions(url, new MvcRouteHandler(), routeValueNames)
            {
                Defaults = new RouteValueDictionary(defaults),
                Constraints = new RouteValueDictionary(constraints),
                DataTokens = new RouteValueDictionary()
            };
            routes.Add(name, item);
            return item;
        }
    }


    public class RouteWithExclusions : Route
    {
        #region Properties
 
        /// <summary>
        /// Gets route values that are excluded when route generates URLs.
        /// </summary>
        /// <value>Route values that should be excluded.</value>
        public ReadOnlyCollection<string> ExcludedRouteValuesNames { get; private set; }
 
        #endregion
 
        #region Constructor
 
        /// <summary>
        /// Initializes a new instance of the <see cref="RouteWithExclusions"/> class.
        /// </summary>
        /// <param name="url">Route URL definition.</param>
        /// <param name="routeHandler">Route handler instance.</param>
        /// <param name="commaSeparatedRouteValueNames">Comma separated string with route values that should be removed when generating URLs.</param>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#")]
        public RouteWithExclusions(string url, IRouteHandler routeHandler, string commaSeparatedRouteValueNames)
            : this(url, routeHandler, (commaSeparatedRouteValueNames ?? string.Empty).Split(','))
        {
            // does nothing
        }
 
        /// <summary>
        /// Initializes a new instance of the <see cref="RouteWithExclusions"/> class.
        /// </summary>
        /// <param name="url">Route URL definition.</param>
        /// <param name="routeHandler">Route handler instance.</param>
        /// <param name="excludeRouteValuesNames">Route values to remove when generating URLs.</param>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#")]
        public RouteWithExclusions(string url, IRouteHandler routeHandler, params string[] excludeRouteValuesNames)
            : base(url, routeHandler)
        {
            this.ExcludedRouteValuesNames = new ReadOnlyCollection<string>(excludeRouteValuesNames.Select<string, string>(val => val.Trim()).ToList());
        }
 
        #endregion
 
        #region Route overrides
 
        /// <summary>
        /// Returns information about the requested route.
        /// </summary>
        /// <param name="httpContext">An object that encapsulates information about the HTTP request.</param>
        /// <returns>
        /// An object that contains the values from the route definition.
        /// </returns>
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            return base.GetRouteData(httpContext);
        }
 
        /// <summary>
        /// Returns information about the URL that is associated with the route.
        /// </summary>
        /// <param name="requestContext">An object that encapsulates information about the requested route.</param>
        /// <param name="values">An object that contains the parameters for a route.</param>
        /// <returns>
        /// An object that contains information about the URL that is associated with the route.
        /// </returns>
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            if (requestContext == null)
            {
                throw new ArgumentNullException("requestContext");
            }
 
            // create new route data and include only non-excluded values
            RouteData excludedRouteData = new RouteData(this, this.RouteHandler);
 
            // add route values
            requestContext.RouteData.Values
                .Where(pair => !this.ExcludedRouteValuesNames.Contains(pair.Key, StringComparer.OrdinalIgnoreCase))
                .ToList()
                .ForEach(pair => excludedRouteData.Values.Add(pair.Key, pair.Value));
            // add data tokens
            requestContext.RouteData.DataTokens
                .ToList()
                .ForEach(pair => excludedRouteData.DataTokens.Add(pair.Key, pair.Value));
 
            // intermediary request context
            RequestContext currentContext = new RequestContext(new HttpContextWrapper(HttpContext.Current), excludedRouteData);
 
            // create new URL route values and include only none-excluded values
            RouteValueDictionary excludedRouteValues = new RouteValueDictionary(
                values
                    .Where(v => !this.ExcludedRouteValuesNames.Contains(v.Key, StringComparer.OrdinalIgnoreCase))
                    .ToDictionary(pair => pair.Key, pair => pair.Value)
            );
 
            VirtualPathData result = base.GetVirtualPath(currentContext, excludedRouteValues);
            return result;
        }
 
        #endregion
    }
}