using System;

namespace Yinyang.Utilities
{
    /// <summary>
    ///     Enum Comment Attribute
    /// </summary>
    public class EnumCommentAttribute : Attribute
    {
        public string EnumComment { get; protected set; }

        public EnumCommentAttribute(string value) => EnumComment = value;
    }

    /// <summary>
    ///     Common Attribute
    /// </summary>
    public static class CommonAttribute
    {
        /// <summary>
        ///     Get Enum Comment
        /// </summary>
        /// <param name="value">Enum Value</param>
        /// <returns>Enum Comment</returns>
        public static string GetEnumComment(this Enum value)
        {
            var type = value.GetType();

            var fieldInfo = type.GetField(value.ToString());

            if (fieldInfo == null)
            {
                return null;
            }

            var attribs = fieldInfo.GetCustomAttributes(typeof(EnumCommentAttribute), false) as EnumCommentAttribute[];

            return attribs.Length > 0 ? attribs[0].EnumComment : null;
        }
    }
}
