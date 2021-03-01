using System.Reflection;

namespace AdaMedicine.Net.Core.Reflection
{
    /// <summary>
    /// Annotated type information
    /// </summary>
    public interface IAnnotatedType
    {
        /// <summary>
        /// Gets the annotated property.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <returns></returns>
        IPropertyInfo GetAnnotatedProperty(PropertyInfo property);
    }
}