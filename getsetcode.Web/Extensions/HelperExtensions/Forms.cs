using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq.Expressions;
using System.Text;
using getsetcode.Web.Extensions.ObjectExtensions;
using System.IO;

namespace getsetcode.Web.Extensions.HelperExtensions
{
    public static class Forms
    {
        private class Form : IDisposable
        {
            private readonly TextWriter _writer;
            public Form(TextWriter writer)
            {
                _writer = writer;
            }

            public void Dispose()
            {
                _writer.Write("</div>");
                _writer.Write("</div>");
            }
        }

        private static string _requiredHtml = " <i class=\"icon-asterisk\"></i>";

        public enum ValidationType
        {
            None, Email
        }

        public static IDisposable HorizontalFormRow<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, ValidationType validation, bool hideRequiredIndicator = false, string cssClass = null, string overrideLabelText = null)
        {
            var writer = html.ViewContext.Writer;

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);

            writer.WriteLine(formRowOpenTag(metadata.IsRequired, cssClass, validation, html.isErrorField(expression)));

            writer.WriteLine(html.HorizontalFormLabelFor(metadata, expression, hideRequiredIndicator, overrideLabelText));

            writer.WriteLine("<div class=\"controls\">");

            return new Form(writer);
        }

        public static MvcHtmlString HorizontalFormLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, ModelMetadata metadata, Expression<Func<TModel, TValue>> expression, bool hideRequiredIndicator, string overrideLabelText = null)
        {
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);

            string labelText;
            if (!string.IsNullOrEmpty(overrideLabelText))
                labelText = overrideLabelText;
            else
                labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            
            if (String.IsNullOrEmpty(labelText))
                return MvcHtmlString.Empty;

            if (metadata.IsRequired && !hideRequiredIndicator)
                labelText = string.Concat(labelText, _requiredHtml);

            TagBuilder tag = new TagBuilder("label");
            tag.AddCssClass("control-label");
            tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.InnerHtml = labelText;
            
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        private static string formRowOpenTag(bool isRequired, string cssClass, ValidationType validation, bool isErrorField = false, object htmlAttributes = null)
        {
            var css = string.Format("control-group{0}", isErrorField ? " error" : "");

            switch (validation)
            {
                case ValidationType.Email:
                    css = string.Concat(css, " email");
                    break;
            }

            if (!string.IsNullOrEmpty(cssClass))
                css = string.Format("{0} {1}", css, cssClass);

            if (isRequired)
                css = string.Concat(css, " required");

            var sb = new StringBuilder();

            sb.Append(string.Format("<div class=\"{0}\"", css));

            if (htmlAttributes != null)
            {
                foreach (var d in htmlAttributes.ToDictionary())
                {
                    sb.Append(string.Format(" {0}=\"{1}\"", d.Key, d.Value));
                }
            }

            sb.Append(">");

            return sb.ToString();
        }

        private static bool isErrorField<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);

            var msd = html.ViewData.ModelState;
            var error = false;
            if (msd.Keys.Contains(htmlFieldName))
            {
                var i = msd.Keys.ToList().IndexOf(htmlFieldName);
                error = (msd.Values.ElementAt(i).Errors.Count() > 0);
            }

            return error;
        }
    }
}