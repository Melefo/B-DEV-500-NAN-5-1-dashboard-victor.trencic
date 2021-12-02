using Doshboard.Backend.Entities;
using Doshboard.Backend.Entities.Widgets;

namespace Doshboard.Backend.Services
{
    public class WidgetService
    {
        /// <summary>
        /// Database access
        /// </summary>
        private readonly MongoService _db;

        public WidgetService(MongoService db)
            => _db = db;

        /// <summary>
        /// Get services linked to an user
        /// </summary>
        /// <param name="user">User account</param>
        /// <returns>User services</returns>
        public UserWidgets GetUserWidgets(string userId)
            => _db.GetUserWidgets(userId);

        public Widget GetWidget(string id)
            => _db.GetWidget(id);

        public Widget NewUserWidget(string userId, string type)
        {
            var user = _db.GetUserWidgets(userId);
            var widget = type switch
            {
                CityTempWidget.Name => new CityTempWidget(),
                _ => throw new NotImplementedException()
            };

            user.Widgets.Add(widget.Id);
            _db.SaveWidget(widget);
            _db.SaveUserWidgets(user);

            return widget;
        }

        public void DeleteUserWidget(string userId, string widgetId)
        {
            var user = _db.GetUserWidgets(userId);
            if (!user.Widgets.Contains(widgetId))
                return;
            user.Widgets.Remove(widgetId);

            _db.DeleteWidget(widgetId);
            _db.SaveUserWidgets(user);
        }

        public void UpdateWidget(Widget widgetData)
        {
            _db.SaveWidget(widgetData);
        }
    }
}
