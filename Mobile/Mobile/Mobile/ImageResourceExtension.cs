using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile
{
    [ContentProperty (nameof(source))]
    class ImageResourceExtension : IMarkupExtension
    {
        public string source { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (source == null)
            {
                return null;
            }

            ImageSource imageSource = ImageSource.FromResource(source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
            return imageSource;
        }
    }
}
