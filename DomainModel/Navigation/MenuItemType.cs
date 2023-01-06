using System.ComponentModel;

namespace DomainModel.Navigation
{
    public enum MenuItemType
    {
        [Description("Страница")]
        Page = 1,
        [Description("Ссылка")]
        Url = 2
    }
}