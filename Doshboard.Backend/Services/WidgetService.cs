using Doshboard.Backend.Entities;
using Doshboard.Backend.Entities.Widgets;
using Doshboard.Backend.Exceptions;

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

        /// <summary>
        /// Get widget by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Widget GetWidget(string id)
            => _db.GetWidget(id);
        
        /// <summary>
        /// Add widget to User by his type
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// <exception cref="UserException"></exception>
        public Widget NewUserWidget(string userId, string type)
        {
            var user = _db.GetUserWidgets(userId);
            Widget widget = type switch
            {
                CityTempWidget.Name => new CityTempWidget(),
                FootWidget.Name => new FootWidget(),
                RealTimeCryptoWidget.Name => new RealTimeCryptoWidget(),
                GameWidget.Name => new GameWidget(),
                VideoWidget.Name => new VideoWidget(),
                FeedWidget.Name => new FeedWidget(),
                _ => throw new NotImplementedException()
            };

            if (widget is VideoWidget)
            {
                var account = _db.GetUser(userId);
                if (account.Google == null)
                    throw new UserException("You must have your Google Account associated to use this widget");
            }

            user.Widgets.Add(widget.Id);
            _db.SaveWidget(widget);
            _db.SaveUserWidgets(user);

            return widget;
        }

        /// <summary>
        /// Delete widget to User by his ID
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="widgetId"></param>
        public void DeleteUserWidget(string userId, string widgetId)
        {
            var user = _db.GetUserWidgets(userId);
            if (!user.Widgets.Contains(widgetId))
                return;
            user.Widgets.Remove(widgetId);

            _db.DeleteWidget(widgetId);
            _db.SaveUserWidgets(user);
        }

        /// <summary>
        /// Update Widget from new Widget Data
        /// </summary>
        /// <param name="widgetData"></param>
        public void UpdateWidget(Widget widgetData) 
            => _db.SaveWidget(widgetData);
    }
}
