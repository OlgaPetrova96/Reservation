using System;
using CustomModelBinderApp.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Reservation.Infrastructure
{
    public class CustomDateTimeModelBinderProvider : IModelBinderProvider
    {
        private readonly IModelBinder binder =
            new CustomDateTimeModelBinder(new SimpleTypeModelBinder(typeof(DateTime)));
 
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(DateTime) ? binder : null;
        }
    }
}