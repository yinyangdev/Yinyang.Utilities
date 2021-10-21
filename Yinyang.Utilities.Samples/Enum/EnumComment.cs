using System;

namespace Yinyang.Utilities.Samples.Enum
{
    /// <summary>
    ///     SampleEnum
    /// </summary>
    public enum SampleEnum
    {
        [EnumComment("無し")] None,
        [EnumComment("追加")] Add,
        [EnumComment("削除")] Delete
    }

    /// <summary>
    ///     EnumComment
    /// </summary>
    public class EnumComment
    {
        /// <summary>
        ///     Get Enum Comment
        /// </summary>
        /// <remarks>
        ///     Enumコメントを取得します
        /// </remarks>
        public void GetEnumComment()
        {
            // 「追加」
            Console.WriteLine(SampleEnum.Add.GetEnumComment());
        }
    }
}
