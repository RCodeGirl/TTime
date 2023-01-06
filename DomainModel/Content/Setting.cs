namespace DomainModel.Content
{
    public class Setting : BaseEntity
    {
        /// <summary>
        ///     ключ
        /// </summary>
        public string StringKey { get; set; }

        /// <summary>
        ///     значение
        /// </summary>
        public string Value { get; set; }
    }
}