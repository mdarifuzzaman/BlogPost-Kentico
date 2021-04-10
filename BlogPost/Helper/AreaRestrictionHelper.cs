﻿using Kentico.PageBuilder.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.Helper
{
    public static class AreaRestrictionHelper
    {
        /// <summary>
        /// Gets list of widget identifiers allowed for landing page.
        /// </summary>
        public static string[] GetLandingPageRestrictions()
        {
            var allowedScopes = new[] { "Kentico.", "BlogPost.General.", "BlogPost.LandingPage." };

            return GetWidgetsIdentifiers()
                .Where(id => allowedScopes.Any(scope => id.StartsWith(scope, StringComparison.OrdinalIgnoreCase)))
                .ToArray();
        }


        /// <summary>
        /// Gets list of widget identifiers allowed for home page.
        /// </summary>
        public static string[] GetHomePageRestrictions()
        {
            var deniedScopes = new[] { "BlogPost.LandingPage." };

            return GetWidgetsIdentifiers()
                .Where(id => deniedScopes.Any(scope => !id.StartsWith(scope, StringComparison.OrdinalIgnoreCase)))
                .ToArray();
        }


        private static IEnumerable<string> GetWidgetsIdentifiers()
        {
            return new ComponentDefinitionProvider<WidgetDefinition>()
                   .GetAll()
                   .Select(definition => definition.Identifier);
        }
    }
}
