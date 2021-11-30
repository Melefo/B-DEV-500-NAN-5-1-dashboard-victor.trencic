using Doshboard.Backend.Entities;
using Doshboard.Backend.Entities.Widget;

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

        public AWidget GetWidget(string id)
            => _db.GetWidget(id);

        public AWidget NewUserWidget(string userId, WidgetType type)
        {
            var user = _db.GetUserWidgets(userId);
            var widget = type switch
            {
                WidgetType.CityTemp => new CityTempWidget(),
                _ => throw new NotImplementedException()
            };

            user.Widgets.Add(widget.Id);
            _db.SaveWidget(widget);
            _db.SaveUserWidgets(user);

            return widget;
        }    
    }
}
