using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Warehouse.API.Filters
{
    public class ModuleFeatureFilter : IActionFilter
    {
        private readonly IConfiguration _configuration;
        private readonly string _featureName;

        public ModuleFeatureFilter(IConfiguration configuration, string featureName)
        {
            _configuration = configuration;
            _featureName = featureName;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            bool enabled = _configuration.GetValue<bool>($"Features:{_featureName}");
            if (!enabled)
                context.Result = new NotFoundResult();
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ModuleFeatureAttribute : TypeFilterAttribute
    {
        public ModuleFeatureAttribute(string featureName) : base(typeof(ModuleFeatureFilter))
        {
            Arguments = new object[] { featureName };
        }
    }
}
